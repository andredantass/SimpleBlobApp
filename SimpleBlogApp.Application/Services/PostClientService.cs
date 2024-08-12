using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleBlogApp.Abstraction.DTO;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.Domain.Entities;
using SimpleBlogApp.Infra.Data.Repository;
using SimpleBlogApp.Infra.Data.Repository.Interfaces;
using System.Linq;

namespace SimpleBlogApp.Application.Services
{
    public class PostClientService : IPostClientService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<PostClientService> _logger;
        public PostClientService(IPostRepository postRepository,
                    IUserRepository userRepository,     
            ILogger<PostClientService> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<string> CreatePost(PostRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user is null)
                return "The UserId does not exists!";

            var post = new Post()
            {
                Content = request.Content,
                Date = DateTime.Now,
                UserId = request.UserId,
                Title = request.Title
            };
            try
            {
                await _postRepository.AddAsync(post);
                await _postRepository.SaveChangesAsync();
                return post.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "";

            }
        }

        public async Task<bool> DeletePost(string postId)
        {
            try
            {
                var deletePost = await _postRepository.GetByIdAsync(postId);

                if (deletePost == null)
                    return false;

                 _postRepository.Delete(deletePost);
                await _postRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<PostResponse>> GetAllPostsByUserId(string userId)
        {
            try
            {
                var posts = await _postRepository.GetAllPostByUserId(userId);

                var postResponse = new List<PostResponse>();

                foreach (var post in posts)
                {
                    postResponse.Add(new PostResponse()
                    {
                        Content = post.Content,
                        Date = post.Date,
                        UserId = post.UserId,
                        Title = post.Title
                    });
                }

                return postResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
 
            }

            return await Task.FromResult(new List<PostResponse>());
        }

        public async Task<bool> UpdatePost(PostRequest request)
        {
            try
            {
                var postUpdate = await _postRepository.GetByIdAsync(request.PostId);

                if (postUpdate == null)
                    return false;

                postUpdate.Content = request.Content;
                postUpdate.Title = request.Title;
                postUpdate.Date = DateTime.Now;

                _postRepository.Update(postUpdate);
                await _postRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
