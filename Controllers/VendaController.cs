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


        // RETORNA UMA VENDA BASEADO NO ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Venda venda = _context.Vendas.Find(id);

            if(venda == null) {
                return NotFound();
            }

            return Ok(venda);

        }


        // CADASTRA VENDA (NECESSITA PASSAR UM ID DE VENDEDOR EXISTENTE)
        [HttpPost("{idVendedor}")]
        public IActionResult Create(Venda venda, int idVendedor) {

            Vendedor vendedor = _context.Vendedores.Find(idVendedor);

            if(vendedor == null) {
                return NotFound();
            }

            // ADICIONA A ID DO VENDEDOR, NA FOREIGN KEY 'VENDEDORID' EM VENDAS
            venda.VendedorId = vendedor.Id;

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return Ok(venda);

        }


        // FAZ CONTROLE PARA TROCA DE STATUS DA VENDA
        [HttpPatch("{idVenda},{statusVenda}")]
        public IActionResult ChangeStatus(int idVenda, int statusVenda) {
            Venda venda = _context.Vendas.Find(idVenda);


            if (venda == null) {
                return NotFound();
            }

            // VERIFICA SE O STATUSVENDA P/ ATUALIZAR ACEITA CONDIÇÃO IMPOSTA

            // STATUS 0 (AGUARDANDO_PGMT) PODE ATUALIZAR P/ STATUS 1 (PGMT_APROVADO)
            if (statusVenda == 1) {
                if (venda.Status == StatusPagamento.Aguardando_Pagamento) {
                    venda.Status = StatusPagamento.Pagamento_Aprovado;

                    _context.Vendas.Update(venda);
                    _context.SaveChanges();

                    return Ok(venda);
                } else {
                    return BadRequest();
                }
            }

            // STATUS 1 (PGMT_APROVADO) PODE ATUALIZAR P/ STATUS 2 (ENV_PARA_TRANSPORTADORA)
            else if (statusVenda == 2) {
                if (venda.Status == StatusPagamento.Pagamento_Aprovado) {
                    venda.Status = StatusPagamento.Enviado_Para_Transportadora;

                    _context.Vendas.Update(venda);
                    _context.SaveChanges();

                    return Ok(venda);
                } else {
                    return BadRequest();
                }

            }

            // STATUS 2 (ENV_PARA_TRANSPORTADORA) PODE ATUALIZAR P/ STATUS 3 (ENTREGUE)
            else if (statusVenda == 3) {
                if (venda.Status == StatusPagamento.Enviado_Para_Transportadora) {
                    venda.Status = StatusPagamento.Entregue;

                    _context.Vendas.Update(venda);
                    _context.SaveChanges();

                    return Ok(venda);
                } else {
                    return BadRequest();
                }

            }

            // STATUS 0 (AGUARDANDO_PGMT) OU 1 (PGMT_APROVADO) PODE ATUALIZAR P/ STATUS 4 (CANCELADO)
            else if (statusVenda == 4) {
                if (venda.Status == StatusPagamento.Aguardando_Pagamento || venda.Status == StatusPagamento.Pagamento_Aprovado) {
                    venda.Status = StatusPagamento.Cancelada;

                    _context.Vendas.Update(venda);
                    _context.SaveChanges();

                    return Ok(venda);
                } else {
                    return BadRequest();
                }


            }

            return BadRequest();
        }
    }
}