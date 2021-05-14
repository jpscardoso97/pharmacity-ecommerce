namespace Crosscutting.Helpers
{
    public static class DataTransferHelper
    {
        private const char SplitCharacter = ';';
        
        public static string ProductIdsToString(string[] productIds)
        {
            return string.Join(SplitCharacter, productIds);
        }
        
        public static string[] ProductIdsFromString(string productIdsString)
        {
            return productIdsString.Split(SplitCharacter);
        }
    }
}