using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.AcoesMkt
{
    public class IndexModel : PageModel
    {
		IAcoesMktRepository _acoesMktRepository;
		public IndexModel(IAcoesMktRepository acoesMktRepository)
		{
			_acoesMktRepository = acoesMktRepository;
		}

		[BindProperty]
		public List<Entities.AcoesMktView> listaAcoesMkt { get; set; }

		[BindProperty]
		public Entities.AcoesMkt acoesMkt { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaAcoesMkt = _acoesMktRepository.GetAcoesMkt();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _acoesMktRepository.Delete(id);

				if (count > 0)
				{
					Message = "Ação deletada com sucesso!";
					return RedirectToPage("/AcoesMkt/Index");
				}
			}

			return Page();
		}
	}
}