using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlogApp.Abstraction.DTO;
using SimpleBlogApp.Abstraction.Request;

namespace SimpleBlogApp.Abstraction.Interface
{
    public interface IPostClientService
    {
        Task<List<PostResponse>> GetAllPostsByUserId(string userId);
        Task<string> CreatePost(PostRequest request);
        Task<bool> DeletePost(string postId);
        Task<bool> UpdatePost(PostRequest request);
    }
}
