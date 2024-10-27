using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Interface;
using CC.Model;
using CC.Data;
using Microsoft.EntityFrameworkCore;

namespace CC.Repositories
{
    public class RecordRepository
    {
        private readonly AppDbContext _context;

        public RecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Record>> GetAllAsync() => await _context.Records.ToListAsync();

        public async Task<Record> GetByIdAsync(Guid id) => await _context.Records.FindAsync(id);

        public async Task AddAsync(Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Record record)
        {
            _context.Records.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var record = await GetByIdAsync(id);
            if (record != null)
            {
                _context.Records.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
