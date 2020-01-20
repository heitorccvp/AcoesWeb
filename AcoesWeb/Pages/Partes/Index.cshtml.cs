using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Partes
{
    public class IndexModel : PageModel
    {
		IPartesRepository _parteRepository;
		public IndexModel(IPartesRepository parteRepository)
		{
			_parteRepository = parteRepository;
		}

		[BindProperty]
		public List<Entities.PartesView> listaPartes { get; set; }

		[BindProperty]
		public Entities.Partes parte { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaPartes = _parteRepository.GetPartes();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _parteRepository.Delete(id);

				if (count > 0)
				{
					Message = "Parte deletada com sucesso!";
					return RedirectToPage("/Partes/Index");
				}
			}

			return Page();
		}
	}
}