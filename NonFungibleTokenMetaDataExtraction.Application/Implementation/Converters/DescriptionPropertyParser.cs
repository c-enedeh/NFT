using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class DescriptionPropertyParser : IPropertyParser
    {
        public string PropertyName => "description";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.Description = jsonInput.ToString();
        }
    }
}
