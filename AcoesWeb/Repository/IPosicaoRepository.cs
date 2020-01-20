using AcoesWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcoesWeb.Repository
{
	public interface IPosicaoRepository
	{
		int Add(Posicao posicao);
		List<Posicao> GetPosicao();
		Posicao Get(int id);
		int Edit(Posicao posicao);
		int Delete(int id);
	}
}
