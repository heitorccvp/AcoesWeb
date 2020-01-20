using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcoesWeb.Pages.Saldo
{
    public class IndexModel : PageModel
    {
		ISaldoRepository _saldoRepository;
		public IndexModel(ISaldoRepository saldoRepository)
		{
			_saldoRepository = saldoRepository;
		}

		[BindProperty]
		public List<Entities.Saldo> listaSaldoPendente { get; set; }
		public List<Entities.Saldo> listaSaldoPago { get; set; }

		[BindProperty]
		public Entities.Saldo saldo { get; set; }

		[TempData]
		public string Message { get; set; }


		public void OnGet()
		{
			listaSaldoPendente = _saldoRepository.GetSaldo("Pendente Pagamento");
			listaSaldoPago = _saldoRepository.GetSaldo("Pago");
		}

		public IActionResult OnPostDelete(int id)
		{
			return Page();
		}
	}
}