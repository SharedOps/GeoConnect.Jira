﻿using System.Collections.Generic;
using GeoConnectJiraServices.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Controllers
{

    [RoutePrefix("sp/jira")]
    public class AddUserController : ApiController
    {
        private readonly IUser _iUserService;

        public AddUserController(IUser iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpPost]
        [Route("adduser")]
        [ResponseType(typeof(AddUser))]
        public async Task<int> AddTag([FromBody] AddUser user)
        {
            return await _iUserService.AddUser(user);
        }



        [HttpGet]
        [Route("getusers")]
        [ResponseType(typeof(AddUser))]
        public async Task<IList<AddUser>> GetUsers()
        {
            return await _iUserService.GetUsers();
        }

    }
}
