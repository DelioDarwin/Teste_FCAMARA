using API_SistemaExterno1.Models;
using API_SistemaExterno2.Models;
using API_SistemaInterno.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabitMQUsuarioConsoleApplication;
using System.Text;
using System.Threading.Channels;


var factory = new ConnectionFactory
{
    HostName = "localhost"
};

API_SistemaExterno1.Models.Usuario usr1;
API_SistemaExterno2.Models.Usuario usr2;

var connection = factory.CreateConnection();
using var channel_SistemaExterno1 = connection.CreateModel();
using var channel_SistemaExterno2 = connection.CreateModel();

channel_SistemaExterno1.QueueDeclare("SistemaExterno1.Incluir", exclusive: false);
channel_SistemaExterno2.QueueDeclare("SistemaExterno2.Incluir", exclusive: false);

var consumer_SistemaExterno1 = new EventingBasicConsumer(channel_SistemaExterno1);
consumer_SistemaExterno1.Received += (model, eventArgs) =>
{
    usr1 = new API_SistemaExterno1.Models.Usuario();
    var metodo = eventArgs.RoutingKey;
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
   
    usr1 = JsonConvert.DeserializeObject<API_SistemaExterno1.Models.Usuario>(message);
    Console.WriteLine($"Usuario adicionado no Sistema Interno: {message}");

   
    if (usr1 != null)
    {
        if (metodo == "SistemaExterno1.Incluir")
        {
            //Grava no Sistema Externo 1
            usr1.IdUsuario = 0;
            bool ret = Service.SistemaExterno1_AddUsuario(usr1);

            if (ret)
            {
                Console.WriteLine($"Usuario INTEGRADO no Sistema Externo 1: {message}");
            }
            else
            {
                string sMsgErro = $"ERRO DE INTEGRAÇAO no Sistema Externo 1: {message}";
                Console.WriteLine(sMsgErro);

                LogErro log = new LogErro();
                log.TipoErro = "API Indisponível - Sistema Externo 1";
                log.Dados = message;
                Service.SistemaInterno_AddLogErro(log);

                Email.EnviarEmail_Ativacao("deliodarwin@gmail.com", sMsgErro);
            }
        }
    }


};
//read the message
channel_SistemaExterno1.BasicConsume(queue: "SistemaExterno1.Incluir", autoAck: true, consumer: consumer_SistemaExterno1);


var consumer_SistemaExterno2 = new EventingBasicConsumer(channel_SistemaExterno2);
consumer_SistemaExterno2.Received += (model, eventArgs) =>
{
    usr2 = new API_SistemaExterno2.Models.Usuario();
    var metodo = eventArgs.RoutingKey;
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    usr2 = JsonConvert.DeserializeObject<API_SistemaExterno2.Models.Usuario>(message);

    if (usr2 != null)
    {
        if (metodo == "SistemaExterno2.Incluir")
        {
            //Grava no Sistema Externo 1
            usr2.IdUsuario = 0;
            bool ret = Service.SistemaExterno2_AddUsuario(usr2);

            if (ret)
            {
                Console.WriteLine($"Usuario INTEGRADO no Sistema Externo 2: {message}");
            }
            else
            {
                string sMsgErro = $"ERRO DE INTEGRAÇAO no Sistema Externo 2: {message}";
                Console.WriteLine(sMsgErro);

                LogErro log = new LogErro();
                log.TipoErro = "API Indisponível - Sistema Externo 2";
                log.Dados = message;
                Service.SistemaInterno_AddLogErro(log);

                Email.EnviarEmail_Ativacao("deliodarwin@gmail.com", sMsgErro);
            }
        }
    }
};
//read the message
channel_SistemaExterno2.BasicConsume(queue: "SistemaExterno2.Incluir", autoAck: true, consumer: consumer_SistemaExterno2);


Console.ReadKey();