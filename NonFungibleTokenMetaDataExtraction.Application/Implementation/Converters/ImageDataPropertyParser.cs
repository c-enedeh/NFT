using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class ImageDataPropertyParser : IPropertyParser
    {
        public string PropertyName => "image_data";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.Media = jsonInput.ToString();
        }
    }
}
