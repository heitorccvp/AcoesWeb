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
    public class EditModel : PageModel
    {
		IProdutosRepository _produtosRepository;
		IFornecedoresRepository _fornecedoresRepository;

		public EditModel(IProdutosRepository produtosRepository, IFornecedoresRepository fornecedoresRepository)
		{
			_produtosRepository = produtosRepository;
			_fornecedoresRepository = fornecedoresRepository;
		}

		public SelectList Fornecedores { get; set; }

		[BindProperty]
		public Entities.Produtos produto { get; set; }

		public void OnGet(int id)
		{
			produto = _produtosRepository.Get(id);
			carregarDropDownLists(produto.Id_Fornecedor);
		}

		public IActionResult OnPost()
		{
			var dados = produto;

			if (ModelState.IsValid)
			{
				var count = _produtosRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Produtos/Index");
				}
			}
			return Page();
		}

		public void carregarDropDownLists(int id)
		{
			var fornecedores = _fornecedoresRepository.GetFornecedores();

			Fornecedores = new SelectList(fornecedores.OrderBy(tb => tb.Nome), "Id", "Nome", fornecedores.Where(tb => tb.Id == id));

		}

	}
}