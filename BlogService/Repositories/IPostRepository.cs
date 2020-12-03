using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface IPostRepository
    {
        ResultPaginationDto<PostDto> GetPosts(PaginationDto search);
        PostDto GetPostByID(int customerId);
        void InsertPost(PostDto entity);
        void DeletePost(int entityId);
        void UpdatePost(PostDto entity);
        void Save();
    }
}
