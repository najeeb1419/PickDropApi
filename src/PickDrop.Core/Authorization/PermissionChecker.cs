using Abp.Authorization;
using PickDrop.Authorization.Roles;
using PickDrop.Authorization.Users;

namespace PickDrop.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
