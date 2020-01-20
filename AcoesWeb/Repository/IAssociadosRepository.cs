using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IAssociadosRepository
	{
		int Add(Associados associado);
		List<Associados> GetAssociados();
		Associados Get(int id);
		int Edit(Associados associado);
		int Delete(int id);
	}
}
