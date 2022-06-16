namespace PhoneBookAssessment.ReportAPI.Services.Common
{
    public interface IMessageService
    {
        bool EnqueueMessage(string message);
    }
}