using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class IpfsImagePropertyParser : IPropertyParser
    {
        public string PropertyName => "ipfs_image";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.ExternalUrl = jsonInput.ToString();
        }
    }
}
