using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cad_Pet.Models
{
    public class DonoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do Dono:")]
        [Display(Name = "Nome do Dono:")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="Insira um email válido: ")]
        [Display(Name ="Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe um telefone:")]
        [Display(Name ="Telefone: ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="Insira a data de cadastro:")]
        [Display(Name ="Data de Cadastro:")]
        public DateTime Data_Cad { get; set; }

        [Display(Name ="Descrição do Endereço:")]
        public string Descr_End { get; set; }

        public virtual ICollection<PetModel> PetModel { get; set; }
    }
}