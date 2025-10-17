using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CacheExample.CQRSProblem
{
    public interface IRequest<TResult>
    {

    }

    public interface IRequetHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        TResult Handle(TRequest request);
    }

    public class UserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class UserCommandHandler : IRequetHandler<UserCommand, bool>
    {
        public bool Handle(UserCommand request)
        {
            Console.WriteLine($"User created with Id {request.Id}");
            return true;
        }
    }

    public class Mediator
    {
        private readonly IServiceProvider _serviceProvider;
        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Send<TRequest, TResult>(TRequest request) where TRequest : IRequest<TResult>
        {
            var handler = _serviceProvider.GetService<IRequetHandler<TRequest, TResult>>();
            return handler.Handle(request);
        }


    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestHandler(this IServiceCollection services,Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var handlerInterfaces = type.GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IRequetHandler<,>));

                foreach (var handlerInterface in handlerInterfaces)
                {
                    services.AddTransient(handlerInterface, type);
                }
            }

            return services;
        }
    }

}