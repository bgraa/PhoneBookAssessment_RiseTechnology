using AutoMapper;
using FluentAssertions;
using Moq;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;
using PhoneBookAssessment.ContactAPI.Models.Enums;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services;
using PhoneBookAssessment.ContactAPI.Services.Common;

namespace PhoneBookAssessment.Test.ContactApiTest;

[TestClass]
public class PersonServiceUnitTest : BaseTests
{

    private readonly Mock<IPersonRepository> _personRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public PersonServiceUnitTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _personRepositoryMock = new Mock<IPersonRepository>();
        _mapper = GetMapper();
        _personService = new PersonService(_unitOfWorkMock.Object, _mapper);
    }
     
    [TestMethod]
    public async Task Should_Create_Person()
    {
        // setup

        var personEntity = new Person
        {
            Company = "test",
            ContactInformation = new List<PersonContactInformation>
            {
                new PersonContactInformation
                {
                    Id = Guid.NewGuid(),
                    InformationContent = "test",
                    InformationType = InformationTypes.Email
                }
            },
            Id = Guid.NewGuid(),
            Name = "Test",
            Surname = "Surname"
        };

        var createPersonModel = new CreatePersonModel
        {
            Company = "test",
            Name = "Test",
            Surname = "Surname",
            ContactInformation = new List<PersonContactInformationModel>
            {
                new PersonContactInformationModel
                {
                      Id = Guid.NewGuid(),
                    InformationContent = "test",
                    InformationType = InformationTypes.Email
                }
            }
        };

        // body

        _unitOfWorkMock.Setup(x => x.PersonRepository.AddAsync(personEntity));

        await _personService.CreatePersonAsync(createPersonModel);

        // tear down

        _unitOfWorkMock.Verify(x => x.SaveAsync(), Times.Once);
    }

    [TestMethod]
    public async Task Should_Return_Error_Create_Person_When_Model_Is_Null()
    {
        // setup
         
        // body

        _unitOfWorkMock.Setup(x => x.PersonRepository.AddAsync(It.IsAny<Person>()));

      var response =  await _personService.CreatePersonAsync(null);

        // tear down

        _unitOfWorkMock.Verify(x => x.SaveAsync(), Times.Never);
        response.IsValid.Should().BeFalse();
        response.Message.Should().Be("Person should be not null");

    }

    [TestMethod]
    public async Task Should_Get_All_Person()
    {
        // setup

        var personEntity = new List<Person>
        {
            new Person
            {
                Company = "test",
                Name = "Test",
                Surname = "Surname"
            },
            new Person
            {
                Company = "test 2",
                Name = "Test 2",
                Surname = "Surname 2"
            },

        };



        // body

        _unitOfWorkMock.Setup(x => x.PersonRepository.GetAllAsync()).ReturnsAsync(personEntity);

        var allPersons = await _personService.GetAllPersonsAsync();

        // tear down

        allPersons.Should().NotBeNullOrEmpty();
        allPersons.Count().Should().Be(2);
    }

    [TestMethod]
    public async Task Should_Get_Person_With_Person_Id()
    {
        // setup

        var personEntity = new Person
        {
            Id = Guid.NewGuid(),
            Company = "test",
            Name = "Test",
            Surname = "Surname"
        };



        // body

        _unitOfWorkMock.Setup(x => x.PersonRepository.GetByIdAsync(personEntity.Id)).ReturnsAsync(personEntity);

        var person = await _personService.GetPersonByIdAsync(personEntity.Id);

        // tear down

        person.Data.Should().NotBeNull();
        person.Data.Company.Should().Be("test");
        person.Data.Name.Should().Be("Test");
        person.Data.Surname.Should().Be("Surname");
    }

    [TestMethod]
    public async Task Should_Get_Person_With_Person_Id_With_Detail()
    {
        // setup

        var personEntity = new Person
        {
            Id = Guid.NewGuid(),
            Company = "test",
            Name = "Test",
            Surname = "Surname"
        };



        // body

        _unitOfWorkMock.Setup(x => x.PersonRepository.GetPersonWithContactInformationAsync(personEntity.Id)).ReturnsAsync(personEntity);

        var person = await _personService.GetPersonByIdWithDetailAsync(personEntity.Id);

        // tear down

        person.Data.Should().NotBeNull();
        person.Data.Company.Should().Be("test");
        person.Data.Name.Should().Be("Test");
        person.Data.Surname.Should().Be("Surname");
    }
}
