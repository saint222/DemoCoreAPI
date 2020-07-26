using AutoMapper;
using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.Commands;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.Data.SQLServer;
using DemoCoreAPI.DomainModels.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCoreAPI.BusinessLogic.Handlers
{
    public class AddSchoolHandler : IRequestHandler<AddSchoolCommand, AddSchoolApiModel>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public AddSchoolHandler(IMapper mapper, ApiContext context)
        {
            _context = context;
            if (context == null)
                throw new ArgumentNullException("Context is null.");
            _mapper = mapper;
        }
        public async Task<AddSchoolApiModel> Handle(AddSchoolCommand model, CancellationToken cancellationToken)
        {
            if (model == null)
                throw new ArgumentNullException("AddSchoolCommand can not be null.");

            var exists = _context.Schools.FirstOrDefault(
                x => x.SchoolNumber == model.SchoolNumber && 
                x.Address.District == model.Address.District && 
                x.Address.Locality == model.Address.Locality &&
                x.Address.Region == (int)model.Address.Region);
            if (exists != null)
                throw new EmailDuplicateException("This school already exists.");
            //var school = new SchoolDb
            //{
            //    SchoolNumber = model.SchoolNumber,
            //    SchoolAddress = new SchoolAddressDb
            //    {
            //        Region = (int)model.Address.Region,
            //        District = model.Address.District,
            //        Locality = model.Address.Locality,
            //        Street = model.Address.Street,
            //        HouseNumber = model.Address.HouseNumber
            //    }

            //};
            var school = _mapper.Map<School>(model);
            _context.Add(school);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AddSchoolApiModel>(school);
        }
    }
}
