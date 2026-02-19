namespace WorksOrders.Data
{
    public class SupplierAttachment
    {
        public string FileName { get; set; }     // full filename on disk
        public string FilePath { get; set; }     // full path to file
        public string DisplayName { get; set; }  // clean name shown in ListBox

        public override string ToString()
        {
            return DisplayName;
        }

    }
}
