using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
namespace CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CRUDContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //Registrando o Serviço com Injeção de Dependência da Aplicação
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<ProviderService>();
            builder.Services.AddScoped<DepartmentsService>();
            builder.Services.AddScoped<ProvidersRecordService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
