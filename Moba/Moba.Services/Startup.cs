using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moba.Services.GraphQLTypes;
using Moba.Services.Models;
using Moba.Services.Repositories;
using Moba.Services.Repositories.Constrains;

namespace Moba.Services
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<EasyStoreQuery>();
            services.AddTransient<IAlbumeRepository, AlbumeRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<AlbumeType>();
            services.AddTransient<SongType>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new EasyStoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<EasyStoreQuery>() });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
