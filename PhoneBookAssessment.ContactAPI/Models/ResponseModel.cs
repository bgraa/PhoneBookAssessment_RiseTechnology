namespace PhoneBookAssessment.ContactAPI.Models
{
    public class ResponseModel<T>
    {
        public bool IsValid { get; set; } = true;
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}