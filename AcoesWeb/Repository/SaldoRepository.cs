using AcoesWeb.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public class SaldoRepository : ISaldoRepository
	{
		IConfiguration _configuration;

		public SaldoRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}

		public List<Saldo> GetSaldo(string status)
		{
			var connectionString = this.GetConnection();
			List<Saldo> acoesMkt = new List<Saldo>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"SELECT 
									AcoesMkt.id
									,AcoesMkt.Nome as acaoNome
									,associados.nome as associoadosNome
									,farmacias.nome as farmaciasNome
									,fornecedores.nome as fornecedoresNome
									,AcoesMkt.valor
									,status.nome as nomeStatus
									,AcoesMkt.dataPagamento
									FROM AcoesMkt
									LEFT JOIN associados ON associados.id = acoesMkt.id_associado
									LEFT JOIN farmacias ON farmacias.id = acoesMkt.id_farmacia
									LEFT JOIN gondolas ON gondolas.id = acoesMkt.id_gondola
									LEFT JOIN posicao ON posicao.id = gondolas.id_posicao
									LEFT JOIN partes ON partes.id_gondola = gondolas.id AND partes.id = AcoesMkt.id_partes
									LEFT JOIN posicao posicaoParte ON posicaoParte.id = partes.id_posicao
									LEFT JOIN fornecedores ON fornecedores.id = acoesMkt.id_fornecedor
									LEFT JOIN status ON status.id = acoesMkt.id_status
									LEFT JOIN aprovadores ON aprovadores.id = acoesMkt.id_aprovador 
									WHERE status.nome ='" + status + "'";

					acoesMkt = con.Query<Saldo>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return acoesMkt;
			}
		}

	}
}
