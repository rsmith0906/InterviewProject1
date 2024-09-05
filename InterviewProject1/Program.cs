
using InterviewProject1;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var diContainer = Startup.GetServiceProvider();

var bankAccountManager = diContainer.GetRequiredService<BankAccountManager>();

var startingBalance = await bankAccountManager.GetBalance();

Console.WriteLine($"Starting balance: {startingBalance.ToString("C", CultureInfo.CurrentCulture)}");

await bankAccountManager.Deposit(100);
await bankAccountManager.Withdraw(50);
await bankAccountManager.Withdraw(10);
await bankAccountManager.Deposit(200);
await bankAccountManager.Withdraw(5);
await bankAccountManager.Withdraw(75);

var endingBalance = await bankAccountManager.GetBalance();

Console.WriteLine($"Ending balance: {endingBalance.ToString("C", CultureInfo.CurrentCulture)}");