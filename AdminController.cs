using Elite_HR.Helper;
using Elite_HR.Interface;
using Elite_HR.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite_HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminInterface iadmininterface;
        public AdminController(IAdminInterface madminInterface)
        {
            iadmininterface = madminInterface;
        }
        [HttpPost("AdminLogin")]
        public RetObj AdminLogin(string username,string password)
        {
            return iadmininterface.AdminLogin(username,password);
        }
    }
}
