namespace AutoSklad.Core.LocalStore
{
    public class LocalStore
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Naming { get; set; }
        public int Count { get; set; }
        public int SkladId { get; set; }
    }
}