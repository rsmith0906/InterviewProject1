
using InterviewProject1;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var diContainer = Startup.GetServiceProvider();

var bankAccountManager = diContainer.GetRequiredService<BankAccountManager>();

// Simulate a account account
Guid accountId = Guid.NewGuid();

var startingBalance = await bankAccountManager.GetBalanceAsync(accountId);

Console.WriteLine($"Starting balance: {startingBalance.ToString("C", CultureInfo.CurrentCulture)}");

await bankAccountManager.DepositAsync(accountId, 100);
await bankAccountManager.WithdrawAsync(accountId, 50);
await bankAccountManager.WithdrawAsync(accountId, 10);
await bankAccountManager.DepositAsync(accountId, 200);
await bankAccountManager.WithdrawAsync(accountId, 5);
await bankAccountManager.WithdrawAsync(accountId, 75);

var endingBalance = await bankAccountManager.GetBalanceAsync(accountId);

Console.WriteLine($"Ending balance: {endingBalance.ToString("C", CultureInfo.CurrentCulture)}");