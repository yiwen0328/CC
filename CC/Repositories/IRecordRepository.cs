using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CC.Model;



namespace CC.Repositories
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllAsync();
        Task<Record> GetByIdAsync(Guid id);
        Task AddAsync(Record record);
        Task UpdateAsync(Record record);
        Task DeleteAsync(Guid id);
    }
}
