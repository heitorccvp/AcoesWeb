using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AcoesWeb.Pages.Gondolas
{
	public class IndexModel : PageModel
    {
		IGondolasRepository _gondolaRepository;
		public IndexModel(IGondolasRepository gondolaRepository)
		{
			_gondolaRepository = gondolaRepository;
		}

		[BindProperty]
		public List<Entities.GondolasView> listaGondolas { get; set; }

		[BindProperty]
		public Entities.Gondolas gondola { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaGondolas = _gondolaRepository.GetGondolas();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _gondolaRepository.Delete(id);

				if (count > 0)
				{
					Message = "Gondola deletada com sucesso!";
					return RedirectToPage("/Gondolas/Index");
				}
			}

			return Page();
		}
	}
}