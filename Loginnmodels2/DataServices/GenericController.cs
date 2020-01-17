//using GenericController.API.Models;
//using GenericController.AspNetMvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Loginnmodels2.Data;

namespace Loginnmodels2.GenericController
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GenericController<T> : Controller where T : class, IAppEntity
    {
        private IApplicationRepository<T> _repository;
        

        public GenericController(IApplicationRepository<T> repository)
        {
            _repository = repository;
            
        }

        [HttpGet]
        public IActionResult Query(int take = 10, int skip = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_repository.Get().Skip(skip).Take(take).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var record = await _repository.GetAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _repository.Create(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return CreatedAtAction("Find", new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T record)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != record.Id)
                return BadRequest();

            _repository.Update(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _repository.Delete(id);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }

        
    }
}