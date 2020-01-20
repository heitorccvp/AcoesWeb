using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Posicao
{
    public class EditModel : PageModel
    {
		IPosicaoRepository _posicaosRepository;

		public EditModel(IPosicaoRepository posicaosRepository)
		{
			_posicaosRepository = posicaosRepository;
		}

		[BindProperty]
		public Entities.Posicao posicao { get; set; }

		public void OnGet(int id)
		{
			posicao = _posicaosRepository.Get(id);
		}

		public IActionResult OnPost()
		{
			var dados = posicao;

			if (ModelState.IsValid)
			{
				var count = _posicaosRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Posicao/Index");
				}
			}
			return Page();
		}
	}
}