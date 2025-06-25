# 🍻 Controle de Bar

![](https://i.imgur.com/kioD02O.gif) <!-- (Substitua por um GIF ou imagem do seu projeto, se desejar) -->

## Introdução

- O projeto **Controle de Bar** tem como objetivo gerenciar **mesas**, **garçons**, **produtos**, **pedidos** e **contas** de forma simples e eficiente.
- Desenvolvido como um projeto **acadêmico** em **C# com .NET**, utilizando **aplicação console** com arquitetura em camadas.
- A aplicação permite registrar pedidos por mesa, associar garçons, controlar produtos vendidos e realizar o **fechamento de contas**, sendo ideal para fins didáticos e simulação de um ambiente de bar real.

---

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=html,css,bootstrap,js,cs,dotnet,visualstudio,git,github)](https://skillicons.dev)

---

## Funcionalidades

- **Mesas**
  - Cadastrar, editar, excluir, visualizar
  - Associar pedidos à mesa

- **Garçons**
  - Cadastrar, editar, excluir, visualizar

- **Produtos**
  - Cadastrar, editar, excluir, visualizar
  - Informar preço

- **Pedidos**
  - Registrar pedidos com quantidade, produto e valor
  - Associar pedidos à conta da mesa

- **Contas**
  - Visualizar pedidos abertos ou fechados
  - Fechar conta com totalização dos valores

- **Geral**
  - Visualizar faturamento do dia

---

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```

4. Em seguida, compile a solução utilizando o comando:
   
```
dotnet build --configuration Release
```

5. Para executar o projeto compilando em tempo real
   
```
dotnet run --project Calculadora.ConsoleApp
```

6. Para executar o arquivo compilado, navegue até a pasta `./Calculadora.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:
   
```
Calculdora.ConsoleApp.exe
```

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

- Visual Studio 2022 ou superior (opcional, para desenvolvimento).
