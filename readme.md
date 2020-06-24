# CashBack API

## endpoints

 - Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF, e- mail e senha; 
 - Rota para validar um login de um revendedor(a); 
 - Rota para cadastrar uma nova compra exigindo no mínimo código, valor, data e CPF do revendedor(a). Todos os cadastros são salvos com o status “Em validação” exceto quando o CPF do revendedor(a) for 153.509.460-56, neste caso o status é salvo como “Aprovado”; 
 - Rota para listar as compras cadastradas retornando código, valor, data, % de cashback aplicado para esta compra, valor de cashback para esta compra e status; 
 - Rota para exibir o acumulado de cashback até o momento, essa rota irá consumir essa informação de uma API externa:
    - API externa GET: https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com/v1/cashback?cpf=12312312323
    - headers { token: 'ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm' } 

## premissas do caso de uso: 
- Os critérios de bonificação são:
    - Para até 1.000 reais em compras, o revendedor(a) receberá 10% de cashback do valor vendido no período de um ms;
    - Entre 1.000 e 1.500 reais em compras, o revendedor(a) receberá 15% de cashback do valor vendido no período de um mês;
    - Acima de 1.500 reais em compras, o revendedor(a) receberá 20% de cashback do valor vendido no período de um mês.


## Starting user
Cpf 153.509.460-56 seeded in database
- ``` user: 15350946056 ```
- ``` password: 12345 ```
