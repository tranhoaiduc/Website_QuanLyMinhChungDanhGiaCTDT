using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;
using QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService;
using QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService.Interface;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService.Interface;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChuanService;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChuanService.Interface;
using QuanLyMinhChungDanhGiaCTDT.Services.UserService;
using QuanLyMinhChungDanhGiaCTDT.Services.UserService.Interface;
using QuanLyMinhChungDanhGiaCTDT.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyMinhChungDanhGiaCTDT.API
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
            services.AddDbContext<EFDbContext>(config => config.UseSqlServer(Configuration.GetConnectionString("Website_QuanLyMinhChungDanhGiaCTDT")));

            services.AddIdentity<MyIdentityUser, MyIdentityRole>()
                .AddEntityFrameworkStores<EFDbContext>()
                .AddDefaultTokenProviders();

            string key = Configuration["JWT:Key"];
            string issuer = Configuration["JWT:Issuer"];

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwtConfig =>
                {
                    jwtConfig.RequireHttpsMetadata = false;
                    jwtConfig.SaveToken = true;
                    jwtConfig.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddApiVersioning(apiConfig =>
            {
                apiConfig.DefaultApiVersion = new ApiVersion(1, 0, "Latest");
                apiConfig.AssumeDefaultVersionWhenUnspecified = false;
                apiConfig.ReportApiVersions = true;
            });

            services.AddAutoMapper(autoMapperConfig =>
            {
                autoMapperConfig.AddProfile<UserProfile>();
            });

            services.AddCors(config =>
            {
                config.AddDefaultPolicy(builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthorization(authorizeConfig =>
            {
                authorizeConfig.AddPolicy("QuanTri", policy =>
                {
                    policy.RequireRole("QuanTri");
                });
            });

            services.AddHttpContextAccessor();
            services.AddTransient<UserManager<MyIdentityUser>, UserManager<MyIdentityUser>>();
            services.AddTransient<SignInManager<MyIdentityUser>, SignInManager<MyIdentityUser>>();
            services.AddTransient<RoleManager<MyIdentityRole>, RoleManager<MyIdentityRole>>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMyDapper, MyDapper>();
            services.AddTransient<ITieuChuanService, TieuChuanService>();
            services.AddTransient<ITieuChiService, TieuChiService>();
            services.AddTransient<IMinhChungService, MinhChungService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminApp.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminApp.API v1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}