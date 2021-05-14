using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Localiza.Frotas.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Localiza.Frotas.Infra.Repository.EF;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas
{
    /// <summary>
    /// Classe de configuração da aplicação .Net Core.
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Construtor padrão da classe Startup.
        /// </summary>
        /// <param name="configuration">Parametro para obter o arquivo de configuração appsettings.json</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Propriedade somente leitura para acessar os itens do arquivo de configuração appsettings.json
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Este método é chamado em tempo de execução. Use este método para adicionar serviços a sua aplicação. 
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<FrotaContext>(opt => opt.UseInMemoryDatabase());
            services.AddSingleton<IVeiculoRepository, InMemoryRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Localiza.Frotas", Version = "v1" });

                var xmlPathApi = Path.Combine(AppContext.BaseDirectory, "Localiza.Frotas.xml");
                c.IncludeXmlComments(xmlPathApi);
            });
        }
        
        /// <summary>
        /// Este método é chamado em tempo de execução. Use este método para adicionar configurações de requisição HTTP.
        /// </summary>
        /// <param name="app">description</param>
        /// <param name="env">description</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Localiza.Frotas v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
