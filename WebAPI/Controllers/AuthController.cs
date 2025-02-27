﻿using Business.Abstract;
using Entitites.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = _authService.Login(userLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            var userToRegister = _authService.Register(userRegisterDto);
            if (!userToRegister.Success)
            {
                return BadRequest(userToRegister.Message);
            }

            var result = _authService.CreateAccessToken(userToRegister.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addwhole")]
        public IActionResult AddWhole(UserRegisterDto[] users)
        {
            foreach (var item in users)
            {
                var result = _authService.Register(item);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

            }
            return Ok("eklendi");


        }
    }
}
