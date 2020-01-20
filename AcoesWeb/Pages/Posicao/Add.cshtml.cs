using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Posicao
{
    public class AddModel : PageModel
    {
		IPosicaoRepository _posicaoRepository;

		public AddModel(IPosicaoRepository posicaoRepository)
		{
			_posicaoRepository = posicaoRepository;
		}

		[BindProperty]
		public Entities.Posicao posicao { get; set; }

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
				var count = _posicaoRepository.Add(posicao);

				if (count > 0)
				{
					Message = "Nova posicao incluída com sucesso !";
					return Redirect("/Posicao/Index");
				}


			}

			return Page();
		}
	}
}