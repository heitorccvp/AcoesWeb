using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Posicao
{
    public class IndexModel : PageModel
    {
		IPosicaoRepository _posicaoRepository;
		public IndexModel(IPosicaoRepository posicaoRepository)
		{
			_posicaoRepository = posicaoRepository;
		}

		[BindProperty]
		public List<Entities.Posicao> listaPosicao { get; set; }

		[BindProperty]
		public Entities.Posicao posicao { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaPosicao = _posicaoRepository.GetPosicao();
		}

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _posicaoRepository.Delete(id);

				if (count > 0)
				{
					Message = "Posicao deletada com sucesso!";
					return RedirectToPage("/Posicao/Index");
				}
			}

			return Page();
		}
	}
}