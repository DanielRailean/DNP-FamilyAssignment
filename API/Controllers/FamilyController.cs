using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController: ControllerBase, IFamilyController
    {
        private IFamilyService familyService;

        public FamilyController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesOfUser([FromQuery] int userId)
        {
            try
            {
                IList<Family> families = familyService.GetFamiliesOfUser(userId);
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            try
            {
                familyService.AddFamily(family);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Family>> RemoveFamily([FromQuery] int familyId)
        {
            try
            {
                familyService.RemoveFamily(familyId);
                return Ok(familyId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<Family>> UpdateFamily([FromBody]Family family)
        {
            try
            {
                familyService.UpdateFamily(family);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}