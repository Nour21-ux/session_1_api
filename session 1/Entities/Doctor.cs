namespace session_1.Entities
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
