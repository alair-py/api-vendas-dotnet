namespace tech_test_payment_api.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public virtual List<Venda> Vendas { get; set; }
    }
}