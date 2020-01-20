using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AcoesWeb.Repository
{
	public interface IFornecedoresRepository
	{
		int Add(Fornecedores fornecedor);
		List<Fornecedores> GetFornecedores();
		Fornecedores Get(int id);
		int Edit(Fornecedores fornecedor);
		int Delete(int id);
	}
}
