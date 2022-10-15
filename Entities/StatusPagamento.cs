namespace tech_test_payment_api.Entities
{
    public enum StatusPagamento
{
    Aguardando_Pagamento = 0,
    Pagamento_Aprovado = 1,
    Enviado_Para_Transportadora = 2,
    Entregue = 3,
    Cancelada = 4,
}
}