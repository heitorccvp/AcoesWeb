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
	public class AcoesMktRepository : IAcoesMktRepository
	{
		IConfiguration _configuration;
		public AcoesMktRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(AcoesMkt acoesMkt)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"insert into acoesMkt
									(Nome
									, id_associado
									, id_farmacia
									, id_gondola
									, id_partes
									, id_fornecedor
									, id_status
									, id_aprovador
									, valor
									, dataVenda
									, dataAgendamento
									, dataPagamento)
									values
									(
									 @Nome
									, @id_associado
									, @id_farmacia
									, @id_gondola
									, @id_partes
									, @id_fornecedor
									, @id_status
									, @id_aprovador
									, @valor
									, @dataVenda
									, @dataAgendamento
									, @dataPagamento
									); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, acoesMkt);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public int Delete(int id)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "DELETE FROM AcoesMkt WHERE id =" + id;
					count = con.Execute(query);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public int Edit(AcoesMkt acoesMkt)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"update acoesMkt
									set  Nome = @Nome
										,id_associado =@id_associado
										,id_farmacia = @id_farmacia
										,id_gondola = @id_gondola
										,id_partes = @id_partes
										,id_fornecedor = @id_fornecedor
										,id_status = @id_status
										,id_aprovador = @id_aprovador
										,valor = @valor
										,dataVenda = @dataVenda
										,dataAgendamento = @dataAgendamento
										,dataPagamento = @dataPagamento 
								 WHERE id = " + acoesMkt.Id;

					count = con.Execute(query, acoesMkt);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public AcoesMkt Get(int id)
		{
			var connectionString = this.GetConnection();
			AcoesMkt acoesMkt = new AcoesMkt();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM AcoesMkt WHERE id =" + id;
					acoesMkt = con.Query<AcoesMkt>(query).FirstOrDefault();
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
		public List<AcoesMktView> GetAcoesMkt()
		{
			var connectionString = this.GetConnection();
			List<AcoesMktView> acoesMkt = new List<AcoesMktView>();
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
								,posicao.nome as posicaoNome
								,gondolas.altura as gondolaAltura
								,gondolas.largura as gondolaLargura
								,partes.altura as partesAltura
								,partes.largura as partesLargura
								,fornecedores.nome as fornecedoresNome
								,status.nome as nomeStatus
								,aprovadores.nome as nomeAprovador
								,AcoesMkt.valor
								,AcoesMkt.dataVenda
								,AcoesMkt.dataAgendamento
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
								LEFT JOIN aprovadores ON aprovadores.id = acoesMkt.id_aprovador";
					acoesMkt = con.Query<AcoesMktView>(query).ToList();
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
