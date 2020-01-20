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
    public class AddModel : PageModel
    {
		IFarmaciasRepository _farmaciaRepository;
		IAssociadosRepository _associadosRepository;

		public AddModel(IFarmaciasRepository farmaciaRepository, IAssociadosRepository associadosRepository)
		{
			_farmaciaRepository = farmaciaRepository;
			_associadosRepository = associadosRepository;
		}

		[BindProperty]
		public Entities.Farmacias farmacia { get; set; }

		public SelectList Associados { get; set; }

		[TempData]
		public string Message { get; set; }

		public IActionResult OnGet()
		{
			carregarDropDownList();
			return Page();
		}

		public IActionResult OnPost()
		{

			if (ModelState.IsValid)
			{
				var count = _farmaciaRepository.Add(farmacia);

				if (count > 0)
				{
					Message = "Novo farmacia incluída com sucesso !";
					return Redirect("/Farmacias/Index");
				}


			}

			return Page();
		}

		public void carregarDropDownList()
		{
			var associados = _associadosRepository.GetAssociados();

			Associados = new SelectList(associados.OrderBy(tb => tb.Nome),"Id", "Nome", null);
		}

	}
}