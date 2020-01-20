using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class FarmaciasView
    {
		public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
		public string associado { get; set; }

	}
}
