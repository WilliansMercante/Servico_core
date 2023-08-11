using Dapper.Contrib.Extensions;

using MySqlConnector;

namespace testeService.Persistencia.Entidades
{
    [Table("tb_log")]
    public class LogEntity
    {
        public int id_log { get; set; }
        public string log { get; set; }
        public DateTime dt_cadastro { get; set; }
    }
}
