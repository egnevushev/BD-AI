using BDAI;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSingleton<Application>()
    .BuildServiceProvider();

await services.GetRequiredService<Application>().RunAsync(args);
