namespace Library.Helpers.Extensions
{
    public class SortModel
    {
        public string ColId { get; set; } = "Id";
        public string Sort { get; set; } = "asc";
        public string PairAsSqlExpression
        {
            get
            {
                return $"{ColId} {Sort}";
            }
        }
    }
}
