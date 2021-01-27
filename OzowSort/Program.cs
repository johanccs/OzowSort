using Microsoft.Extensions.DependencyInjection;
using Ozow.Service.Interfaces;
using Ozow.Service.Services;
using System;

namespace OzowSort
{
    class Program
    {
        #region Fields

        private static IServiceProvider _serviceProvider;

        #endregion

        static void Main(string[] args)
        {
            _serviceProvider = RegisterServices();

            ISortService _sortService = _serviceProvider.GetService<ISortService>();

            var result = _sortService.Sort("Contrary to popular belief, the pink unicorn flies east.");

            Console.WriteLine($"Result is: { result }");
            Console.Read();

            DisposeServices();
        }

        #region Helper Methods

        private static ServiceProvider RegisterServices()
        {
            ServiceCollection _serviceCollection = new ServiceCollection();

            _serviceCollection.AddSingleton<ISortService, SortService>();
           
            return _serviceCollection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;

            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }

        #endregion
    }
}
