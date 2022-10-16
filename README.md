# API PAYMENT POTTENCIAL
VIDEO:

Teste final do bootcamp Digital Innovation One e Pottencial, trata-se de uma API de Vendas, em que se pode cadastrar Vendedor através de um CRUD e também Vendas, ambos em tabelas diferentes e relacionadas através de Foreign Key. Abaixo uma documentação básica de utilização dos serviços.

  

## EndPoint VENDA

* ### GET /Venda/{id}

Descrição: Retorna uma venda armazenada no banco de dados.

#### Parâmetros

	Necessário parâmetro ID.

#### Respostas

	200 - Sucesso! 
Exemplo:

```
{
	"id": 3,
	"vendedorId": 17,
	"item": "RTX 3060",
	"data": "2022-02-20T13:22:21",
	"status": 0
}
```

	400 - ID inválido. Motivos: "ID diferente de padrão esperado."

	404 - Não encontrado. Motivos: "ID não corresponde a uma venda válida."

  

* ### POST /Venda/{idVendedor}

Descrição:  Adiciona nova venda ao banco de dados.

#### Parâmetros

	Necessário parâmetro ID de um vendedor válido.

Exemplo Request Body:

```
{
	"item": "Monitor 2k",
	"data": "2022-10-16T16:34:50.770Z",
	"status": 0
}
```

#### Respostas

	200 - Sucesso!

	400 - Requisição inválida. Motivos: "ID inválido ou valor nulo em campo obrigatório."

  

* ### PATCH /Venda/{idVenda},{statusVenda}

Descrição: Altera status da venda. 
#### Atenção! 
Novas vendas são registradas automaticamente com status 'Aguardando Pagamento'. 
Os status possuem as seguintes regras de alteração:
 >'Aguardando Pagamento' para 'Pagamento Aprovado'.
 'Aguardando Pagamento' para 'Cancelado'
 'Pagamento Aprovado' para 'Cancelado'
 'Pagamento Aprovado' para 'Enviado a Transportadora'
 'Enviado a Transportadora' para 'Entregue'

#### Parâmetros

	Necessário parâmetros "idVenda", "statusVenda".

#### IDs para alteração: 
>1 = Pagamento Aprovado 
2 = Enviado p/ Transportadora
3 = Entregue
4 = Cancelado

  

#### Respostas

	200 - Sucesso!

	400 - Requisição inválida. Motivos: "Possível alteração de status fora das regras estabelecidas."

	404 - Não encontrado. Motivos: "ID de venda não encontrado."

  

## EndPoint VENDEDOR

* ### GET /Vendedor/{id}

Busca um vendedor pelo ID.

#### Parâmetros

	Necessário parâmetro ID.

#### Respostas

	200 - Sucesso!

	404 - Não encontrado. Motivos: "Não encontrou um vendedor com ID informado."

  
  

* ### PATCH /Vendedor/{id}

Descrição: Altera dados de um vendedor pelo ID.

#### Parâmetros

	Necessário parâmetro ID.

#### Respostas

	200 - Sucesso!

	404 - Não encontrado. Motivos: "ID não encontrou um vendedor com ID informado."

  
  

* ### DELETE /Vendedor/{id}

Descrição: Exclui um vendedor pelo ID.

#### Parâmetros

	Necessário parâmetro ID.

#### Respostas

	200 - Sucesso!

	404 - Não encontrado. Motivos: "Não encontrou um vendedor com ID informado."

  
  

* ### POST /Vendedor

Descrição: Cria um novo vendedor. 
Exemplo Request Body:

```
{
	"nome": "string",
	"cpf": "string",
	"email": "string",
	"telefone": "string"
}
```

#### Paramêtros

Não necessita parâmetros.

#### Respostas

	200 - Sucesso.