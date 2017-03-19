[![JRWIKI](http://jrwiki.pe.hu/wp-content/uploads/2016/05/logo.png)] (http://jrwiki.pe.hu)

# Sistema Venda de Pizza
- Sistema de uma Pizzaria em C#, trabalho do curso de ADS

Descrição
---------

Foi desenvolvido uma aplicação usando o Visual Studio a linguagem utilizada foi o C# padrão estruturado o banco de dados utilizado foi o Access com base no levantamento realizado pelo analista de sistemas, foi possível identificar que a pizzaria necessitará dos seguintes controles:

Controle de Cliente:
-------------------
Neste controle é necessário o nome do cliente, telefone de contato, endereço, ponto de referência e data de nascimento. Com base nestes dados, no momento do pedido, o atendente realizará uma pesquisa pelo número do telefone do cliente, caso esteja cadastrado, os seus dados deverão ser exibidos, caso contrário, deverá cadastrá-lo. Este cenário leva a uma situação onde, por exemplo, em uma residência, cujo telefone fixo já esteja cadastrado para um dos moradores, não poderá ser cadastrado para outro morador da mesma residência, porém, caso necessário poderá mudar o nome do morador.

Controle de Entregadores:
-------------------------
Neste controle são necessários os seguintes dados: nome do entregador, CPF, RG e celular.

Controle do Produto:
--------------------
Neste caso os produtos são as pizzas a serem vendidas, sendo necessária a inclusão dos dados, nome do produto, descrição, tamanho e custo.

Controle de Pedido:
-------------------
Para gerenciar os pedidos realizados pelo cliente, o atendente deverá informar no registro do pedido: nome do cliente, nome do produto, quantidade, tamanho etc. O pedido pode conter várias pizzas, porém, cada pizza apenas um sabor.
