namespace WorkOrderApp.Data
{
    public class WorkOrderFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }


        public override string ToString()
        {
            return FileName;
        }

    }
}