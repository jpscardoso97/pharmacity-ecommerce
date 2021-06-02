namespace Crosscutting.Helpers
{
    using System.Collections.Generic;

    public static class DataTransferHelper
    {
        private const char SplitCharacter = ';';
        
        public static string IdsToString(IList<string> productIds)
        {
            return productIds != null ? string.Join(SplitCharacter, productIds) : default;
        }
        
        public static IList<string> IdsFromString(string productIdsString)
        {
            return productIdsString?.Split(SplitCharacter);
        }
    }
}