using Microsoft.Extensions.Configuration;
using NonFungibleTokenMetaDataExtraction.Application.Model;
using NonFungibleTokenMetaDataExtraction.Application.Services;


IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var apiKey = config.GetRequiredSection("ApiKey").Value;
var client = NonFungibleTokenClient.GetNonFungibleTokenClient(apiKey);

while (true)
{
    Console.Write("Please enter contract address: ");
    var contract = Console.ReadLine();
    Console.Write("Please enter index number: ");
    var index = Console.ReadLine();
    var request = new NonFungibleTokenInputRequest()
    {
        ContractAddress = contract,
        TokenIndeX = index
    };

    var model = await client.GetNonFungibleTokenModel(request);
    Console.WriteLine(model);
    Console.ReadLine();
}
