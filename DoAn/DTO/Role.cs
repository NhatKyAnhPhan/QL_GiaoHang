using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class Role
    {
        private string roleId,roleName;
        public Role(string roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;
        }
        public Role()
        {

        }

        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
