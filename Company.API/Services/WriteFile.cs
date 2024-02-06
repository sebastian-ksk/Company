using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Company.API.Services
{
    public class WriteFile : IHostedService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _fileName;
        private Timer _timer;

        public WriteFile(IWebHostEnvironment env)
        {
            _env = env;
            // Establece el nombre del archivo con la fecha actual para agrupar los logs por día.
            _fileName = $"log-{DateTime.Now:yyyy-MM-dd}.txt";
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Inicializa el timer para ejecutar DoWork cada 5 segundos después del inicio inmediato.
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1)));

            // Registra un mensaje al iniciar la aplicación.
            Write("WebApi started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Registra un mensaje al detener la aplicación.
            Write("WebApi Finalizado");

            // Detiene y libera el timer.
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            // Escribe un mensaje de log durante la ejecución regular.
            Write("WebApi en ejecución");
        }

        private void Write(string message)
        {
            try
            {
                var path = Path.Combine(_env.ContentRootPath, _fileName);
                using (var writer = new StreamWriter(path, append: true))
                {
                    var messageTime = $"{DateTime.Now} - {message}";
                    writer.WriteLine(messageTime);
                }
            }
            catch (Exception ex)
            {
                // En un escenario real, considera registrar estas excepciones en un sistema de log centralizado.
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }
    }
}
