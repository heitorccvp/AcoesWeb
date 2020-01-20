using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoesWeb.Pages.Partes
{
    public class AddModel : PageModel
    {
		IPartesRepository _parteRepository;
		IGondolasRepository _gondolasRepository;
		IPosicaoRepository _posicaoRepository;

		public AddModel(IPartesRepository parteRepository, IGondolasRepository gondolasRepository, IPosicaoRepository posicaoRepository)
		{
			_parteRepository = parteRepository;
			_gondolasRepository = gondolasRepository;
			_posicaoRepository = posicaoRepository;
		}

		[BindProperty]
		public Entities.Partes parte { get; set; }

		public SelectList Gondolas { get; set; }

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
				var count = _parteRepository.Add(parte);

				if (count > 0)
				{
					Message = "Nova parte incluída com sucesso !";
					return Redirect("/Partes/Index");
				}


			}

			return Page();
		}


		public void carregarDropDownLists()
		{
			var gondolas = _gondolasRepository.GetGondolas();

			Gondolas = new SelectList(gondolas.OrderBy(tb => tb.Nome), "Id", "Nome", null);

			var posicoes = _posicaoRepository.GetPosicao();

			Posicoes = new SelectList(posicoes.OrderBy(tb => tb.Nome), "Id", "Nome", null);

		}
	}
}