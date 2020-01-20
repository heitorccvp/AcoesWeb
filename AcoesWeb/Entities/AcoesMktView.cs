using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
	public class AcoesMktView
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required]
		[Display(Name = "acaoNome")]
		public string acaoNome { get; set; }

		[Display(Name = "associoadosNome")]
		public string associoadosNome { get; set; }

		[Display(Name = "farmaciasNome")]
		public string farmaciasNome { get; set; }
		
		[Display(Name = "posicaoNome")]
		public string posicaoNome { get; set; }
		
		[Display(Name = "gondolaAltura")]
		public int gondolaAltura { get; set; }

		[Display(Name = "gondolaLargura")]
		public int gondolaLargura { get; set; }

		[Display(Name = "partesAltura")]
		public int partesAltura { get; set; }

		[Display(Name = "partesLargura")]
		public int partesLargura { get; set; }

		[Display(Name = "fornecedoresNome")]
		public string fornecedoresNome { get; set; }

		[Display(Name = "nomeStatus")]
		public string nomeStatus { get; set; }

		[Display(Name = "nomeAprovador")]
		public string nomeAprovador { get; set; }

		[Display(Name = "Valor")]
		public decimal Valor { get; set; }

		[Display(Name = "DataVenda")]
		public DateTime? DataVenda { get; set; }
		[Display(Name = "DataAgendamento")]
		public DateTime? DataAgendamento { get; set; }
		[Display(Name = "DataPagamento")]
		public DateTime? DataPagamento { get; set; }
	}
}
