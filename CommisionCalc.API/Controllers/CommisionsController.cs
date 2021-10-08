using CommisionCalc.BusinessLogic;
using CommisionCalc.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommisionCalc.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommisionsController : ControllerBase
    {
        private ICommision _commision;

       public CommisionsController(ICommision commision)
        {
            _commision = commision;
        }

        [HttpGet]
        public List<ICommision> Get()
        {
           return _commision.GetAll();
        }

        [HttpPost]
        public List<ICommision> Add([FromBody]Commision commision)
        {
            return _commision.Add(commision);
        }

        [HttpPut]
        public int Add(int sales)
        {
            return _commision.Calculate(sales);
        }
    }
}
