namespace lotionApp.Models
{
    public class Lotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Volume { get; set; } 
        public float Price { get; set; } // in dollars
        public string Scent { get; set; }
        public int SPF { get; set; } 
        public string Ingredients { get; set; }

    }
}
