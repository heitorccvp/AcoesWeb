using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Fornecedores
{
    public class IndexModel : PageModel
    {
		IFornecedoresRepository _fornecedorRepository;
		public IndexModel(IFornecedoresRepository fornecedorRepository)
		{
			_fornecedorRepository = fornecedorRepository;
		}

		[BindProperty]
		public List<Entities.Fornecedores> listaFornecedores { get; set; }

		[BindProperty]
		public Entities.Fornecedores fornecedor { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaFornecedores = _fornecedorRepository.GetFornecedores();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _fornecedorRepository.Delete(id);

				if (count > 0)
				{
					Message = "Fornecedor deletado com sucesso!";
					return RedirectToPage("/Fornecedores/Index");
				}
			}

			return Page();
		}
	}
}