using Dataplace.Core;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using Dataplace.Imersao.Core.Domain.Produtos.Repositories;
using Dataplace.Imersao.Core.Domain.Services;
using Dataplace.Imersao.Core.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataplace.Imersao.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var executingAssembly = new Assembly[]
              { Assembly.GetExecutingAssembly(), typeof(Dataplace.Imersao.Core.Boot).Assembly};

            var builder = Dataplace.Core.DataplaceApplication.CreateBuilder(null)
                .UseAppName("SALESAPP")
                .UseLayout(AppLayoutEnum.Basic)
                .UseMediatR(executingAssembly);

            ConfiguurationService(builder.Services);

            var app = builder.Build();
            app.Run<MainForm>();

        }

        private static void ConfiguurationService(IServiceCollection services)
        {
            services.AddSingleton<MainForm>();

            // domain - services
            services.AddScoped<IOrcamentoService, OrcamentoService>();


            // domain - repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

        }


    }
}
