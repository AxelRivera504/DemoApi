using DemoApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ClienteController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<Cliente> clientes = await _applicationDbContext.Clientes.Where(x => x.ClienteActivo).ToListAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Cliente cliente)
        {
            if (cliente is null)
                return BadRequest("Cliente no puede ser vacio");

            if(string.IsNullOrEmpty(cliente.Nombre))
                return BadRequest("El nombre del cliente no puede estar vacio");

            if (string.IsNullOrEmpty(cliente.Correo))
                return BadRequest("El correo del cliente no puede estar vacio");

            await _applicationDbContext.Clientes.AddAsync(cliente);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateClient(int id,Cliente cliente)
        {
            Cliente? clienteBuscado = await _applicationDbContext.Clientes.FindAsync(id);

            if (clienteBuscado == null)
                return BadRequest("El cliente que desea actualizar no existe en la BD");

            if (cliente is null)
                return BadRequest("Cliente no puede ser vacio");

            if (string.IsNullOrEmpty(cliente.Nombre))
                return BadRequest("El nombre del cliente no puede estar vacio");

            if (string.IsNullOrEmpty(cliente.Correo))
                return BadRequest("El correo del cliente no puede estar vacio");

            clienteBuscado.Nombre = cliente.Nombre;
            clienteBuscado.Telefono = cliente.Telefono;
            clienteBuscado.Correo = cliente.Correo;
            clienteBuscado.Direccion = cliente.Direccion;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(clienteBuscado);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            Cliente? clienteBuscado = await _applicationDbContext.Clientes.FindAsync(id);

            if (clienteBuscado == null)
                return BadRequest("El cliente que desea actualizar no existe en la BD");

            clienteBuscado.ClienteActivo = false;

            await _applicationDbContext.SaveChangesAsync();

            return Ok("El registro del cliente solicitado ha sido desactivado");
        }
    }
}
