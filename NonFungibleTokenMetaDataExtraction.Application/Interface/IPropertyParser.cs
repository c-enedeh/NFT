using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Interface
{
    public interface IPropertyParser
    {
        string PropertyName { get; }
        void SwapValue(NonFungibleToken model, object jsonInput);
    }
}
