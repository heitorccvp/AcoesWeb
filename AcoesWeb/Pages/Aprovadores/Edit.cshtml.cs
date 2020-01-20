using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Aprovadores
{
    public class EditModel : PageModel
    {

		IAprovadoresRepository _aprovadoresRepository;
		public EditModel(IAprovadoresRepository aprovadoresRepository)
		{
			_aprovadoresRepository = aprovadoresRepository;
		}

		[BindProperty]
		public Entities.Aprovadores aprovador { get; set; }

		public void OnGet(int id)
		{
			aprovador = _aprovadoresRepository.Get(id);
		}

		public IActionResult OnPost()
		{
			var dados = aprovador;

			if (ModelState.IsValid)
			{
				var count = _aprovadoresRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Aprovadores/Index");
				}
			}
			return Page();
		}
	}
}