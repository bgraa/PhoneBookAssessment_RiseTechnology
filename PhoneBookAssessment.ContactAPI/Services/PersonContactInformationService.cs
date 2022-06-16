using AutoMapper;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services.Common;

namespace PhoneBookAssessment.ContactAPI.Services
{
    public class PersonContactInformationService : IPersonContactInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public PersonContactInformationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseModel> AddContactInformation(Guid personId, CreatePersonContactInformationModel contactInformationModel)
        {
            try
            {
                var response = new ResponseModel();

                var person = await _unitOfWork.PersonRepository.GetByIdAsync(personId);
                if(person == null)
                {
                    response.IsValid = false;
                    response.Message = "Person not found.";

                    return response;
                }

                var contactInformationEntity = _mapper.Map<PersonContactInformation>(contactInformationModel);

                contactInformationEntity.PersonId = person.Id;

                await _unitOfWork.PersonContactInformationRepository.AddAsync(contactInformationEntity);

                await _unitOfWork.SaveAsync();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel> DeleteContactInformation(Guid id)
        {
            try
            {
                var response = new ResponseModel();

                if(string.IsNullOrWhiteSpace(id.ToString()))
                {
                    response.IsValid = false;
                    response.Message = "Contact information id cannot be null.";

                    return response;
                }

                var contactInformation = await _unitOfWork.PersonContactInformationRepository.GetByIdAsync(id);
                if(contactInformation == null)
                {
                    response.IsValid = false;
                    response.Message = "Person contact information not found.";

                    return response;
                }

                _unitOfWork.PersonContactInformationRepository.Delete(contactInformation);

                await _unitOfWork.SaveAsync();

                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel<IReadOnlyList<PersonContactInformationModel>>> GetAllContactInformations()
        {
            try
            {
                var response = new ResponseModel<IReadOnlyList<PersonContactInformationModel>>();
                 
                var contactInformations = await _unitOfWork.PersonContactInformationRepository.GetAllAsync();

                response.Data = _mapper.Map<IReadOnlyList<PersonContactInformationModel>>(contactInformations);
                
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}