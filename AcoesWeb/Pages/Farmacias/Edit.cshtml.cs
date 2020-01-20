using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoesWeb.Pages.Farmacias
{
    public class EditModel : PageModel
    {
		IFarmaciasRepository _farmaciasRepository;
		IAssociadosRepository _associadosRepository;

		public EditModel(IFarmaciasRepository farmaciaRepository, IAssociadosRepository associadosRepository)
		{
			_farmaciasRepository = farmaciaRepository;
			_associadosRepository = associadosRepository;
		}

		[BindProperty]
		public Entities.Farmacias farmacia { get; set; }

		public SelectList Associados { get; set; }

		public void OnGet(int id)
		{
			farmacia = _farmaciasRepository.Get(id);
			carregarDropDownList(farmacia.Id_Associado);
		}

		public IActionResult OnPost()
		{
			var dados = farmacia;

			if (ModelState.IsValid)
			{
				var count = _farmaciasRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Farmacias/Index");
				}
			}
			return Page();
		}


		public void carregarDropDownList(int id)
		{
			var associados = _associadosRepository.GetAssociados();

			Associados = new SelectList(associados.OrderBy(tb => tb.Nome), "Id", "Nome", associados.Where(tb => tb.Id == id));
		}
	}
}