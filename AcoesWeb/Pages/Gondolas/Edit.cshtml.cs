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
    public class EditModel : PageModel
    {
		IGondolasRepository _gondolasRepository;
		IFarmaciasRepository _farmaciaRepository;
		IPosicaoRepository _posicaoRepository;

		public EditModel(IGondolasRepository gondolasRepository, IFarmaciasRepository farmaciaRepository, IPosicaoRepository posicaoRepository)
		{
			_gondolasRepository = gondolasRepository;
			_farmaciaRepository = farmaciaRepository;
			_posicaoRepository = posicaoRepository;
		}

		[BindProperty]
		public Entities.Gondolas gondola { get; set; }

		public SelectList Farmacias { get; set; }

		public SelectList Posicoes { get; set; }

		public void OnGet(int id)
		{
			gondola = _gondolasRepository.Get(id);
			carregarDropDownListFarmacia(gondola.Id_Farmacia);
			carregarDropDownListPosicao(gondola.Id_Posicao);
		}

		public IActionResult OnPost()
		{
			var dados = gondola;

			if (ModelState.IsValid)
			{
				var count = _gondolasRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Gondolas/Index");
				}
			}
			return Page();
		}

		public void carregarDropDownListFarmacia(int id)
		{
			var farmacias = _farmaciaRepository.GetFarmacia();

			Farmacias = new SelectList(farmacias.OrderBy(tb => tb.Nome), "Id", "Nome", farmacias.Where(tb => tb.Id == id));
		}

		public void carregarDropDownListPosicao(int? id)
		{
			var posicoes = _posicaoRepository.GetPosicao();
			
			Posicoes = new SelectList(posicoes.OrderBy(tb => tb.Nome), "Id", "Nome", posicoes.Where(tb => tb.Id == id));
		}

	}
}