using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class Gondolas
    {
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "nome")]
		[StringLength(150, ErrorMessage = "Nome é obrigatório")]
		public string nome { get; set; }

		[Required]
		[Display(Name = "Farmacia")]
		public int Id_Farmacia { get; set; }
		[Display(Name = "Posicao")]
		public int? Id_Posicao { get; set; }
		[Display(Name = "Altura")]
		public decimal? Altura { get; set; }
		[Display(Name = "Largura")]
		public decimal? Largura { get; set; }

    }
}
