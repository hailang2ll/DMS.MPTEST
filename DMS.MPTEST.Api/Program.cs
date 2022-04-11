using Autofac;
using Autofac.Extensions.DependencyInjection;
using DMS.MPTEST.Api.Filter;
using DMS.MPTEST.Common.ServiceExtensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegister(AppContext.BaseDirectory, new List<string>()
    {
        "DMS.MPTEST.Services.dll",
    }));
    builder.RegisterModule<AutofacPropertityModuleRegister>();
});

builder.Services.AddControllers();

builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
