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
        [Required(ErrorMessage = "Titulo es un campo obligatorio")]
        [StringLength(50, ErrorMessage = "Titulo debe tener menos de 50 caracteres")]
        [MinLength(4, ErrorMessage = "Titulo debe tenes mas de 4 caracteres")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "Categoria es un campo obligatorio")]
        [StringLength(50, ErrorMessage = "Categoria debe tener menos de 50 caracteres")]
        [MinLength(4, ErrorMessage = "Categoria debe tenes mas de 4 caracteres")]
        public string categoria { get; set; }
        [Required(ErrorMessage = "Contenido es un campo obligatorio")]
        [StringLength(1000, ErrorMessage = "Contenido debe tener menos de 1000 caracteres")]
        [MinLength(20, ErrorMessage = "Contenido debe tenes mas de 20 caracteres")]
        public string contenido { get; set; }
        [Required(ErrorMessage = "Imagen es un campo obligatorio")]
        [Url(ErrorMessage = "Imagen debe ser una URL valida")]
        public string imagen { get; set; }
    }
}
