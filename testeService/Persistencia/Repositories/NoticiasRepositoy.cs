using Dapper.Contrib.Extensions;

using MySqlConnector;

using testeService.Persistencia.Entidades;

namespace testeService.Persistencia.Repositories
{
    public class NoticiasRepositoy
    {
        private readonly string connectionString;
        public NoticiasRepositoy(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("NOTICIAS");
        }

        public void Inserir(NoticiasEntity noticia)
        {
            using (var db = new MySqlConnection(connectionString))
            {
                db.Insert(noticia);
            }
        }

        public IEnumerable<NoticiasEntity> Listar()
        {
            IEnumerable<NoticiasEntity> lstNoticiasEntity = new List<NoticiasEntity>();

            using (var db = new MySqlConnection(connectionString))
            {
                lstNoticiasEntity = db.GetAll<NoticiasEntity>();
            }

            return lstNoticiasEntity;
        }
    }
}
