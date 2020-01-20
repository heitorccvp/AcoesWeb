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
	public class ProdutosRepository : IProdutosRepository
	{
		IConfiguration _configuration;
		public ProdutosRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Produtos produto)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "INSERT INTO Produtos(Nome, id_fornecedor) VALUES(@Nome, @id_fornecedor); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, produto);
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
					var query = "DELETE FROM Produtos WHERE id =" + id;
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
		public int Edit(Produtos produto)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Produtos SET Nome = @Nome, id_fornecedor = @id_fornecedor WHERE id = " + produto.Id;

					count = con.Execute(query, produto);
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
		public Produtos Get(int id)
		{
			var connectionString = this.GetConnection();
			Produtos produto = new Produtos();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Produtos WHERE id =" + id;
					produto = con.Query<Produtos>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return produto;
			}
		}
		public List<ProdutosView> GetProdutos()
		{
			var connectionString = this.GetConnection();
			List<ProdutosView> produtos = new List<ProdutosView>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"select 
									produtos.id,
									produtos.nome,
									fornecedores.nome as Fornecedor 
								from produtos 
									left join fornecedores on fornecedores.id = produtos.id_fornecedor";

					produtos = con.Query<ProdutosView>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return produtos;
			}
		}
	}
}
