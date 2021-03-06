namespace PhoneBookAssessment.ContactAPI.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
          IPersonRepository PersonRepository { get; }
          IPersonContactInformationRepository PersonContactInformationRepository { get; }
        Task SaveAsync();
    }
}