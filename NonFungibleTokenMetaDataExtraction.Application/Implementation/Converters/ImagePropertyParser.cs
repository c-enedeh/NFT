using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class ImagePropertyParser : IPropertyParser
    {
        public string PropertyName => "image";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.Media = jsonInput.ToString();
        }
    }
}
