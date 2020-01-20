using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Aprovadores
{
    public class AddModel : PageModel
    {
		IAprovadoresRepository _aprovadorRepository;

		public AddModel(IAprovadoresRepository aprovadorRepository)
		{
			_aprovadorRepository = aprovadorRepository;
		}

		[BindProperty]
		public Entities.Aprovadores aprovador { get; set; }

		[TempData]
		public string Message { get; set; }

		public IActionResult OnGet()
		{
			return Page();
		}

		public IActionResult OnPost()
		{

			if (ModelState.IsValid)
			{
				var count = _aprovadorRepository.Add(aprovador);

				if (count > 0)
				{
					Message = "Novo aprovador incluído com sucesso !";
					return Redirect("/Aprovadores/Index");
				}


			}

			return Page();
		}
	}
}