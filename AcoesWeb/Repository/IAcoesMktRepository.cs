using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IAcoesMktRepository
	{
		int Add(AcoesMkt acoesMkt);
		List<AcoesMktView> GetAcoesMkt();
		AcoesMkt Get(int id);
		int Edit(AcoesMkt acoesMkt);
		int Delete(int id);
	}
}
