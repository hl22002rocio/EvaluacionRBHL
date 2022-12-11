using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RLCRUD.EntidadesDeNegocio
{
    public class Contacto
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Telefono es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Correo es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 60 caracteres")]
        public string Correo { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
