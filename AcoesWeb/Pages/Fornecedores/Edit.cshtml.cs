using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Fornecedores
{
	public class EditModel : PageModel
    {
		IFornecedoresRepository _fornecedoresRepository;

		public EditModel(IFornecedoresRepository fornecedoresRepository)
		{
			_fornecedoresRepository = fornecedoresRepository;
		}

		[BindProperty]
		public Entities.Fornecedores fornecedor { get; set; }

		public void OnGet(int id)
		{
			fornecedor = _fornecedoresRepository.Get(id);
		}

		public IActionResult OnPost()
		{
			var dados = fornecedor;

			if (ModelState.IsValid)
			{
				var count = _fornecedoresRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Fornecedores/Index");
				}
			}
			return Page();
		}
	}
}