using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Controllers.Connection
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ConnectionController : ControllerBase
    {
        private readonly IConnectionService _connectionService;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<ConnectionController> _localizer;

        public ConnectionController(IConnectionService connectionService, IConfiguration Configuration, IStringLocalizer<ConnectionController> localizer)
        {
            _connectionService = connectionService;
            _configuration = Configuration;
            _localizer = localizer;
        }

    }
}
