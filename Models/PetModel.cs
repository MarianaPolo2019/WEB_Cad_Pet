using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cad_Pet.Models
{
    public class PetModel
    {
        [Key]
        [Display(Name ="Id:")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do pet:")]
        [Display(Name ="Nome do Pet:")]
        public string Nome_Pet { get; set; }
        [Required(ErrorMessage ="Digite o tipo do pet:(Gato, cão, etc)")]
        [Display(Name ="Tipo de Pet: ")]
        public string Tipo_Pet { get; set; }
        [Display(Name = "Sexo do Pet: ")]
        public string Sexo { get; set; }
        [Display(Name = "Raça:")]
        public string Raca { get; set; }
        [Required(ErrorMessage ="Digite o porte do Pet!")]
        [Display(Name = "Porte:")]
        public string Porte { get; set; }
        public int? DonoId { get; set; }
        public virtual DonoModel DonoModel { get; set; }
    }
}