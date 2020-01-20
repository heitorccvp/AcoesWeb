using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoesWeb.Pages.Produtos
{
    public class AddModel : PageModel
    {
		IProdutosRepository _produtoRepository;
		IFornecedoresRepository _fornecedoresRepository;

		public AddModel(IProdutosRepository produtoRepository, IFornecedoresRepository fornecedoresRepository)
		{
			_produtoRepository = produtoRepository;
			_fornecedoresRepository = fornecedoresRepository;
		}

		[BindProperty]
		public Entities.Produtos produto { get; set; }

		public SelectList Fornecedores { get; set; }

		[TempData]
		public string Message { get; set; }

		public IActionResult OnGet()
		{
			carregarDropDownLists();
			return Page();
		}

		public IActionResult OnPost()
		{

			if (ModelState.IsValid)
			{
				var count = _produtoRepository.Add(produto);

				if (count > 0)
				{
					Message = "Novo produto incluído com sucesso !";
					return Redirect("/Produtos/Index");
				}


			}

			return Page();
		}

		public void carregarDropDownLists()
		{
			var fornecedores = _fornecedoresRepository.GetFornecedores();

			Fornecedores = new SelectList(fornecedores.OrderBy(tb => tb.Nome), "Id", "Nome", null);

		}

	}
}