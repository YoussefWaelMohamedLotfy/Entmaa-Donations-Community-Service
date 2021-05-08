using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.ReportedCases;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class ReportedCaseController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ReportedCaseController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Organizations/{id}/reportedcases")]
        [HttpGet]
        public IHttpActionResult GetReportedCasesToOrganization(int id)
        {
            var cases = _unit.ReportedCases.GetReportedCasesToOrganization(id);

            if (cases == null)
                return NotFound();

            var dto = cases.Select(_mapper.Map<ReportedCase, GetReportedCasesDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/reportedcases")]
        [HttpPost]
        public IHttpActionResult ReportNewCase(int id, AddReportedCaseDTO caseDTO)
        {
            var contributor = _unit.Contributors.Get(id);

            if (contributor == null)
                return NotFound();

            var reportedCase = _mapper.Map<ReportedCase>(caseDTO);
            reportedCase.ReportedBy = id;
            reportedCase.Photo = "a";

            _unit.ReportedCases.Add(reportedCase);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

    }
}
