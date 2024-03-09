namespace BookApp.Components.CsvReader.Extension
{
    public class BookLogicExtension
    {
        public static bool ConvertStringToBoolean(string input)
        {
            return input.ToLower() switch
            {
                "yes" => true,
                "no" => false,
                _=> throw new Exception("Incorrect wording!"),
            };
        }
        public static int ConvertStringToInteger(string input)
        {
            return int.TryParse(input, out int result) ? result 
                :throw new Exception("String is not an integer!");
        }
    }
}
