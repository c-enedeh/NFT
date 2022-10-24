using NonFungibleTokenMetaDataExtraction.Api.Model;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Api.Services
{
    public interface INonFungibleTokenValuations
    {
        Task<NonFungibleToken> GetMetaData(Request model);
    }
}
