using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class GondolasView
    {
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Required]
		[Display(Name = "Farmacia")]
		public string Farmacia { get; set; }

		[Display(Name = "Posicao")]
		public string Posicao { get; set; }

		[Display(Name = "Altura")]
		public decimal? Altura { get; set; }
		[Display(Name = "Largura")]
		public decimal? Largura { get; set; }


    }
}
