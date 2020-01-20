using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class Farmacias
    {
        public Farmacias()
        {

        }
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }
        public int Id_Associado { get; set; }

		[Required]
		[Display(Name = "Nome")]
		[StringLength(150, ErrorMessage = "Nome é obrigatório")]
		public string Nome { get; set; }
        public string Local { get; set; }



    }
}
