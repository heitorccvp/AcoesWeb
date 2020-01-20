using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class AcoesMkt
    {
		[Key]
		[Display(Name ="Id")]
        public int Id { get; set; }

		[Required]
		[Display(Name = "Nome")]
		[StringLength(150, ErrorMessage ="Max 150")]
		public string Nome { get; set; }
		
		[Display(Name = "Associado")]
		public int Id_Associado { get; set; }

		[Display(Name = "Farmacia")]
		public int Id_Farmacia { get; set; }

		[Display(Name = "Gondola")]
		public int Id_Gondola { get; set; }

		[Display(Name = "Partes")]
		public int Id_Partes { get; set; }

		[Display(Name = "Fornecedor")]
		public int? Id_Fornecedor { get; set; }

		[Display(Name = "Status")]
		public int? Id_Status { get; set; }

		[Display(Name = "Aprovador")]
		public int? Id_Aprovador { get; set; }

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
