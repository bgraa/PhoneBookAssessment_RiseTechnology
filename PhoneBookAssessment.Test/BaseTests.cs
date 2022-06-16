using System;
using AutoMapper;
using PhoneBookAssessment.ContactAPI.Mappings;

namespace PhoneBookAssessment.Test
{
	public abstract class BaseTests
	{
		 protected IMapper GetMapper()
        {
			var mce = new MapperConfigurationExpression();

			mce.AddProfile<ContactApiMapping>();

			var mc = new MapperConfiguration(mce);

			var mapper = new Mapper(mc);

			return mapper;
        }
	}
}

