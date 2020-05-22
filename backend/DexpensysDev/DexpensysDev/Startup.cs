using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
      services.AddMvc();
      // MvcOptions.EnableEndpointRouting = false;

      services.AddAWSService<IAmazonDynamoDB>();
      services.AddDefaultAWSOptions(
        new AWSOptions
        {
          Region = RegionEndpoint.GetBySystemName("eu-west-1")
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

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