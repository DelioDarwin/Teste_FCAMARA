# Teste_FCAMARA
Cadastro de Pessoas com Integrações Externas

# Tecnologias Utilizadas
 - APIs Rest .Net Core 6
 - Entity Framework Core
 - RabbitMQ
 - Container Compose
 - Swagger
 - SQL Server Express
 - Integração com o SendGrid (Envio de Email)

# Aplicações da Solução
- Frontend ASP.Net (listagem dos dados das 3 aplicações)
- Back-end CRUD API .Net Core do Sistema Interno (que integra os dados da pessoa após POST)
- Back-end CRUD API .Net Core do Sistema Externo 1
- Back-end CRUD API .Net Core do Sistema Externo 2
- Back-end Consumer RabbitMQ das mensagens enviadas pela API do Sistema Interno (após consumir as mensagens - realiza as requisições nas APIS dos sistemas externos para integrar os dados)
  
 # Instalação
 - Instalar o Container e o RabbitMQ - rodando na porta default
 - Executar os comandos para criar os 3 banco de dados SQL Server das aplicações

   Docker Compose
   
    -docker-compose up --build

  SQL Server (executar os dois comandos nos 3 projetos API .NET Core)
  
    - Add-Migration Inicial -Context DbContextClass
    - Update-Database -Context DbContextClass


# Escopo Recebido
Cenário 1: Receber Dados Cadastrais e Salvar Internamente
Dado que um usuário fornece seus dados cadastrais através do endpoint de cadastro,
Quando o sistema recebe esses dados,
Então os dados devem ser salvos internamente para referências futuras
Cenário 2: Integração com Serviço Externo para Cadastro no Sistema Parceiro
Dado que os dados cadastrais de um usuário foram salvos internamente,
Quando o sistema se integra com o serviço externo para o cadastro no sistema parceiro,
Então os dados salvos internamente devem ser enviados para o sistema parceiro,
E o sistema deve receber uma confirmação de que o cadastro foi realizado com sucesso.
Cenário 3: Integração com Outro Serviço Externo para Cadastro no Sistema Parceiro
Dado que os dados cadastrais foram salvos internamente após a integração com o primeiro serviço externo, Quando o sistema se integra com outro serviço externo para o mesmo objetivo,
Então os dados previamente salvos devem ser enviados para o segundo sistema parceiro,
E o sistema deve receber uma confirmação de que o cadastro foi realizado com sucesso no segundo sistema parceiro.
Cenário 4: Tratamento de Falhas na Integração
Dado que o sistema está integrado com os serviços externos,
Quando ocorrer uma falha durante a integração com qualquer um dos sistemas parceiros,
Então o sistema deve registrar a falha para fins de monitoramento e análise,
E deve notificar os administradores sobre a falha para tomada de ação corretiva.
Cenário 5: Verificação de Dados no Sistema Parceiro
Dado que o cadastro foi realizado com sucesso nos sistemas parceiros,
Quando necessário
Então o sistema deve permitir a verificação dos dados no sistema parceiro para garantir consistência entre os sistemas.
