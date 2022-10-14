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
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context) {
            _context = context;
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Venda venda = _context.Vendas.Find(id);

            if(venda == null) {
                return NotFound();
            }

            return Ok(venda);

        }



        [HttpPost("{idVendedor}")]
        public IActionResult Create(Venda venda, int idVendedor) {

            Vendedor vendedor = _context.Vendedores.Find(idVendedor);

            if(vendedor == null) {
                return NotFound();
            }

            venda.VendedorId = vendedor.Id;

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return Ok(venda);

        }
    }
}