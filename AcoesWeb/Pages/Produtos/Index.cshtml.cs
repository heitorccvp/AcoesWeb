using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Produtos
{
    public class IndexModel : PageModel
    {
		IProdutosRepository _produtoRepository;
		public IndexModel(IProdutosRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		[BindProperty]
		public List<Entities.ProdutosView> listaProdutos { get; set; }

		[BindProperty]
		public Entities.Produtos produto { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaProdutos = _produtoRepository.GetProdutos();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _produtoRepository.Delete(id);

				if (count > 0)
				{
					Message = "Produto deletado com sucesso!";
					return RedirectToPage("/Produtos/Index");
				}
			}

			return Page();
		}
	}
}