namespace tech_test_payment_api.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public string Item { get; set; }
        public DateTime Data { get; set; }
        public StatusPagamento Status { get; set; }

    }
}