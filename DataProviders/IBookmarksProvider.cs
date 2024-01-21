using BookApp.Entities;

namespace BookApp.DataProviders
{
    public interface IBookmarksProvider
    {
        //select
        List<string> GetUniqueBookmarksColor();
        decimal GetMinimumPriceOfAllBookmarks();
        List<Bookmark> GetSpecificColumns();
        string AnonymusClass();

        //order by
        List<Bookmark> OrderByName();
        List<Bookmark> OrderByNameDescending();
        List<Bookmark> OrderByColorAndName();
        List<Bookmark> OrderByColorAndNameDesc();

        // where
        List<Bookmark> WhereColorIs(string color);
        List<Bookmark> WhereStartsWith(string prefix);
        List<Bookmark> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

        //first,by,single
        Bookmark FirstByColor(string color);
        Bookmark? FirstOrDefaultByColor(string color);
        Bookmark FirstOrDefaultByColorWithDefault(string color);
        Bookmark LastByColor(string color);
        Bookmark SingleById(int id);
        Bookmark SingleOrDefaultById(int id);

        //take
        List<Bookmark> TakeBookmarks(int howMony);
        List<Bookmark> TakeBookmarks(Range range);
        List<Bookmark> TakeBookmarksWhileNameStartsWith(string prefix);

        //skip
        List<Bookmark> SkipBookmarks(int howMony);
        List<Bookmark> SkipBookmarksWhileNameStartsWith(string prefix);

        //distinc
        List<string> DistincAllColor();
        List<Bookmark> DistincByColor();

        //distinc
        List<Bookmark[]> ChunkBookmarks(int size);
    }
}
