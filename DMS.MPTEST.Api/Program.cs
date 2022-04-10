using Autofac;
using Autofac.Extensions.DependencyInjection;
using DMS.MPTEST.Common.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegister(AppContext.BaseDirectory, new List<string>()
    {
        "DMS.MPTEST.Services.dll",
    }));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
