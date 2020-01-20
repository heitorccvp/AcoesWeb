using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public interface IStatusRepository
	{
		int Add(Status status);
		List<Status> GetStatus();
		Status Get(int id);
		int Edit(Status status);
		int Delete(int id);
	}
}
