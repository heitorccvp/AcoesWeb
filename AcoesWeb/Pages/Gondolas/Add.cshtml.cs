using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoesWeb.Pages.Gondolas
{
    public class AddModel : PageModel
    {
		IGondolasRepository _gondolaRepository;
		IFarmaciasRepository _farmaciaRepository;
		IPosicaoRepository _posicaoRepository;

		public AddModel(IGondolasRepository gondolaRepository, IFarmaciasRepository farmaciaRepository, IPosicaoRepository posicaoRepository)
		{
			_gondolaRepository = gondolaRepository;
			_farmaciaRepository = farmaciaRepository;
			_posicaoRepository = posicaoRepository;
		}

		[BindProperty]
		public Entities.Gondolas gondola { get; set; }

		public SelectList Farmacias { get; set; }

		public SelectList Posicoes { get; set; }

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
				var count = _gondolaRepository.Add(gondola);

				if (count > 0)
				{
					Message = "Nova gondola incluída com sucesso !";
					return Redirect("/Gondolas/Index");
				}


			}

			return Page();
		}

		public void carregarDropDownLists()
		{
			var farmacias = _farmaciaRepository.GetFarmacia();

			Farmacias = new SelectList(farmacias.OrderBy(tb => tb.Nome), "Id", "Nome", null);

			var posicoes = _posicaoRepository.GetPosicao();

			Posicoes = new SelectList(posicoes.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

	}
}