namespace WorksOrders.Data
{
    public class SupplierAttachment
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
