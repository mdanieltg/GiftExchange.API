using System;
using System.Collections.Generic;
using AutoMapper;
using GiftExchange.DataAccess;
using GiftExchange.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftExchange.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfilesController(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository =
                userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
