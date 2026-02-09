namespace WorkOrderApp.Data
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}