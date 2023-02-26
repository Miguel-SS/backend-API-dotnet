namespace APIBackend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthYear { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Disease { get; set; }
        public string? Observation { get; set; }
    }
}
