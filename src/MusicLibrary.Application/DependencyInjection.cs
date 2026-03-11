namespace MusicLibrary.Application;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Application.Abstractions.Messaging;
// using MusicLibrary.Application.Decorators.Logging;
// using MusicLibrary.Application.Decorators.Validation;
// using MusicLibrary.Application.Abstractions.DomainEvents;

public static class DependencyInjection
{
    public static IServiceCollection RegisterQueryHandlers(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());


        return services;
    }
}
