using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IPartesRepository
	{
		int Add(Partes parte);
		List<PartesView> GetPartes();
		Partes Get(int id);
		int Edit(Partes parte);
		int Delete(int id);
	}
}
