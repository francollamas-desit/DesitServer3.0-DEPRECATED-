using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desit.Models;
using Desit.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desit.Controllers
{

    [Route("api/[controller]")]
    public class CentralesController : ControllerBase
    {
        private readonly CentralRepo centrales;

        public CentralesController(CentralRepo centrales)
        {
            this.centrales = centrales;
        }

        // GET: api/Centrales/Estados
        [Route("Estados")]
        public async Task<IActionResult> GetEstadoCentrales()
        {
            return Ok(await centrales.GetEstadoCentrales());
        }

        // GET: api/Centrales/Estados/5
        [Route("Estados/{id}")]
        public async Task<IActionResult> GetEstadosCentral([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Central central = await centrales.Get(id);
            if (central == null)
            {
                return NotFound();
            }

            return Ok(await centrales.GetEstadosCentral(id));

        }

        // GET: api/Centrales
        [HttpGet]
        public async Task<IEnumerable<Central>> GetCentrales()
        {
            return await centrales.GetAll();
        }

        // GET: api/Centrales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCentral([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Central central = await centrales.Get(id);
            if (central == null)
            {
                return NotFound();
            }

            return Ok(central);
        }

        // PUT: api/Centrales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentral([FromRoute] string id, [FromBody] Central central)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != central.CentralId)
            {
                return BadRequest();
            }

            if (await centrales.Update(central))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/Centrales
        [HttpPost]
        public async Task<IActionResult> PostCentral([FromBody] Central central)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await centrales.Insert(central);

            return CreatedAtAction("GetCentral", new { id = central.CentralId }, central);
        }

        // DELETE: api/Centrales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentral([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await centrales.Delete(id))
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