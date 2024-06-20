namespace LMS.Domain.Employees
{
    public class Employee
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public string ReportsTo { get; set; } // the id of user which this user reports to
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
