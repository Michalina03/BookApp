namespace BookApp.Components.CsvReader.Extension
{
    public class BookLogicExtension
    {
        public static bool ConvertStringToBoolean(string input)
        {
            if (input == "yes")
            {
                return true;
            }
            else if (input == "no")
            {
                return false;
            }
            else
            {
                throw new Exception("Incorrect wording!");
            }
        }

        public static int ConvertStringToInteger(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new Exception("String is not a integer!");
            }
        }
    }
}
