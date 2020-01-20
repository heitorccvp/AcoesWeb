using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class PartesView
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Display(Name = "Gondola")]
		public string Gondola { get; set; }

		[Display(Name = "Posicao")]
		public string Posicao { get; set; }

		[Display(Name = "Altura")]
		public decimal? Altura { get; set; }

		[Display(Name = "Largura")]
		public decimal? Largura { get; set; }


    }
}
