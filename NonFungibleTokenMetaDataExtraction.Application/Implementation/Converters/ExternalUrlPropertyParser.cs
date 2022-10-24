using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class ExternalUrlPropertyParser : IPropertyParser
    {
        public string PropertyName => "external_url";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.ExternalUrl = jsonInput.ToString();
        }
    }
}
