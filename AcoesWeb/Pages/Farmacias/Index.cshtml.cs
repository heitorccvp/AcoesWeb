using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Farmacias
{
    public class IndexModel : PageModel
    {
		IFarmaciasRepository _farmaciaRepository;
		public IndexModel(IFarmaciasRepository farmaciaRepository)
		{
			_farmaciaRepository = farmaciaRepository;
		}

		[BindProperty]
		public List<Entities.FarmaciasView> listaFarmacias { get; set; }

		[BindProperty]
		public Entities.Farmacias farmacia { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaFarmacias = _farmaciaRepository.GetFarmacia();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _farmaciaRepository.Delete(id);

				if (count > 0)
				{
					Message = "Farmacia deletada com sucesso!";
					return RedirectToPage("/Farmacias/Index");
				}
			}

			return Page();
		}
	}
}