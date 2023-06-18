using JustBlog.Core.Database;
using JustBlog.Repositories.CategoryRepository;
using JustBlog.Repositories.CommentRepository;
using JustBlog.Repositories.PostRepository;
using JustBlog.Repositories.RoleRepository;
using JustBlog.Repositories.TagRepository;
using JustBlog.Repositories.UserRepository;

namespace JustBlog.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JustBlogContext context;
        private ICategoryRepository categoryRepository;
        private ICommentRepository commentRepository;
        private IPostRepository postRepository;
        private ITagRepository tagRepository;
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;

        public UnitOfWork(JustBlogContext context = null)
        {
            this.context = context ?? new JustBlogContext();
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository.CategoryRepository(context);
                return categoryRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository.CommentRepository(context);
                return commentRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository.PostRepository(context);
                return postRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository.TagRepository(context);
                return tagRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository.RoleRepository(context);
                return roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository.UserRepository(context);
                return userRepository;
            }
        }

        private bool disposed = false;

        public void SaveChange()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
