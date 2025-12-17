# 🎬 Sistema de Locadora – C# (Programação III)

Este repositório contém o **projeto final da disciplina de Programação III**, desenvolvido em **C#**, com foco em **aplicações desktop com banco de dados**, utilizando **arquitetura MVC**, **DAO** e conceitos de **Programação Orientada a Objetos**.

O sistema simula o funcionamento de uma **locadora**, permitindo o gerenciamento completo de clientes, filmes, locações, usuários e relatórios, atendendo a todos os requisitos propostos na disciplina.

---

## 🎥 Vídeo de Funcionamento

Assista ao vídeo demonstrativo do sistema no YouTube:  

<p align="center">
  <a href="https://youtu.be/iJvVmZemwnk">
    <img src="https://img.youtube.com/vi/iJvVmZemwnk/0.jpg" alt="Sistema de Locadora - Demonstração" width="480"/>
  </a>
</p>

---

## 🛠 Tecnologias Utilizadas

- **C# (.NET / Windows Forms)**
- **Banco de Dados MySQL** (gerenciado via **XAMPP**)
- **Arquitetura MVC**
- **DAO (Data Access Object)**
- **MDI (Multiple Document Interface)**
- **Programação Orientada a Objetos (POO)**
- **Bibliotecas para geração de PDF e gráficos**

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=flat&logo=mysql&logoColor=white)
![XAMPP](https://img.shields.io/badge/XAMPP-FB7A24?style=flat&logo=xampp&logoColor=white)

---

## 📌 Funcionalidades Implementadas

O sistema atende integralmente aos requisitos da disciplina:

### 📂 Banco de Dados
- Banco de dados relacional com **mínimo de 5 tabelas relacionadas**
- Relacionamentos entre entidades (clientes, filmes, locações, usuários, etc.)

### 🔁 CRUD Completo
- Cadastro, leitura, atualização e exclusão de dados
- Interface gráfica para todas as operações

### 🧱 Arquitetura
- Separação em **Model**, **DAO**, **Controller** e **View**
- Código organizado, reutilizável e de fácil manutenção

### 💾 Backup e Restauração
- Recurso para **backup do banco de dados**
- Restauração realizada diretamente pela aplicação

### 📄 Importação de CSV
- Upload de arquivo **.csv** para povoar tabelas do banco de dados

### 📊 Relatórios e Gráficos
- Apresentação de **pelo menos dois gráficos** com dados obtidos do banco
- Visualização estatística das informações da locadora

### 🧾 Geração de PDF
- Exportação de **relatórios em PDF** contendo dados de cada tabela

### 📋 DataTable
- Utilização de **DataTable** em pelo menos um formulário CRUD
- Facilita visualização, ordenação e filtragem dos dados

### 🔐 Sistema de Login
- Autenticação de usuários
- **Níveis de acesso distintos**:
  - Administrador
  - Usuário comum

### 📝 Log de Ações
- Registro automático de ações como:
  - Inserções
  - Atualizações
  - Exclusões
  - Acessos ao sistema
- Logs contendo **data/hora** e **usuário responsável**

### 🪟 Interface MDI
- Aplicação estruturada utilizando **MDI (Multiple Document Interface)**

---

## ⚙️ Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/lauratrigo/Projeto_Locadora.git
```
2. Abra o arquivo .sln no Visual Studio.
3. Configure a string de conexão com o banco de dados.
4. Execute o script SQL disponível na pasta Database/ para criar o banco de dados.
5. Compile e execute a aplicação.
6. Faça login com um usuário cadastrado (administrador ou usuário comum).

---

## 🤝 Agradecimentos

Projeto desenvolvido durante o curso de Engenharia da Computação, como parte das atividades acadêmicas da disciplina de Programação III.

---

## 📜 Licença

Este repositório está licenciado sob MIT License. Consulte o arquivo LICENSE para mais informações.

