using DMS.Core.Dto;
using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{

    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService service;
        private readonly IEmployeeService eService;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public UserController(IUserService service, IEmployeeService EService, IWebHostEnvironment hostingEnvironment)
        {
            this.service = service;
            this.eService = EService;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/login/validate")]
        public async Task<ActionResult> requestToken([FromBody] LoginRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                var user = await service.IsAuthenticated(request);
                if (!string.IsNullOrEmpty(service.Token))
                {                    
                    var data = new { token = service.Token, user = user };
                    return Ok(data);
                }

                return getResponse(new Exception("Username or password is incorrect."));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        
        [Route("~/api/user/detail/{employeeid}")]
        [HttpGet]
        public async Task<ActionResult> getUserDetail(string employeeid)
        {
            try
            { 
                return getResponse(await service.getUserDetail(employeeid));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [AllowAnonymous]
        [Route("~/api/user/credential/detail/{employeeid}")]
        [HttpGet]
        public async Task<ActionResult> getUserCredentialDetail(string employeeid)
        {
            try
            {
                return getResponse(await service.getUserCredentialInfo(employeeid));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        // PASSWORD CHANGE
        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/password/change")]
        public async Task<ActionResult> passwordChange([FromBody] LoginRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));
                return getResponse(await service.updateUserPassword(request));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [Route("~/api/user/depot/location")]
        [HttpGet]
        public async Task<ActionResult> getdepotLocation()
        {
            try
            {
                return getResponse(await service.getCurrentLocation());
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        //user permission

    
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/user/privileged/menu/{EmployeeCode}")]
        public async Task<ActionResult> getDMSUserPrivilegedMenu(string EmployeeCode)
        {
            try
            {
                return getResponse(await service.getDMSUserPrivilegedMenuList(EmployeeCode));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

    }
}
