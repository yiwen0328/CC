using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CC.Dtos;
using CC.Interface;
using CC.Model;
using Microsoft.AspNetCore.Mvc;





namespace CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;

        public RecordsController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetAll()
        {
            var records = await _recordRepository.GetAllAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetById(Guid id)
        {
            var record = await _recordRepository.GetByIdAsync(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RecordDto recordDto)
        {
            var record = new Record
            {
                Age = recordDto.Age,
                Name = recordDto.Name,
                IsActive = recordDto.IsActive
            };
            await _recordRepository.AddAsync(record);
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] RecordUpdateDto recordDto)
        {
            var record = await _recordRepository.GetByIdAsync(id);
            if (record == null) return NotFound();

            if (recordDto.Age.HasValue) record.Age = recordDto.Age.Value;
            if (recordDto.Name != null) record.Name = recordDto.Name;
            if (recordDto.IsActive.HasValue) record.IsActive = recordDto.IsActive.Value;
            if (recordDto.Description != null) record.Description = recordDto.Description;

            await _recordRepository.UpdateAsync(record);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _recordRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
