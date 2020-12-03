using BlogService.Dto;
using BlogService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Implementation
{
    public class PostJsonReposiotry : IPostRepository
    {
        public void DeletePost(int entityrId)
        {
            throw new NotImplementedException();
        }

        public PostDto GetPostByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public ResultPaginationDto<PostDto> GetPosts(PaginationDto search)
        {
            throw new NotImplementedException();
        }

        public void InsertPost(PostDto entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(PostDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
