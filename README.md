# Planejamento de Compras com Integração com Chat GPT

## Descrição do Projeto
Este projeto é um sistema de planejamento de compras que utiliza o Chat GPT da OpenAI para tomar decisões informadas sobre as compras do próximo mês com base no histórico de compras dos anos anteriores. Ele consiste em três principais componentes: um Worker que processa o histórico de compras, uma API para operações CRUD e uma interface Web para visualização e configuração.

## Índice
1. [Instalação](#instalação)
2. [Fluxo do Processo](#fluxo-do-processo)
3. [Uso](#uso)
4. [Créditos](#créditos)

## Instalação
Para executar este projeto, você precisa atender aos seguintes requisitos de sistema:
- Node.js
- C# .NET 7
- SQL Server

Siga estas etapas para configurar o projeto:
1. Clone o repositório em sua máquina local.
2. Configure o banco de dados executando os scripts SQL localizados na pasta "scripts".
3. Crie uma chave de API no Chat GPT da OpenAI em [https://platform.openai.com/account/api-keys](https://platform.openai.com/account/api-keys).
4. Adicione a chave de API no endpoint POST: [https://localhost:7106/Configuracao](https://localhost:7106/Configuracao) ou utilize o Swagger para configuração em [https://localhost:7106/swagger/index.html](https://localhost:7106/swagger/index.html).
5. Use o endpoint [https://localhost:7106/Senha](https://localhost:7106/Senha) para gerar senhas com base nas palavras-chave fornecidas.

## Fluxo do Processo
Este processo de planejamento de compras envolve as seguintes etapas:

1. **Início do Processo:** Recuperação dos dados do histórico de compras dos anos anteriores a partir do banco de dados.
2. **Interação com o Modelo GPT:** Submissão dos dados históricos ao modelo GPT para gerar uma estimativa de quantos produtos devem ser comprados e em que quantidade. Isso envolve a comunicação com o modelo GPT, que fornece insights com base nas informações fornecidas.
3. **Armazenamento da Estimativa:** A estimativa gerada pelo modelo GPT é registrada no banco de dados para referência futura.
4. **Finalização do Processo:** O worker conclui a execução mensal e está pronto para repetir o processo no mês seguinte.

Este processo visa otimizar o planejamento de compras com base em dados e análises avançadas, permitindo uma visão mais precisa das necessidades de compras futuras.

## Uso
Para utilizar este sistema de planejamento de compras, siga as instruções de instalação acima. Após a configuração, você pode interagir com a API e a interface Web para visualizar informações e realizar configurações.

**Exemplo de Uso:**

1. Acesse a interface Web para visualizar os dados e realizar configurações.
2. O Worker executará automaticamente uma vez por mês para processar o histórico de compras dos anos anteriores e gerar estimativas de compras futuras com base na interação com o Chat GPT.
3. As estimativas de compras são armazenadas no banco de dados para referência futura.

## Créditos
- Documentação do Chat GPT da OpenAI: [https://platform.openai.com/docs/introduction](https://platform.openai.com/docs/introduction)

Este projeto combina análise de dados históricos, interação com inteligência artificial e armazenamento de estimativas para otimizar o processo de planejamento de compras.