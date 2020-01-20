using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Status
{
    public class IndexModel : PageModel
    {
		IStatusRepository _statusRepository;
		public IndexModel(IStatusRepository statusRepository)
		{
			_statusRepository = statusRepository;
		}

		[BindProperty]
		public List<Entities.Status> listaStatus { get; set; }

		[BindProperty]
		public Entities.Status status { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaStatus = _statusRepository.GetStatus();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _statusRepository.Delete(id);

				if (count > 0)
				{
					Message = "Status deletado com sucesso!";
					return RedirectToPage("/Status/Index");
				}
			}

			return Page();
		}
	}
}