using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using DexpensysDev.Libs.Mappers;
using DexpensysDev.Libs.Repositories;
using DexpensysDev.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DexpensysDev
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(options => options.EnableEndpointRouting = false);
      
      
      services.AddAWSService<IAmazonDynamoDB>();
      services.AddDefaultAWSOptions(
        new AWSOptions
        {
          Region = RegionEndpoint.GetBySystemName("eu-west-1"),
          Profile = "dintentdev"
        });
      // services.AddDefaultAWSOptions(Configuration.GetAWSOptions())

      services.AddSingleton<IExpenseService, ExpenseService>();
      services.AddSingleton<IExpenseRepository, ExpenseRepository>();
      services.AddSingleton<IMapper, Mapper>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // ReSharper disable once MVC1005
      app.UseMvc();
      

      // app.UseRouting();
      //
      // app.UseEndpoints(endpoints =>
      // {
      //   endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
      // });
    }
  }
}