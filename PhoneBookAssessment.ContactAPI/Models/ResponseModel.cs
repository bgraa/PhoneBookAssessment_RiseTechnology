namespace PhoneBookAssessment.ContactAPI.Models
{
    public class ResponseModel
    {
        public bool IsValid { get; set; } = true;
        public string Message { get; set; }

    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}