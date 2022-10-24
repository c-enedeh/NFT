using NonFungibleTokenMetaDataExtraction.Application.Model;
using NonFungibleTokenMetaDataExtraction.Application.Services;

var client = NonFungibleTokenClient.GetNonFungibleTokenClient("4441cc2988c64bc1bc3029f55d39dbe6");

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
