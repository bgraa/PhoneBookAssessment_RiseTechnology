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

        public async Task<ResponseModel<Guid>> CreatePersonAsync(CreatePersonModel person)
        {
            try
            {
                var response = new ResponseModel<Guid>();

                if (person == null)
                {
                    response.IsValid = false;
                    response.Message = "Person should be not null";

                    return response;
                }

                var personEntity = _mapper.Map<Person>(person);

                await _unitOfWork.PersonRepository.AddAsync(personEntity);

                await _unitOfWork.SaveAsync();

                response.Data = personEntity.Id;

                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ResponseModel> DeletePerson(Guid personId)
        {
            try
            {
                var response = new ResponseModel();

                var person = await _unitOfWork.PersonRepository.GetByIdAsync(personId);
                if (person == null)
                {
                    response.IsValid=false;
                    response.Message = "Person not found.";
                }

                _unitOfWork.PersonRepository.Delete(person);

                await _unitOfWork.SaveAsync();
 
                return response;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<PersonModel>> GetAllPersonsAsync()
        {
            try
            {
                var persons = await _unitOfWork.PersonRepository.GetAllAsync();

                return _mapper.Map<IReadOnlyList<PersonModel>>(persons);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel<PersonModel>> GetPersonByIdAsync(Guid id)
        {
            try
            {
                var response = new ResponseModel<PersonModel>();

                if(string.IsNullOrWhiteSpace(id.ToString()))
                {
                    response.IsValid=false;
                    response.Message="Person id cannot be null.";

                    return response;
                }

                var person = await _unitOfWork.PersonRepository.GetByIdAsync(id);
                
                response.Data = _mapper.Map<PersonModel>(person);

                return response;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<ResponseModel<PersonDetailModel>> GetPersonByIdWithDetailAsync(Guid id)
        {
            var person = await _unitOfWork.PersonRepository.GetPersonWithContactInformationAsync(id);

            var response = new ResponseModel<PersonDetailModel>();

            response.Data = _mapper.Map<PersonDetailModel>(person);

            return response;
        }

    }
}