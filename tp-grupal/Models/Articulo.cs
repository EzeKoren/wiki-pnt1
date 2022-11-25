using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace tp_grupal.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string categoria { get; set; }
        [Required]
        public string contenido { get; set; }
        [Required]
        public string imagen { get; set; }
    }
}
