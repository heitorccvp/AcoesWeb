using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Enum;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoesWeb.Pages.AcoesMkt
{
    public class AddModel : PageModel
    {

		IAcoesMktRepository _acoesMktRepository;
		IAssociadosRepository _associadosRepository;
		IFarmaciasRepository _farmaciasRepository;
		IGondolasRepository _gondolasRepository;
		IPartesRepository _partesRepository;
		IFornecedoresRepository _fornecedoresRepository;
		IStatusRepository _statusRepository;
		IAprovadoresRepository _aprovadoresRepository;

		public AddModel(
			 IAcoesMktRepository acoesMktRepository
			,IAssociadosRepository associadosRepository
			,IFarmaciasRepository farmaciasRepository
			,IGondolasRepository gondolasRepository
			,IPartesRepository partesRepository
			,IFornecedoresRepository fornecedoresRepository
			,IStatusRepository statusRepository
			,IAprovadoresRepository aprovadoresRepository
			)
		{
			_acoesMktRepository = acoesMktRepository;
			_associadosRepository = associadosRepository;
			_farmaciasRepository = farmaciasRepository;
			_gondolasRepository = gondolasRepository;
			_partesRepository = partesRepository;
			_fornecedoresRepository = fornecedoresRepository;
			_statusRepository = statusRepository;
			_aprovadoresRepository = aprovadoresRepository;
		}

		[BindProperty]
		public Entities.AcoesMkt acoesMkt { get; set; }

		public SelectList Associados { get; set; }
		public SelectList Farmacias { get; set; }
		public SelectList Gondolas { get; set; }
		public SelectList Partes { get; set; }
		public SelectList Fornecedores { get; set; }
		public SelectList Status { get; set; }
		public SelectList Aprovadores { get; set; }

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
				var count = _acoesMktRepository.Add(acoesMkt);

				if (count > 0)
				{
					Message = "Nova Ação incluída com sucesso !";
					return Redirect("/AcoesMkt/Index");
				}


			}

			return Page();
		}

		public void carregarDropDownList()
		{
			carregarAssociados();
			carregarFarmacias();
			carregarGondolas();
			carregarPartes();
			carregarFornecedores();
			carregarStatus();
			carregarAprovadores();
		}

		public void carregarAssociados()
		{
			var associados = _associadosRepository.GetAssociados();

			Associados = new SelectList(associados.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

		public void carregarFarmacias()
		{
			var farmacias = _farmaciasRepository.GetFarmacia();

			Farmacias = new SelectList(farmacias.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

		public void carregarGondolas()
		{
			var gondolas = _gondolasRepository.GetGondolas();

			Gondolas = new SelectList(gondolas.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

		public void carregarPartes()
		{
			var partes = _partesRepository.GetPartes();

			Partes = new SelectList(partes.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

		public void carregarFornecedores()
		{
			var fornecedores = _fornecedoresRepository.GetFornecedores();

			Fornecedores = new SelectList(fornecedores.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}

		public void carregarStatus()
		{
			var status = _statusRepository.GetStatus();

			string teste = AprovacaoEnum.PendenteAprovacao.ToString();

			Status = new SelectList(status.Where(tb => tb.Nome == "Pendente de Aprovação"), "Id", "Nome", status.Where(tb => tb.Nome == "Pendente de Aprovação"));
		}
		public void carregarAprovadores()
		{
			var aprovadores = _aprovadoresRepository.GetAprovadores();

			Aprovadores = new SelectList(aprovadores.OrderBy(tb => tb.Nome), "Id", "Nome", null);
		}
	}
}