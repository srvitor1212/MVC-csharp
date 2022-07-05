using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;
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
                return Problem("ID no parâmetro não confere com ID do Body!");

            string ret =_departamentoService.Update(id, departamento);

            if (ret != "Ok")
                return BadRequest();
            else
                return NoContent();
        }

        //------------------------------------------------------------------------------------------------------
        // POST: api/Departamentos
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            var ret = _departamentoService.FindById(departamento.Id);
            if (ret != null)
                return Problem("Este departamento já existe!");

            _departamentoService.Create(departamento);
            
            
            return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
        }

        //------------------------------------------------------------------------------------------------------
        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var dep = _departamentoService.FindById(id);
            if (dep == null)
                return NotFound();

            _departamentoService.Remove(dep);
            
            
            return NoContent();
        }
    }
}
