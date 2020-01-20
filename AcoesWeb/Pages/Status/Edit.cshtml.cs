using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Status
{
    public class EditModel : PageModel
    {
		IStatusRepository _statusRepository;

		public EditModel(IStatusRepository statusRepository)
		{
			_statusRepository = statusRepository;
		}

		[BindProperty]
		public Entities.Status status { get; set; }

		public void OnGet(int id)
		{
			status = _statusRepository.Get(id);
		}

		public IActionResult OnPost()
		{
			var dados = status;

			if (ModelState.IsValid)
			{
				var count = _statusRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Status/Index");
				}
			}
			return Page();
		}
	}
}