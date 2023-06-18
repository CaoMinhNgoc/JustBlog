using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(JustBlogContext db) : base(db)
        {
        }

        public IList<IdentityRole<Guid>> GetRoles(Guid id)
        {
            var roleIds = _db.UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.RoleId).ToList();
            return _db.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
        }
        public void AddRoles(Guid id, IList<Guid> roleIds)
        {
            var userRoles = roleIds.Select(roleId => new IdentityUserRole<Guid>
            {
                UserId = id,
                RoleId = roleId
            });
            _db.UserRoles.AddRange(userRoles);
        }

        public void DeleteRoles(Guid id)
        {
            _db.UserRoles.RemoveRange(_db.UserRoles.Where(ur => ur.UserId == id));
        }
    }
}
