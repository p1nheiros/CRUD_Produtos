# CRUD de Produtos

Este projeto foi desenvolvido com **ASP.NET Core** e tem como objetivo gerenciar produtos de forma simples e eficiente. Ele inclui uma **API RESTful** para operações CRUD e uma aplicação **MVC** para consumir essa API de forma intuitiva.

---

## Tecnologias Utilizadas

- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **MVC (Model-View-Controller)**

---

### 🌐 API RESTful
A API permite:

Criação de produtos
Listagem dos produtos
Detalhes de um produto específico
Atualização de um produto existente
Remoção de um produto

### 💻 Aplicação MVC
A interface permite:

Visualizar a listagem de produtos
Adicionar novos produtos
Editar produtos já cadastrados
Excluir produtos

---

### Pré-requisitos
- **Visual Studio**
- **SQL Server**

### Rodando a aplicação
1. **Clone o repositório**
   ```sh
   git clone https://github.com/p1nheiros/CRUD_Produtos.git
   ```
2. **Acesse a pasta do projeto da API para configurar o banco de dados**
   ```sh
   cd CRUD_Produto\CrudProdutos
   -> No arquivo 'appsettings.json'
   -> Linha "DefaultConnection": "Server=nome_servidor;Database=nome_database;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
   Substitua o 'nome_servidor' e o 'nome_database' por um servidor e banco de dados existente no seu SQLServer (a conexão deve ser realizada por autenticação do windows)
   ```
3. **Criação da tabela no banco de dados**
   ```sh
   Crie a tabela Produto para executar a API corretamente.
   
   CREATE TABLE Produto (
   	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
       Titulo VARCHAR(MAX),
       Descricao VARCHAR(MAX),
       Preco DECIMAL(16,2),
       Estoque INT,
       Fotos VARCHAR(MAX)
   );
   ```
4. **Execute a API**
   ```sh
   Buildar o projeto CrudProdutos
   Execute o projeto.
   
   cd CRUD_Produtos\CrudProdutos\bin\Debug\net8.0
   -> Executar o arquivo CrudProdutos
   ```
5. **Acesse a pasta do projeto MVC**
   ```sh
   cd CRUD_Produtos\CrudProdutosMVC
   Buildar o projeto CrudProdutosMVC
   Execute o projeto na máquina local.
   ```
   
