using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Entities;

namespace tech_test_payment_api.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendedorController(VendaContext context) {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Vendedor vendedor = _context.Vendedores.Find(id);
            List<Venda> venda = _context.Vendas.Where(x => x.VendedorId.Equals(id)).ToList();

            vendedor.Vendas = venda;

            if(vendedor == null) {
                return NotFound();
            }

            return Ok(vendedor);
        }



        [HttpPost]
        public IActionResult Create(Vendedor vendedor) {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();

            return Ok(vendedor);
        }



        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, Vendedor vendedor) {
            var vendedorConsultado = _context.Vendedores.Find(id);

            if(vendedorConsultado == null) {
                return NotFound();
            }

            vendedorConsultado.Nome = vendedor.Nome;
            vendedorConsultado.Cpf = vendedor.Cpf;
            vendedorConsultado.Email = vendedor.Email;
            vendedorConsultado.Telefone = vendedor.Telefone;

            _context.Vendedores.Update(vendedorConsultado);
            _context.SaveChanges();

            return Ok(vendedorConsultado);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            var vendedorConsultado = _context.Vendedores.Find(id);

            if(vendedorConsultado == null) {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedorConsultado);
            _context.SaveChanges();

            return NoContent();
        }
    }
    
}