namespace employeeProject.Models
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;
        
        public string Body { get; set; } = string.Empty;
        public EmailDto(string To, string Subject, string Body) 
        {   
            this.To = To;
            this.Subject = Subject;
            this.Body = Body;
        }
    }
}
