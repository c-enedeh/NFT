using Microsoft.Extensions.Configuration;
using NonFungibleTokenMetaDataExtraction.Application.Model;
using NonFungibleTokenMetaDataExtraction.Application.Services;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting Non Fungible Token (NFT) Metadata Extraction app");

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var apiKey = config.GetRequiredSection("ApiKey").Value;
Log.Information("Retrieve Api key from appsettings file successfully");

NonFungibleTokenClient client;
try
{
    Log.Information("Fetching NFT client information");
    client = NonFungibleTokenClient.GetNonFungibleTokenClient(apiKey);
    Log.Information("Fetched NFT client information successfully");

}
catch (Exception exception)
{
    Log.Error(exception,"An error happened while fetching NFT client information");
    throw;
}


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

    try
    {
        Log.Information("Fetching NFT client metadata object information");
        var model = await client.GetNonFungibleTokenModel(request);
        Log.Information("Fetched NFT client metadata object information successfully");
        Console.WriteLine(model);
        Console.ReadLine();
    }
    catch (Exception exception)
    {
        Log.Error(exception,"An error happened while fetching NFT metadata object");
    }
}
