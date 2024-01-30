using System.Text;
namespace BookApp.Data.Entities
{
    public class Bookmark : EntityBase
    {
        public string Name { get; set; }
        public string Dimension { get; set; }
        public string Color { get; set; }
        public decimal StandarCost { get; set; }
        public decimal ListPrice { get; set; }
        public int? NameLenght { get; set; }
        public decimal? TotalSales { get; set; }
        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new(1024);
            sb.AppendLine($"{Name} Id: {Id}");
            sb.AppendLine($"Color: {Color} Dimension: {Dimension}");
            sb.AppendLine($"Cost: {StandarCost} Price: {ListPrice}");
            if (NameLenght.HasValue)
            {
                sb.AppendLine($"Name Lenght {NameLenght}");
            }
            if (TotalSales.HasValue)
            {
                sb.AppendLine($"Total Sales {TotalSales}");
            }
            return sb.ToString();
            #endregion
        }
    }
}

