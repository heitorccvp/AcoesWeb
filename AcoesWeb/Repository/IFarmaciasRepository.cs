using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IFarmaciasRepository
	{
		int Add(Farmacias farmacia);
		List<FarmaciasView> GetFarmacia();
		Farmacias Get(int id);
		int Edit(Farmacias farmacia);
		int Delete(int id);
	}
}
