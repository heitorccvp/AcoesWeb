using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IProdutosRepository
	{
		int Add(Produtos produto);
		List<ProdutosView> GetProdutos();
		Produtos Get(int id);
		int Edit(Produtos produto);
		int Delete(int id);
	}
}
