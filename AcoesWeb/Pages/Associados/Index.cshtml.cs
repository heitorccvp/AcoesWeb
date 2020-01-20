using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AcoesWeb.Pages.Associados
{
	public class IndexModel : PageModel
    {
		IAssociadosRepository _associadoRepository;
		public IndexModel(IAssociadosRepository associadoRepository)
		{
			_associadoRepository = associadoRepository;
		}

		[BindProperty]
		public List<Entities.Associados> listaAssociados { get; set; }

		[BindProperty]
		public Entities.Associados associado { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
        {
			listaAssociados = _associadoRepository.GetAssociados();
        }

		public IActionResult OnPostDelete(int id)
		{
			if (id > 0)
			{
				var count = _associadoRepository.Delete(id);

				if(count > 0)
				{
					Message = "Associado deletado com sucesso!";
					return RedirectToPage("/Associados/Index");
				}
			}

			return Page();
		}
    }
}