using OpenQA.Selenium.DevTools;

using testeService.Persistencia;
using testeService.Persistencia.Entidades;
using testeService.Persistencia.Repositories;
using testeService.testeService;

namespace testeService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public AcessoPaginas acessoPaginas = new AcessoPaginas();
        private readonly NoticiasRepositoy _noticias;
        private readonly LogRepositoy _log;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _noticias = new NoticiasRepositoy(configuration);
            _log = new LogRepositoy(configuration);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Serviço Iniciando " + DateTime.Now);
            File.AppendAllText("c:\\temp\\logNoticias.txt", Environment.NewLine + $"Iniciando: {DateTime.Now}");
            acessoPaginas.Start();

            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    var noticiaUol = acessoPaginas.BuscaNoticiaUol();
                    _noticias.Inserir(new NoticiasEntity { dt_cadastro = DateTime.Now, id_canal_noticia = Convert.ToInt32(CanalNoticiaEnum.UOL),noticia = noticiaUol });
                    File.AppendAllText("c:\\temp\\Noticias.txt", Environment.NewLine + $"Noticia UOL: {noticiaUol} {DateTime.Now}");
                }
                catch (Exception e)
                {
                    _log.Inserir(new LogEntity { dt_cadastro = DateTime.Now, log = "UOL: " + e.Message });
                    File.AppendAllText("c:\\temp\\Noticias.txt", Environment.NewLine + $"Noticia UOL: * Não foi possível obter a informação * {DateTime.Now}");
                    File.AppendAllText("c:\\temp\\logNoticias.txt", Environment.NewLine + $"Erro: {e.Message} {DateTime.Now}");
                }

                try
                {
                    var noticiaTerra = acessoPaginas.BuscaNoticiaTerra();
                    _noticias.Inserir(new NoticiasEntity { dt_cadastro = DateTime.Now, id_canal_noticia = Convert.ToInt32(CanalNoticiaEnum.TERRA), noticia = noticiaTerra });
                    File.AppendAllText("c:\\temp\\Noticias.txt", Environment.NewLine + $"Noticia Terra: {noticiaTerra} {DateTime.Now}");
                }
                catch (Exception e)
                {
                    _log.Inserir(new LogEntity { dt_cadastro = DateTime.Now, log = "Terra: " + e.Message });
                    File.AppendAllText("c:\\temp\\Noticias.txt", Environment.NewLine + $"Noticia Terra: * Não foi possível obter a informação * {DateTime.Now}");
                    File.AppendAllText("c:\\temp\\logNoticias.txt", Environment.NewLine + $"Erro: {e.Message} {DateTime.Now}");
                }

                File.AppendAllText("c:\\temp\\logNoticias.txt", Environment.NewLine + $"Rodando: {DateTime.Now}");
                await Task.Delay(300000, stoppingToken);
            }

            _logger.LogInformation("Serviço Finalizando " + DateTime.Now);
            File.AppendAllText("c:\\temp\\logTeste.txt", Environment.NewLine + $"Finalizando: {DateTime.Now}");
        }
    }
}