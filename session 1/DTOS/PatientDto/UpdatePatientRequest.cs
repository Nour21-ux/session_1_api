namespace session_1.DTOS.PatientDto
{
    public class UpdatePatientRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
