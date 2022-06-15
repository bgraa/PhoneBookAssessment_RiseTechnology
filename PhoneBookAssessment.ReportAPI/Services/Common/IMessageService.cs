namespace PhoneBookAssessment.ReportAPI.Interface
{
    public interface IMessageService
    {
        bool EnqueueMessage(string message);
    }
}