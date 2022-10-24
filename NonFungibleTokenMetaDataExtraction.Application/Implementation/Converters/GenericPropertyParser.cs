using Newtonsoft.Json.Linq;
using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class GenericPropertyParser : IPropertyParser
    {
        public virtual string PropertyName => "attributes";
        public void SwapValue(NonFungibleToken model, object jsonInput)
        {
            const int defaultLength = 2;
            if (jsonInput is not JArray jArray) return;
            foreach (var jToken in jArray)
            {
                var obj = (JObject) jToken;
                var props = obj.Properties().ToArray();
                string? key;
                string? value;
                if (props.Length == defaultLength)
                {
                    key = props[0]?.Value.ToString();
                    value = props[1]?.Value.ToString();
                }
                else
                {
                    key = props.FirstOrDefault(p => p.Name == "trait_type")?.Value.ToString();
                    value = props.FirstOrDefault(p => p.Name == "value")?.Value.ToString();
                }

                if (!string.IsNullOrWhiteSpace(key)
                    && !model.Properties.ContainsKey(key))
                {
                    model.Properties[key] = new NonFungibleTokenProperty { Category = key, Property = value };
                }
                
            }
        }
    }
}
