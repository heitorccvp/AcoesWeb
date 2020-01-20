using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcoesWeb.Repository
{
	public interface IGondolasRepository
	{
		int Add(Gondolas gondola);
		List<GondolasView> GetGondolas();
		Gondolas Get(int id);
		int Edit(Gondolas gondola);
		int Delete(int id);
	}
}
