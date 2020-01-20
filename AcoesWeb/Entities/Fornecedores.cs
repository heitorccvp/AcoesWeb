using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class Fornecedores
    {
        public Fornecedores()
        {

        }
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(150, ErrorMessage = "Nome é obrigatório")]
		public string Nome { get; set; }


    }
}
