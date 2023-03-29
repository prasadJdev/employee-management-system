namespace employeeProject.Models
{
    public class Requests
    {
        public int Id { get; set; }
        
        public string Request_Name { get; set; }

        public int Raised_By { get; set; }
        
        public string Raised_By_Name { get; set; }//By replace with to
        
        public DateTime Request_Date_Time { get; set; }

        public bool Request_Status { get; set; } //Approvd - 0; Rejected-1
        
        public string? Request_Message { get; set;}
        
        public string? Request_Comment { get; set;}
    }
}
