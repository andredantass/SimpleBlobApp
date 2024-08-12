using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Logging;
using SimpleBlogApp.Abstraction.DTO;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.Domain.Entities;
using SimpleBlogApp.Infra.Data.Repository.Interfaces;

namespace SimpleBlogApp.Application.Services
{
    public class UserClientService : IUserClientService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserClientService> _logger;
        public UserClientService(IUserRepository userRepository,
                                 ILogger<UserClientService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        
        public async Task<string> CreateUser(UserRequest request)
        {
            var user = new User()
            {
                Name = request.Name,
                SecondName = request.SecondName,
                Document = request.Document,
                Email = request.Email,
                Nickname = request.Nickname,
                Password = request.Password,

            };
            try
            {
                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();
                return user.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "";

            }
        }

        public Task<List<UserResponse>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> CheckCredentials(UserRequest request)
        {
            var userFound = await _userRepository.GetByCredentials(request.Nickname, request.Password);
            
            if (userFound != null)
            {
                return new UserResponse()
                {
                    Name = userFound.Name,
                    Email = userFound.Email,
                    Document = userFound.Document
                };
            }

            return await Task.FromResult(new UserResponse());
        }
        
    }
}
