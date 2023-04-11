# Alguns comentários:

## Tive que alterar o appsettings devido ao localDB não ser compatível com o Mac M1. Utilizei um container do docker para rodar a base de dados.
## Por algum motivo, nos meus testes utilizando o Swagger, as listagens estavam voltando dados equivocados. Entretanto ao testar no Postman, estava tudo certo. Acredito que seja devido algum cache do navegador, mas somente para deixar avisado.

# Prova BonifiQ Backend
Ol�!
Essa prova foi criada para testar suas habilidades com .NET e C# em geral. 
Por favor, siga atentamente as instru��es antes de come�ar, ok?

N�o conseguiu fazer alguma etapa? Blza, entrega o que voc� conseguir ;)

## Para come�ar
O primeiro passo � criar uma **c�pia** deste reposit�rio. Por favor, perceba que fazer uma c�pia � diferente de realizar um clone ou fork. Siga os passos abaixo para fazer a c�pia:

- Crie um novo reposit�rio em sua conta do GitHub. D� o nome de ***prova-bonifiq***
- Abra seu client do git e siga os comandos:
```
git clone --bare https://github.com/bonifiq/prova-backend.git
```
Esse comando gera uma c�pia do reposit�rio da prova em seu computador. Agora, continue com os comandos
```
cd prova-backend.git
git push --mirror https://github.com/SEUSUARIO/prova-bonifiq.git
```
Note que voc� precisa alterar o SEUUSUARIO pelo seu username do GitHub, utilizado para criar o reposit�rio no primeiro passo.
Voc� pode apagar o diret�rio ```prova-backend.git``` que foi criado em seu computador.

Tudo certo: voc� possui um reposit�rio em seu nome com tudo que precisa para come�ar responder sua prova. Agora sim, fa�a o clone (git clone) em sua m�quina e voc� est� pronto para trabalhar.
```
git clone https://github.com/SEUSUARIO/prova-bonifiq.git
```

> Lembre-se: N�O gere um Fork do reposit�rio. Siga os passos acima para copiar o reposit�rio para sua conta.

## Conhecendo o projeto
> N�s recomendamos que voc� utilize o Visual Studio 2022 (pode ser a vers�o community). Voc� tamb�m precisa do .NET 6 instalado, ok?
Ah, n�o esquece de instalar o pacote de desenvolvimento para o ASP NET durante a instala��o do Visual Studio.

Ao abrir o projeto no Visual Studio, voc� pode notar que se trata de um projeto Web API do ASP NET.  Voc� pode se orientar pela pasta ```Controllers``. 
Dentro dela, cada Controller representa uma etapa da prova.  Logo abaixo vamos falar mais sobre essas etapas e como resolv�-las.

Antes de rodar o projeto, voc� precisa rodar as migrations. Para isso, primeiro instale o [EF Tools](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install#get-the-entity-framework-core-tools):
```
dotnet tool install --global dotnet-ef
```
Agora, pode rodar as migrations de fato:
```
dotnet ef update database
``` 

Pronto, o projeto j� criou as tabelas e alguns registros no seu localDB. 


Rode o projeto e, se tudo deu certo, voc� dever� ver uma p�gina do Swagger com as APIs que utilizaremos no teste.

D� uma passeada pelo projeto e note que ele tem alguns probleminhas de arquitetura. Vamos resolver isso j� j�


## Seu trabalho
Certo, tudo configurado e rodando. Agora vamos explicar o que voc� precisa fazer.

### Parte1Controller
Esse controller foi criado para gerar uma API que sempre retorna um n�mero aleat�rio. 
Voc� pode v�-lo funcionando ao rodar o projeto e na p�gina do Swagger, clique em Parte 1 > Try it Out > Execute.

Esse c�digo, no entanto, tem algum problema: ele sempre retorna o mesmo valor.
Seu trabalho, portanto, � corrigir esse comportamente: cada vez que a chamada � realizada um n�mero diferente dever� ser retornado.

### Parte2Controller
Essa API deveria retornar os produtos cadastrados de forma paginada. O usu�rio informa a p�gina (page) desejada e o sistema retorna os 10 itens da mesma.
O problema � que n�o importa qual n�mero de p�gina � utilizado: os resultados est�o vindo sempre os mesmos. E n�o apenas os 10.

Voc� precisa portanto:
1. Corrigir o bug de pagina��o. Ao passar page=1, deveria ser retornado os 10 (0 a 9) primeiros itens do banco. Ao passar page=2 deveria ser retornado os itens subsequentes (10 a 19), etc
2. Note que na Action do Controller, chamamos o ```ProductService```. Fazemos isso, instanciando o mesmo (```var productService = new ProductService(_ctx);```). Essa � uma pr�tica ruim. Altere o c�digo para que utilize Inje��o de Depend�ncia.
3. Agora, explore os arquivos ```/Models/CustomerList``` e ```/Models/ProductList```. Eles s�o bem parecidos. De fato, deve haver uma forma melhor de criar esses objetos, com menos repeti��o de c�digo. Fa�a essa altera��o.
4. Da mesma forma, como voc� melhoraria o ```CustomerService```e o ```ProductService``` para evitar repeti��o de c�digo?

### Parte3Controller
Essa API cria o pagamento de uma compra (```PlaceOrder```). Verifique o m�todo ```PayOrder``` da classe ```OrderService```.
Voc� deve ter percebido que existem diversas formas de pagamento (Pix, cart�o de cr�dito, paypal), certo?
Essa classe, no entanto, � problem�tica. Imagine que ter�amos que incluir um novo m�todo de pagamento, seria mais um ```if```na estrutura.

Voc� precisa:
1. Fa�a uma altera��o na arquitetura para que fique mais bem estruturado e preparado para o futuro.
Tenha certeza que o princ�pio Open-Closed ser� respeitado.

### Parte4Controller
Essa API faz uma valida��o de neg�cio e retorna se o consumidor pode realizar uma compra.
Verifique o arquivo ```CanPurchase``` da classe ```CustomerService``` e note que ele aplica diversas regras de neg�cio.

Seu trabalho aqui ser�:
1. Crie testes unit�rios para este m�todo. Tente obter o m�ximo de cobertura poss�vel. Se precisar, pode rearquitetar o c�digo para facilitar nos testes.

Voc� pode utilizar qualquer framework de testes que desejar. 

## Como entregar
Oba! Terminou tudinho? Agora fa�a o seguinte:
1. Fa�a ```push``` para seu reposit�rio (sim, aquele que voc� criou l� em cima. Nada de fork).
2. Forne�a acesso ao reposit�rio no GitHub para o usu�rio ```sandercamargo```
2. Preencha o formul�rio abaixo:
[https://forms.gle/mHipmDJJnij7FRHE7](https://forms.gle/mHipmDJJnij7FRHE7)

A gente te responde em breve, ok?
