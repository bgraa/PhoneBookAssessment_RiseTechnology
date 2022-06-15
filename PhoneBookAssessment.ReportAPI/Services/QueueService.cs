using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PhoneBookAssessment.ReportAPI.Models;
using PhoneBookAssessment.ReportAPI.Services.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PhoneBookAssessment.ReportAPI.Services
{
    public static class QueueService
	{
        public static IApplicationBuilder UseQueueService(this IApplicationBuilder app)
        {
            var settings = app.ApplicationServices.GetRequiredService<IOptions<Settings>>().Value;

            var rabbitMqConnection = settings.RabbitMqConnection;

            var createReportQueue = "create-report-queue";
            var reportCreateExchange = "report_create_exchange";

            ConnectionFactory connectionFactory = new()
            {
                Uri = new Uri(rabbitMqConnection)
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.ExchangeDeclare(reportCreateExchange, "direct");

            channel.QueueDeclare(createReportQueue, false, false, false);
            channel.QueueBind(createReportQueue, reportCreateExchange, createReportQueue);

            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var reportService = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IReportService>();
                var incomingModel = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                Console.WriteLine("Data received");
                Console.WriteLine($"Received Id: {incomingModel}");
                reportService.GenerateReportResponse(Guid.Parse(incomingModel));
            };

            channel.BasicConsume(createReportQueue, true, consumerEvent);

            return app;
        }
    }
}

