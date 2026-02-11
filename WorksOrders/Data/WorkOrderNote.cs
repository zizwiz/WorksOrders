using System;

namespace WorkOrderApp.Data
{
    public class WorkOrderNote
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public string NoteText { get; set; }

        public override string ToString()
        {
            return Timestamp.ToString("dd-MMM-yyyy HH:mm") + " - " + NoteText;
        }
    }
}