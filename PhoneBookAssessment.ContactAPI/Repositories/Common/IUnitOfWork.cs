namespace PhoneBookAssessment.ContactAPI.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
          IPeopleRepository Peoples { get; }
          Task SaveAsync();
    }
}