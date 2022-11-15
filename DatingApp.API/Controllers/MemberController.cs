using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Route("api/members")]
    // [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _iMemberService;
        public MemberController(IMemberService iMemberService)
        {
            _iMemberService = iMemberService;
        }
        [HttpGet]
        public ActionResult<List<MemberDto>> Get()
        {
            return Ok(_iMemberService.GetMembers());
        }

        [HttpGet("{username}")]
        public ActionResult<MemberDto> Get(string username)
        {
            return Ok(_iMemberService.GetMemberByUsername(username));
        }
    }
}