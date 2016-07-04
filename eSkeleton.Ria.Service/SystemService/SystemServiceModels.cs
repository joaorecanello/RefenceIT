using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace eSkeleton.Ria.Service.SystemServiceModels
{

    public class MenuDetail
    {

        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public string OnClick { get; set; }
        public bool HasChildren { get; set; }
        public string ParentTitle { get; set; }
        public Int16 Order { get; set; }
        public string Description { get; set; }
        public bool IsSecurity { get; set; }
        public bool IsSystem { get; set; }

    }

    public class PermissionDetail
    {

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        [Include]
        [Association("RolePermission", "Id", "PermissionId", IsForeignKey = false)]
        public IQueryable<RolePermissionDetail> RolePermission { get; set; }

    }

    public class RolePermissionDetail
    {

        [Key]
        public string PermissionId { get; set; }
        [Key]
        public string RoleName { get; set; }

        [Association("RolePermission", "PermissionId", "Id", IsForeignKey=true)]
        public PermissionDetail PermissionDetail { get; set; }
        [Association("RolePermissionRole", "RoleName", "Name", IsForeignKey = true)]
        public RoleDetail RoleDetail { get; set; }

    }

    public class RoleUserDetail
    {

        [Key]
        public string RoleName { get; set; }
        [Key]
        public string UserName { get; set; }

        [Association("RoleUserRole", "RoleName", "Name", IsForeignKey = true)]
        public RoleDetail RoleDetail { get; set; }
        [Association("RoleUser", "UserName", "UserName", IsForeignKey = true)]
        public UserDetail UserDetail { get; set; }

    }

    public class RoleDetail
    {

        [Key]
        public string Name { get; set; }

        [Include]
        [Association("RolePermissionRole", "Name", "RoleName", IsForeignKey = false)]
        public IQueryable<RolePermissionDetail> RolePermissionRole { get; set; }

        [Include]
        [Association("RoleUserRole", "Name", "RoleName", IsForeignKey = false)]
        public IQueryable<RoleUserDetail> RoleUserRole { get; set; }


    }

    public class UserDetail
    {

        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        [Include]
        [Association("RoleUser", "UserName", "UserName", IsForeignKey = false)]
        public IQueryable<RoleUserDetail> RoleUser { get; set; }

    }

    public class EntityDetail
    {
        [Key]
        public string Name { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanInsert { get; set; }

    }

}
