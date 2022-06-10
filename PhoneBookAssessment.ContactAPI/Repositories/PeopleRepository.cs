using PhoneBookAssessment.ContactAPI.Entities;
using PhoneBookAssessment.ContactAPI.Repositories.Interfaces;

namespace PhoneBookAssessment.ContactAPI.Repositories
{
    public class PeopleRepository: List<People>, IPeopleRepository
    {
        private readonly static List<People> _peoples = Populate();

        private static List<People> Populate()
        {
            var result = new List<People>()
            {
                new People
                {
                    Id = 1,
                    Title = "First People",
                    WriterId = 1,
                    LastUpdate = DateTime.Now
                },
                new People
                {
                    Id = 2,
                    Title = "Second title",
                    WriterId = 2,
                    LastUpdate = DateTime.Now
                },
                new People
                {
                    Id = 3,
                    Title = "Third title",
                    WriterId = 3,
                    LastUpdate = DateTime.Now
                }
            };

            return result;
        }

        public List<People> GetAll()
        {
            return _peoples;
        }

        public People? Get(int id)
        {
            return _peoples.FirstOrDefault(x => x.Id == id);
        }

        public int Delete(int id)
        {
            var removed = _peoples.SingleOrDefault(x => x.Id == id);

            if (removed != null)
                _peoples.Remove(removed);

            return removed?.Id ?? 0;
        }
    }
}