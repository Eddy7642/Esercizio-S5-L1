using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Questo metodo viene chiamato dal runtime. Usa questo metodo per aggiungere servizi al container.
    // Qyesto ,mng
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<DataAccess>(); // Registrazione del servizio DataAccess
        services.AddControllers(); // Aggiunta dei controller
    }

    // Questo metodo viene chiamato dal runtime. Usa questo metodo per configurare la pipeline delle richieste HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthentication(); // Aggiunge il middleware per l'autenticazione
        app.UseAuthorization();  // Aggiunge il middleware per l'autorizzazione

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Mappa i controller per gestire le richieste
        });
    }
}
