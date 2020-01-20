using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Associados
{
    public class EditModel : PageModel
    {

		IAssociadosRepository _associadosRepository;

		public EditModel(IAssociadosRepository associadosRepository)
		{
			_associadosRepository = associadosRepository;
		}

		[BindProperty]
		public Entities.Associados associado { get; set; }
		
		public void OnGet(int id)
        {
			associado = _associadosRepository.Get(id);
        }

		public IActionResult OnPost()
		{
			var dados = associado;

			if (ModelState.IsValid)
			{
				var count = _associadosRepository.Edit(dados);

				if (count > 0)
				{
					return RedirectToPage("/Associados/Index");
				}
			}
			return Page();
		}


    }
}