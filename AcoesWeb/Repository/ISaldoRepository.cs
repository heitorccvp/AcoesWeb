using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface ISaldoRepository
	{
		List<Saldo> GetSaldo(string status);
	}
}
