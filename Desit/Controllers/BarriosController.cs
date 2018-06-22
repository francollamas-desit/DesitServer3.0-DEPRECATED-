using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desit.Models;
using Microsoft.AspNetCore.Authorization;
using Desit.Repositories;

namespace Desit.Controllers
{
    [Route("api/[controller]")]
    public class BarriosController : ControllerBase
    {
        private readonly BarrioRepo barrios;

        public BarriosController(BarrioRepo barrios)
        {
            this.barrios = barrios;
        }

        // GET: api/Barrios
        [HttpGet]
        public async Task<IEnumerable<Barrio>> GetBarrio()
        {
            return await barrios.GetAll();
        }

        // GET: api/Barrios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarrio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Barrio barrio = await barrios.Get(id);
            if (barrio == null)
            {
                return NotFound();
            }
            
            return Ok(barrio);
        }

        // PUT: api/Barrios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarrio([FromRoute] int id, [FromBody] Barrio barrio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barrio.BarrioId)
            {
                return BadRequest();
            }

            if (await barrios.Update(barrio))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST: api/Barrios
        [HttpPost]
        public async Task<IActionResult> PostBarrio([FromBody] Barrio barrio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await barrios.Insert(barrio);

            return CreatedAtAction("GetBarrio", new { id = barrio.BarrioId }, barrio);
        }

        // DELETE: api/Barrios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarrio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (await barrios.Delete(id))
            {
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}