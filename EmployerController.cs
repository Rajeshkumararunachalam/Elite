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
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerInterface iemployer;
        private readonly IConfiguration _iconfigure;
        public EmployerController(IEmployerInterface memployer, IConfiguration iconfigure)
        {
            iemployer = memployer;
            _iconfigure = iconfigure;
        }
        [HttpPost("AddOrUpdateEmployerLogin")]
        public async Task<ActionResult<RetObj>> EmployerLogin(EmployerModel employermodel)
        {
            try
            {
                var result = await iemployer.EmployerLogin(employermodel);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occured{e.Message}");
            }
        }
        [HttpPost("EmployerMobileLogin")]
        public RetObj MobileLogin(EmployerModel employer, string mobileno)
        {
            return iemployer.MobileLogin(employer, mobileno);
        }
        [HttpGet("GetAllEmployer")]
        public async Task<IActionResult> GetAllEmployer()
        {
            try
            {
                List<EmployerModel> employer = await iemployer.GetAllEmployer();
                if (employer != null)
                {
                    return Ok(employer);
                }
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error Occured {e.Message}");
            }
        }
        [HttpGet("GetEmployerById")]
        public async Task<IActionResult> GetEmployerById(int employerid)
        {
            try
            {
                EmployerModel employee = await iemployer.GetEmployerById(employerid);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occured {e.Message}");
            }
        }
        [HttpDelete("DeleteEmployerById")]
        public async Task<IActionResult> DelteEmployerById(int employerid)
        {
            try
            {
                await iemployer.DelteEmployerById(employerid);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An Error Occurred {e.Message}");
            }
        }
    }
}
