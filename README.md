# CalcAzureFuntion
Projeto de Teste em .net core v3 que foi hospedado no Azure Function v3.

## Parametros de Funcionamento
`/api/HttpTriggerCSharp?Operacao=multiplication` 

### Query parmetro
O parametro operacao pode ser o seguinte:

    1. sum;
    2. divided;
    3. subtraction;
    4. multiplication
### Body Request

O corpo da requisição deve ser respeitado o seguinte conteudo.

`{
	"numberA": 2,
	"numberB": 20
}`

Aonde deve ser sempre passado dois numeros com o o nome do parametro igual a numberA e numberB.


