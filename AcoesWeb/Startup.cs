using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesWeb.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcoesWeb
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSingleton<IConfiguration>(Configuration);
		
			services.AddTransient<IAcoesMktRepository, AcoesMktRepository>();
			services.AddTransient<IAprovadoresRepository, AprovadoresRepository>();
			services.AddTransient<IAssociadosRepository, AssociadosRepository>();
			services.AddTransient<IFarmaciasRepository, FarmaciasRepository>();
			services.AddTransient<IFornecedoresRepository, FornecedoresRepository>();
			services.AddTransient<IGondolasRepository, GondolasRepository>();
			services.AddTransient<IPartesRepository, PartesRepository>();
			services.AddTransient<IPosicaoRepository, PosicaoRepository>();
			services.AddTransient<IProdutosRepository, ProdutosRepository>();
			services.AddTransient<IStatusRepository, StatusRepository>();
			services.AddTransient<ISaldoRepository, SaldoRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc();
		}
	}
}
