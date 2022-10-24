using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class AnimationUrlPropertyParser : IPropertyParser
    {
        public string PropertyName => "animation_url";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.ExternalUrl = jsonInput.ToString();
        }
    }
}
