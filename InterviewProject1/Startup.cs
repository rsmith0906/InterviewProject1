using InterviewProject1.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewProject1
{
    internal class Startup
    {
        public static ServiceProvider GetServiceProvider()
        {
            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton<DbContext>();
            serviceCollection.AddScoped<IAccountAccessor, AccountAccessor>();
            serviceCollection.AddScoped<BankAccountManager>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
