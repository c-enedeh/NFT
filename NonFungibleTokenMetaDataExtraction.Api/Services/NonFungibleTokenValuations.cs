using NonFungibleTokenMetaDataExtraction.Api.Model;
using NonFungibleTokenMetaDataExtraction.Application.Model;
using NonFungibleTokenMetaDataExtraction.Application.Services;

namespace NonFungibleTokenMetaDataExtraction.Api.Services;

public class NonFungibleTokenValuations : INonFungibleTokenValuations
{
    public async Task<NonFungibleToken> GetMetaData(Request requestModel)
    {
        var configuration = new ConfigurationManager();
        var apiKey = configuration.GetSection("ApiKey").Value;
        var client = NonFungibleTokenClient.GetNonFungibleTokenClient(apiKey);

        var request = new NonFungibleTokenInputRequest
        {
            ContractAddress = requestModel.ContractAddress,
            TokenIndeX = requestModel.TokenIndex
        };

        var model = await client.GetNonFungibleTokenModel(request);

        return model;

    }
}