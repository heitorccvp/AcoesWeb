using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Fornecedores
{
    public class AddModel : PageModel
    {
		IFornecedoresRepository _fornecedorRepository;

		public AddModel(IFornecedoresRepository fornecedorRepository)
		{
			_fornecedorRepository = fornecedorRepository;
		}

		[BindProperty]
		public Entities.Fornecedores fornecedor { get; set; }

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
				var count = _fornecedorRepository.Add(fornecedor);

				if (count > 0)
				{
					Message = "Novo fornecedor incluído com sucesso !";
					return Redirect("/Fornecedores/Index");
				}


			}

			return Page();
		}
	}
}