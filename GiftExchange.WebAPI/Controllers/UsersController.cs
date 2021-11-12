using System;
using System.Collections.Generic;
using AutoMapper;
using GiftExchange.DataAccess;
using GiftExchange.WebAPI.Helpers;
using GiftExchange.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftExchange.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<User> GetUsers()
        {
            return _mapper.Map<IEnumerable<User>>(_userRepository.GetAll());
        }

        [HttpGet("{userId}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser(int userId)
        {
            var user = _userRepository.Get(userId);

            return user is null
                ? NotFound()
                : Ok(_mapper.Map<User>(user));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult CreateUser(UserForCreation userForCreation)
        {
            var user = _userRepository.Get(userForCreation.Email);
            if (user is not null)
            {
                // User exists already. Return HTTP 303 SeeOther
                return HttpStatusResults.SeeOtherStatus(this, "GetUser", new { userId = user.Id });
            }

            user = _mapper.Map<DataAccess.Entities.User>(userForCreation);

            // Initial values
            user.IsVerified = false;
            user.RegistrationDate = DateTime.UtcNow;

            _userRepository.Add(user);
            _userRepository.Save();

            var userToReturn = _mapper.Map<User>(user);

            return CreatedAtRoute("GetUser", new { userId = user.Id }, userToReturn);
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult UpdateUser(int userId, UserForCreation userForUpdate)
        {
            var existingUser = _userRepository.Get(userForUpdate.Email);
            if (existingUser is not null)
            {
                // User exists already. Return HTTP 303 SeeOther
                return HttpStatusResults.SeeOtherStatus(this, "GetUser", new { userId = existingUser.Id });
            }

            var user = _userRepository.Get(userId);
            if (user is null)
            {
                return NotFound();
            }

            user.Email = userForUpdate.Email;
            _userRepository.Save();

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int userId)
        {
            var user = _userRepository.Get(userId);

            if (user is null)
            {
                return NotFound();
            }

            _userRepository.Remove(user);
            _userRepository.Save();

            return NoContent();
        }
    }
}
