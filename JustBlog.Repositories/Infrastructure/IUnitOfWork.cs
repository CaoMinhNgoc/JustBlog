using JustBlog.Repositories.CategoryRepository;
using JustBlog.Repositories.CommentRepository;
using JustBlog.Repositories.PostRepository;
using JustBlog.Repositories.RoleRepository;
using JustBlog.Repositories.TagRepository;
using JustBlog.Repositories.UserRepository;

namespace JustBlog.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IPostRepository PostRepository { get; }
        public ITagRepository TagRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        void SaveChange();
    }
}
