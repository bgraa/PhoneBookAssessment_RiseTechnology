using AutoMapper;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services.Common;

namespace PhoneBookAssessment.ContactAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseModel<PersonModel>> CreatePersonAsync(PersonModel person)
        {
            try
            {
                var response = new ResponseModel<PersonModel>();

                if (person == null)
                {
                    response.IsValid = false;
                    response.Message = "Person should be not null";

                    return response;
                }

                var personEntity = _mapper.Map<Person>(person);
                
                await _unitOfWork.PersonRepository.AddAsync(personEntity).ConfigureAwait(false);

                await _unitOfWork.SaveAsync();

                response.Data = _mapper.Map<PersonModel>(personEntity);

                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void DeletePerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PersonModel>> GetAllPersonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PersonModel>> GetPersonByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PersonModel>> UpdatePersonAsync(PersonModel person)
        {
            throw new NotImplementedException();
        }
    }
}