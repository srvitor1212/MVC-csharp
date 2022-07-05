using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cerveja.Data;
using Cerveja.Models;

namespace ApiCerveja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly CervejaContext _context;
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(CervejaContext context, DepartamentoService departamentoService)
        {
            _context = context;
            _departamentoService = departamentoService;
        }

        //------------------------------------------------------------------------------------------------------
        // GET: api/Departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamento()
        {
            return _departamentoService.FindAll();
        }

        //------------------------------------------------------------------------------------------------------
        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            return _departamentoService.FindById(id);
        }

        //------------------------------------------------------------------------------------------------------
        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id)
                return BadRequest();

            string ret =_departamentoService.Update(id, departamento);

            if (ret != "Ok")
                return BadRequest();
            else
                return NoContent();
        }

        //------------------------------------------------------------------------------------------------------
        // POST: api/Departamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
          if (_context.Departamento == null)
          {
              return Problem("Entity set 'CervejaContext.Departamento'  is null.");
          }
            _context.Departamento.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            if (_context.Departamento == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return (_context.Departamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
