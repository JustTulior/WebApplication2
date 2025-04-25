namespace WebApplication2.Shops
{
    public class Shops
    {
        public Shops() 
        { }
        public Shops (int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string address { get; set; } = null!;

        public static async Task<Shops> Create(int id, string name, string address)
        {
            return new Shops(id, name, address);
        }
    }
}
