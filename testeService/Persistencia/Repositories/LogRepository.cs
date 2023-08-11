using Dapper.Contrib.Extensions;

using MySqlConnector;

using testeService.Persistencia.Entidades;

namespace testeService.Persistencia.Repositories
{
    public class LogRepositoy
    {
        private readonly string connectionString;
        public LogRepositoy(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("NOTICIAS");
        }

        public void Inserir(LogEntity log)
        {
            using (var db = new MySqlConnection(connectionString))
            {
                db.Insert(log);
            }
        }

        public IEnumerable<LogEntity> Listar()
        {
            IEnumerable<LogEntity> lstLogEntity = new List<LogEntity>();

            using (var db = new MySqlConnection(connectionString))
            {
                lstLogEntity = db.GetAll<LogEntity>();
            }

            return lstLogEntity;
        }
    }
}
