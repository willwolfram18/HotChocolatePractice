using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.GraphiQL;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Types;
using HotChocolateData;
using HotChocolateWebApi.Models.Operations;
using HotChocolateWebApi.Models.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateWebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICharacterRepository, CharacterRepository>();

            services.AddGraphQL(serviceProvider => ConfigureGraphQLSchema(serviceProvider));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL("/graphql")
                .UseGraphiQL()
                .UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graphql"
                });
        }

        private ISchema ConfigureGraphQLSchema(IServiceProvider services)
        {
            return Schema.Create(config => {
                config.RegisterServiceProvider(services);

                config.RegisterQueryType<QueryObjectType>();
            });
        }
    }
}
