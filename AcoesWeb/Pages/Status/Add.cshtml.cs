using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Status
{
    public class AddModel : PageModel
    {
		IStatusRepository _statusRepository;

		public AddModel(IStatusRepository statusRepository)
		{
			_statusRepository = statusRepository;
		}

		[BindProperty]
		public Entities.Status status { get; set; }

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
				var count = _statusRepository.Add(status);

				if (count > 0)
				{
					Message = "Novo status incluído com sucesso !";
					return Redirect("/Status/Index");
				}


			}

			return Page();
		}
	}
}