using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    //Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //Ignora os valores nulos ao fazer jun��es nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SpMedicalGroup.webApi"
                });

                //Habilita o caminho do swagger para xml ou json
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Adiciona o CORS ao projeto
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", 
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });


            // Define a forma de autentica��o
            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                        // define que o issuer ser� validado
                        ValidateIssuer = true,

                        // define que o audience ser� validado
                        ValidateAudience = true,

                        // define que o tempo de vida ser� validado
                        ValidateLifetime = true,

                        // forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sp-medical-group-autenticacao")),

                        // verifica o tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde est� vindo
                        ValidIssuer = "spMedicalGroup.webApi",

                        // define o nome da audience, para onde est� indo
                        ValidAudience = "spMedicalGroup.webApi"
                   };
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();            

            //Habilita a autentica��o
            app.UseAuthentication();

            //Habilita a autoriza��o
            app.UseAuthorization();

            // Habilita o CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Habilita o uso do swagger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpMedical.webApi v1");
                c.RoutePrefix = string.Empty;
            });       
        }
    }
}
