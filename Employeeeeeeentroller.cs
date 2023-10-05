using Elite_HR.Helper;
using Elite_HR.Interface;
using Elite_HR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite_HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface iemployee;
        private readonly IConfiguration _iconfigure;
        public EmployeeController(IEmployeeInterface memployee, IConfiguration iconfigure)
        {
            iemployee = memployee;
            _iconfigure = iconfigure;
        }
        [HttpPost("AddOrUpdateEmployeeLogin")]
        public async Task<ActionResult<RetObj>>EmployeeLogin(EmployeeModel employeemodel)
        {
            try
            {
                var result = await iemployee.EmployeeLogin(employeemodel);
                if(result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, $"An error occured{e.Message}");
            }
        }
        [HttpPost("EmployeeMobileLogin")]
        public RetObj MobileLogin(EmployeeModel employee,string mobileno)
        {
            return iemployee.MobileLogin(employee,mobileno);
        }
        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult>GetAllEmployee()
        {
            try
            {
                List<EmployeeModel> employee = await iemployee.GetAllEmployee();
                if(employee!=null)
                {
                    return Ok(employee);
                }
                return NoContent();
                    
            }
            catch(Exception e)
            {
                return StatusCode(500, $"An error Occured {e.Message}");
            }
        }
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult>GetEmployeeById(int employeeid)
        {
            try
            {
                EmployeeModel employee = await iemployee.GetEmployeeById(employeeid);
                if(employee!=null)
                {
                    return Ok(employee);
                }
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, $"An error occured {e.Message}");
            }
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<IActionResult>DelteEmployeeById(int employeeid)
        {
            try
            {
                await iemployee.DelteEmployeeById(employeeid);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, $"An Error Occurred {e.Message}");
            }
        }
    }
}
