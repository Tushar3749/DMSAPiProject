using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using DMS.Core.Models.SystemManager;
using DMS.Services;
using DMS.Services.Employee;
using DMS.Services.Interfaces;
using DMS.Services.Map;
using System;
using System.IO;
using System.Text;
using DMS.Services.SalesInvoice;
using DMS.Core.Models.SalesInvoice;
using DMS.Services.Inventory;
using DMS.Services.Discount;
using DMS.Services.Accounts;
using DMS.Core.DTO;
using Microsoft.Extensions.Options;
using DMS.Services.SummaryAndReturn;
using DMS.Services.Outstanding;
using DMS.Services.Report;
using DMS.Services.Maintenance;
using DMS.Services.CreditNote;

namespace DMS
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
            services.AddControllers().AddJsonOptions(options =>
            {
                // Use the default property (Pascal) casing.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DMS", Version = "v1" });
            //});

            #region Configure Swagger  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DMS", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            #endregion

            // JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["TokenManagement:Secret"])),
                    ValidIssuer = Configuration["TokenManagement:Issuer"],
                    ValidAudience = Configuration["TokenManagement:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 200; // 200 items max
                options.ValueLengthLimit = 1024 * 1024 * 100; // 100MB max len form data
            });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            var allowedOrigins = this.Configuration.GetSection("AllowedSites").Value;
            string[] origins = allowedOrigins.Split(";");


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            // SERVICES 
            registerServices(services);


            configureDatabaseConnection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DMS v1"));
            }            
            else app.UseExceptionHandler("/Error");

            
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            setStaticFiles(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        // DATABASE CONNECTION
        public void configureDatabaseConnection(IServiceCollection services)
        {
            // SYSTEM MANAGER
            services.AddDbContext<SystemManagerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SystemManager"));
            }); 
            
            
            services.AddDbContext<InvoiceContext>(c =>
                 c.UseSqlServer(Configuration.GetConnectionString("Invoice"))
            );


            services.Configure<DBConnectionDto>(Configuration).AddSingleton(s => s.GetRequiredService<IOptions<DBConnectionDto>>().Value);
        }

        //public void MapContext(IServiceCollection services, T  ContextClass, string ConnectionStringName )
        //{
        //    // SYSTEM MANAGER
        //    services.AddDbContext<ContextClass>(options =>
        //    {
        //        options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringName));
        //    });
        //}


        private void registerServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IInvoiceAllocationService, InvoiceAllocationService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IstockService, StockService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInvoiceSummaryService, InvoiceSummaryService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<IChemistService, ChemistService>();
            services.AddScoped<IDepoDayStatementService, DepoDayStatementService>();
            services.AddScoped<ISummaryService, SummaryService>();
            services.AddScoped<IOutstandingService, OutStandingService>();
            services.AddScoped<ISalesReportService, SalesReportService>();
            services.AddScoped<IDataValidationService, DataValidationService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<ICreditNoteService, CreditNoteService>();
        }

        private void setStaticFiles(IApplicationBuilder app)
        {
            try
            {
                app.UseFileServer(new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"attachments")),
                    RequestPath = new PathString("/attachments")
                });
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
