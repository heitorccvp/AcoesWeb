using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Aprovadores
{
    public class IndexModel : PageModel
    {
		IAprovadoresRepository _aprovadoresRepository;

		public IndexModel(IAprovadoresRepository aprovadoresRepository)
		{
			_aprovadoresRepository = aprovadoresRepository;
		}

		[BindProperty]
		public List<Entities.Aprovadores> listaAprovadores { get; set; }

		[BindProperty]
		public Entities.Aprovadores aprovador { get; set; }

		[TempData]
		public string Message { get; set; }

		public void OnGet()
        {
			listaAprovadores = _aprovadoresRepository.GetAprovadores();
		}
		
		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _aprovadoresRepository.Delete(id);

				if (count > 0)
				{
					Message = "Aprovador deletado com sucesso!";
					return RedirectToPage("/Aprovadores/Index");
				}

			}
			return Page();
		}

    }
}