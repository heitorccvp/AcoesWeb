using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
	public class Saldo
	{

		public int Id { get; set; }

		[Display(Name = "acaoNome")]
		public string acaoNome { get; set; }

		[Display(Name = "Associoados")]
		public string associoadosNome { get; set; }

		[Display(Name = "Farmacia")]
		public string farmaciasNome { get; set; }

		[Display(Name = "Fornecedores")]
		public string fornecedoresNome { get; set; }

		[Display(Name = "Valor")]
		public decimal valor { get; set; }

		[Display(Name = "Status")]
		public string nomeStatus { get; set; }

		[Display(Name = "Data Pagamento")]
		public DateTime? dataPagamento  { get; set; }

	}
}
