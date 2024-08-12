using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlogApp.Abstraction.DTO;
using SimpleBlogApp.Abstraction.Request;

namespace SimpleBlogApp.Abstraction.Interface
{
    public interface IUserClientService
    {
        Task<UserResponse> GetUserById(int id);
        Task<string> CreateUser(UserRequest  request);
        Task<List<UserResponse>> GetAllUsers();
        Task<UserResponse> CheckCredentials(UserRequest request);
    }
}
