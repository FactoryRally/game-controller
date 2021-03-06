/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: 0.1.0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Tgm.Roborally.Server.Filters;

namespace Tgm.Roborally.Server {
	/// <summary>
	///     Startup
	/// </summary>
	public class Startup {
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		/// <summary>
		///     The application configuration.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		///     This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services) {
			// Add framework services.
			services
				.AddMvc(setupAction: opts => opts.EnableEndpointRouting = false)
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddNewtonsoftJson(setupAction: opts => {
					opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					//opts.SerializerSettings.Converters.Add(new StringEnumConverter {
					//	NamingStrategy = new CamelCaseNamingStrategy()
					//});
					opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
					opts.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
				});

			services
				.AddSwaggerGen(setupAction: c => {
					c.SwaggerDoc("2.16.1", new OpenApiInfo {
						Version     = "2.16.1",
						Title       = "Robot Rally Game logic engine",
						Description = "Robot Rally Game logic engine (ASP.NET Core 3.1)",
						Contact = new OpenApiContact {
							Name  = "Nils Brugger",
							Url   = new Uri("https://github.com/openapitools/openapi-generator"),
							Email = "nbrugger@student.tgm.ac.at"
						}
						//TermsOfService = new Uri("")
					});
					//c.CustomSchemaIds(type => type.(true));
					c.IncludeXmlComments(
						$"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");
					// Sets the basePath property in the Swagger document generated
					//				c.DocumentFilter<BasePathFilter>("/v1/");

					// Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
					// Use [ValidateModelState] on Actions to actually validate it in C# as well!
					c.OperationFilter<GeneratePathParamsValidationFilter>();
				});
		}

		/// <summary>
		///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseHttpsRedirection();
			app
				.UseMvc()
				.UseDefaultFiles()
				.UseStaticFiles()
				.UseSwagger(setupAction: c => { c.RouteTemplate = "swagger/{documentName}/openapi.json"; })
				.UseSwaggerUI(setupAction: c => {
					c.SwaggerEndpoint("/openapi-original.json", "Robot Rally (manual documentation)");
					c.SwaggerEndpoint("/swagger/2.16.1/openapi.json", "Robot Rally (autogenerated)");
				});
			app.UseRouting();
			app.UseEndpoints(configure: endpoints => { endpoints.MapControllers(); });

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();
		}
	}
}