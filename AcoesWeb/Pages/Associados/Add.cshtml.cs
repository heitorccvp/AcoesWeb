using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Associados
{
    public class AddModel : PageModel
    {

		IAssociadosRepository _associadoRepository;

		public AddModel(IAssociadosRepository associadoRepository)
		{
			_associadoRepository = associadoRepository;
		}

		[BindProperty]
		public Entities.Associados associado { get; set; }

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
				var count = _associadoRepository.Add(associado);

				if (count > 0)
				{
					Message = "Novo associado incluído com sucesso !";
					return Redirect("/Associados/Index");
				}


			}

			return Page();
		}
			 

    }
}