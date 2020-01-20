﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcoesWeb.Entities
{
    public class Aprovadores
    {
        public Aprovadores()
        {
        }

		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome")]
		public string Nome { get; set; }

    }
}
