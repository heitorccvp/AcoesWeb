using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IAprovadoresRepository
	{
		int Add(Aprovadores aprovador);
		List<Aprovadores> GetAprovadores();
		Aprovadores Get(int id);
		int Edit(Aprovadores aprovador);
		int Delete(int id);
	}
}
