namespace WorksOrders.Data
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Address_Line3 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Phone_Mobile { get; set; }
        public string Phone_Office { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
