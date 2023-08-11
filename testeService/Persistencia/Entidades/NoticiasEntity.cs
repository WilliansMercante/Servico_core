using Dapper.Contrib.Extensions;

using MySqlConnector;

namespace testeService.Persistencia.Entidades
{
    [Table("tb_noticia")]
    public class NoticiasEntity
    {
        [Key]
        public int id_noticia { get; set; }
        public string noticia { get; set; }
        public int id_canal_noticia { get; set; }
        public DateTime dt_cadastro { get; set; }
    }
}
