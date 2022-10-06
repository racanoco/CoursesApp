﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Common.DomainEvent;
using Common.DomainEvent.Handler;
using Common.Model;
using CoursesApp.Infrastructure;
using CoursesApp.Domain.Security.RoleAggregate;
using CoursesApp.Infrastructure.Security.RoleInfrastructure;
using CoursesApp.Domain.Sales.CourseAggregate;
using CoursesApp.Infrastructure.Sales.CourseInfrastructure;
using CoursesApp.Domain.Sales.BuyerAggregate;
using CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
using CoursesApp.Domain.Service.StudentAggregate;
using CoursesApp.Infrastructure.Service.StudentInfrastructure;
using CoursesApp.Domain;
using CoursesApp.Application.Security.RoleApplication;
using CoursesApp.Domain.Security.RoleAggregate.Events;
using CoursesApp.Application.Security.RoleApplication.EventHandlers;
using Microsoft.Extensions.Logging;
using Common.Services;

using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
    services
        .AddSingleton<ILogger, CoursesAppLogger>()
        .AddSingleton<IDomainEventBus, DomainEventBus>()
        .AddSingleton<IDomainEventHandlerFactory, DomainEventHandlerFactory>()
        .AddSingleton<IDbContext, CoursesAppContext>()
        .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
        .AddSingleton<IRoleRepository, RoleRepository>()
        .AddSingleton<ICourseRepository, CourseRepository>()
        .AddSingleton<IBuyerRepository, BuyerRepository>()
        .AddSingleton<IStudentRepository, StudentRepository>()
        .AddSingleton<IUnitOfWork, UnitOfWork>()
        .AddSingleton<RoleService>()
        .AddSingleton<IDomainEventHandler<UserFirstNameChangedDomainEvent>, UserFirstNameChangedDomainEventHandler>())
        .Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

await ExecuteApp(provider);
await host.RunAsync();

static async Task ExecuteApp(IServiceProvider serviceProvider)
{
    RoleService roleService = serviceProvider.GetRequiredService<RoleService>();

    // ServiceResult serviceResult = await roleService.Create("admin", "Admin", "Rol con privilegios de administrador");
    // ServiceResult serviceResult = await roleService.Create("normal", "Normal", "Rol con privilegios normales");

    // Address address1 = new Address("Calle 1", "Ciudad 1", "Estado 1", "Pais 1", "100");

    // ServiceResult serviceResult = await roleService.CreateUser(Guid.Parse("CAF2B7E7-46A5-4AE2-932A-FD36F054F547"), "user1", "Nombre 1", "Apellido 1", address1, "Cualquier cosa 1");

    //Address address2 = new Address("Calle 2", "Ciudad 2", "Estado 2", "Pais 2", "200");
    //ServiceResult serviceResult = await roleService.CreateUser(Guid.Parse("CAF2B7E7-46A5-4AE2-932A-FD36F054F547"), "user2", "Nombre 2", "Apellido 2", address2, "Cualquier cosa 2");

    ServiceResult serviceResult = await roleService.UpdateUserFirstName(Guid.Parse("2BC703C7-69A9-4F55-B477-40800CC6FF55"), "Nombre 1 modificado");

    if (serviceResult.ErrorMessage != "")
        Console.WriteLine(serviceResult.ErrorMessage);
    else
        if(serviceResult.Data is not null)
            Console.WriteLine("El proceso ha finalizado correctamente.");
    
}