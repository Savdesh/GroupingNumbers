using System;
using System.Collections.Generic;
using GroupingNumbers.Services.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroupingNumbers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupConsecutiveController : ControllerBase
    {
        private readonly IGroupConsecutives _groupConsecutives;

        public GroupConsecutiveController(IGroupConsecutives groupConsecutives)
        {
            _groupConsecutives = groupConsecutives;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] List<int> ids)
        {
            try
            {
                return _groupConsecutives.Group(ids);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       
    }
}
