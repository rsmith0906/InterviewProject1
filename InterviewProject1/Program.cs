
using InterviewProject1;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var diContainer = Startup.GetServiceProvider();

var bankAccountManager = diContainer.GetRequiredService<BankAccountManager>();

var startingBalance = await bankAccountManager.GetBalanceAsync();

Console.WriteLine($"Starting balance: {startingBalance.ToString("C", CultureInfo.CurrentCulture)}");

await bankAccountManager.DepositAsync(100);
await bankAccountManager.WithdrawAsync(50);
await bankAccountManager.WithdrawAsync(10);
await bankAccountManager.DepositAsync(200);
await bankAccountManager.WithdrawAsync(5);
await bankAccountManager.WithdrawAsync(75);

var endingBalance = await bankAccountManager.GetBalanceAsync();

Console.WriteLine($"Ending balance: {endingBalance.ToString("C", CultureInfo.CurrentCulture)}");