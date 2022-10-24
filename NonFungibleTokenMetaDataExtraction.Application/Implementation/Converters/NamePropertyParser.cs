using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class NamePropertyParser : IPropertyParser
    {
        public string PropertyName => "name";

        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            model.Name = jsonInput.ToString();
        }
    }
}
