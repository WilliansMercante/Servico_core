using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testeService.Persistencia.Entidades
{
    [Table("tb_canal_noticia")]
    public class CanalNoticiaEntity
    {
        [Key]
        public int id_canal_noticia { get; set; }
        public string nm_canal_noticia { get; set; }
        public DateTime dt_cadastro { get; set; }
    }
}
