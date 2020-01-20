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
    public class EditModel : PageModel
    {

		IPartesRepository _partesRepository;
		IGondolasRepository _gondolasRepository;
		IPosicaoRepository _posicaoRepository;

		public EditModel(IPartesRepository partesRepository, IGondolasRepository gondolasRepository, IPosicaoRepository posicaoRepository)
		{
			_partesRepository = partesRepository;
			_gondolasRepository = gondolasRepository;
			_posicaoRepository = posicaoRepository;

		}

		[BindProperty]
		public Entities.Partes parte { get; set; }

		public SelectList Gondolas { get; set; }
		public SelectList Posicoes { get; set; }

		public void OnGet(int id)
		{
			parte = _partesRepository.Get(id);
			carregarDropDownLists(parte.Id_Gondola);
			carregarDropDownListPosicao(parte.Id_Posicao);
		}

		public IActionResult OnPost()
		{
			var dados = parte;

			if (ModelState.IsValid)
			{
				var count = _partesRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Partes/Index");
				}
			}
			return Page();
		}

		public void carregarDropDownLists(int id)
		{
			var gondolas = _gondolasRepository.GetGondolas();

			Gondolas = new SelectList(gondolas.OrderBy(tb => tb.Nome), "Id", "Nome", gondolas.Where(tb => tb.Id == id));
		}

		public void carregarDropDownListPosicao(int? id)
		{
			var posicoes = _posicaoRepository.GetPosicao();

			Posicoes = new SelectList(posicoes.OrderBy(tb => tb.Nome), "Id", "Nome", posicoes.Where(tb => tb.Id == id));
		}
	}
}