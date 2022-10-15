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


        // BUSCA UM VENDEDOR E TODAS SUAS VENDAS POR ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            // BUSCA O VENDEDOR PELO ID
            Vendedor vendedor = _context.Vendedores.Find(id);
            // BUSCA TODAS VENDAS BASEADOS NO ID DO VENDEDOR (POR FOREIGN KEY)
            List<Venda> venda = _context.Vendas.Where(x => x.VendedorId.Equals(id)).ToList();

            // ADICIONA VENDAS ENCONTRADAS PELA FK, NO CAMPO DE VENDAS DO VENDEDOR
            vendedor.Vendas = venda;

            if(vendedor == null) {
                return NotFound();
            }

            return Ok(vendedor);
        }



        // CADASTRA UM NOVO VENDEDOR
        [HttpPost]
        public IActionResult Create(Vendedor vendedor) {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();

            return Ok(vendedor);
        }



        // EDITA UM VENDEDOR JÁ CADASTRADO
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


        // EXCLUI UM VENDEDOR JÁ CADASTRADO
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