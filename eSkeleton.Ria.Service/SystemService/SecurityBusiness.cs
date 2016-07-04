using eSkeleton.Ria.Service.SystemServiceModels;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Base;
using Microsoft.LightSwitch.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace eSkeleton.Ria.Service.SystemService
{
    public class SecurityBusiness
    {

        #region User Detail

        public IQueryable<UserDetail> getUserDetails()
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                IEnumerable<Microsoft.LightSwitch.Security.UserRegistration> _listUsers =
                  workspace.SecurityData.UserRegistrations.GetQuery().Execute();

                return
                    _listUsers.Select(u =>
                        new UserDetail
                        {

                            FullName = u.FullName,
                            UserName = u.UserName

                        }).AsQueryable();
            }
            finally
            {
                Transaction.Current = currentTrx;
            }
        }

        public void insertUserDetail(UserDetail userDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                UserRegistration newUserRegistration = workspace.SecurityData.UserRegistrations.AddNew();
                newUserRegistration.FullName = userDetail.FullName;
                newUserRegistration.Password = userDetail.Password;
                newUserRegistration.UserName = userDetail.UserName;
                workspace.SecurityData.SaveChanges();


            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void updateUserDetail(UserDetail userDetail)
        {


            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                UserRegistration newUserRegistration =
                    workspace.SecurityData
                        .UserRegistrations
                        .GetQuery()
                        .Execute()
                        .Where(u => u.UserName == userDetail.UserName)
                        .First();

                newUserRegistration.FullName = userDetail.FullName;
                newUserRegistration.Password = userDetail.Password;
                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void deleteUserDetail(UserDetail userDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                workspace.SecurityData
                    .UserRegistrations
                    .GetQuery()
                    .Execute()
                    .Where(u => u.UserName == userDetail.UserName)
                    .First()
                    .Delete();

                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        #endregion

        #region Role Detail

        public IQueryable<RoleDetail> getRoleDetails()
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                IEnumerable<Microsoft.LightSwitch.Security.Role> _listRoles = workspace.SecurityData.Roles.GetQuery().Execute();

                return
                    _listRoles.Select(r =>
                        new RoleDetail
                        {
                            Name = r.Name
                        }).AsQueryable();
            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void insertRoleDetail(RoleDetail roleDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                Role newRole = workspace.SecurityData.Roles.AddNew();
                newRole.Name = roleDetail.Name;
                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void deleteRoleDetail(RoleDetail roleDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();

                // delete Permissions associated to role
                var _permissionsToDelete = workspace.SecurityData
                    .RolePermissions
                    .GetQuery()
                    .Execute()
                    .Where(rp => rp.RoleName == roleDetail.Name);

                foreach (var PermissionToDelete in _permissionsToDelete)
	            {
                    PermissionToDelete.Delete();
	            }

                // delete users association with role;
                var _userRegistrationsToDelete = workspace.SecurityData
                    .RoleAssignments
                    .GetQuery()
                    .Execute()
                    .Where(ra => ra.RoleName == roleDetail.Name);

                foreach (var UserToDelete in _userRegistrationsToDelete)
                {
                    UserToDelete.Delete();
                }

                workspace.SecurityData
                    .Roles
                    .GetQuery()
                    .Execute()
                    .Where(r => r.Name == roleDetail.Name)
                    .First().Delete();

                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }


        }

        #endregion

        #region Permissions

        public IQueryable<PermissionDetail> getPermissionDetails()
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                IEnumerable<Microsoft.LightSwitch.Security.Permission> _listPermissions =
                  workspace.SecurityData.Permissions.GetQuery().Execute();

                return
                    _listPermissions.Select(p =>
                        new PermissionDetail
                        {
                            Id = p.Id,
                            Name = p.Name
                        }).AsQueryable();
            }
            finally
            {
                Transaction.Current = currentTrx;
            }
        }

        #endregion

        #region Role Permission

        public void insertRolePermissionDetail(RolePermissionDetail rolePermissionDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                RolePermission newRolePermission = workspace.SecurityData.RolePermissions.AddNew();
                newRolePermission.Permission = workspace.SecurityData.Permissions
                    .Where(p => p.Id == rolePermissionDetail.PermissionId).First();
                newRolePermission.PermissionId = rolePermissionDetail.PermissionId;
                newRolePermission.Role = workspace.SecurityData.Roles
                    .Where(r => r.Name == rolePermissionDetail.RoleName).First();
                newRolePermission.RoleName = rolePermissionDetail.RoleName;
                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void deleteRolePermissionDetail(RolePermissionDetail rolePermissionDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                workspace.SecurityData
                    .RolePermissions
                    .GetQuery()
                    .Execute()
                    .Where(rp => rp.PermissionId == rolePermissionDetail.PermissionId && rp.RoleName == rolePermissionDetail.RoleName)
                    .First()
                    .Delete();

                workspace.SecurityData.SaveChanges();


            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public IQueryable<RolePermissionDetail> getRolePermissionDetails()
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                IEnumerable<Microsoft.LightSwitch.Security.RolePermission> _listRolePermission =
                  workspace.SecurityData.RolePermissions.GetQuery().Execute();

                return
                    _listRolePermission.Select(rp =>
                        new RolePermissionDetail
                        {
                            PermissionDetail = new PermissionDetail() { Id = rp.Permission.Id, Name = rp.Permission.Name },
                            PermissionId = rp.PermissionId,
                            RoleDetail = new RoleDetail() { Name = rp.Role.Name },
                            RoleName = rp.RoleName
                        }).AsQueryable();
            }
            finally
            {
                Transaction.Current = currentTrx;
            }
        }

        #endregion

        #region Role User Detail

        public IQueryable<RoleUserDetail> getRoleUserDetails()
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                IEnumerable<Microsoft.LightSwitch.Security.RoleAssignment> _listRoleAssignment =
                  workspace.SecurityData.RoleAssignments.GetQuery().Execute();

                return
                    _listRoleAssignment.Select(ra =>
                        new RoleUserDetail
                        {
                            RoleDetail = new RoleDetail() { Name = ra.Role.Name },
                            RoleName = ra.RoleName,
                            UserDetail = new UserDetail() { FullName = ra.User.FullName, UserName = ra.User.UserName, Password = ra.User.Password },
                            UserName = ra.UserName
                        }).AsQueryable();
            }
            finally
            {
                Transaction.Current = currentTrx;
            }
        }

        public void insertRoleUserDetail(RoleUserDetail roleUserDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {
                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                RoleAssignment newRoleUserDetail = workspace.SecurityData.RoleAssignments.AddNew();

                newRoleUserDetail.UserName = roleUserDetail.UserName;
                newRoleUserDetail.RoleName = roleUserDetail.RoleName;

                newRoleUserDetail.User = workspace.SecurityData.UserRegistrations
                    .Where(u => u.UserName == roleUserDetail.UserName).First();

                newRoleUserDetail.Role = workspace.SecurityData.Roles
                    .Where(r => r.Name == roleUserDetail.RoleName).First();

                newRoleUserDetail.SourceAccount = newRoleUserDetail.User;

                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        public void deleteRoleUserDetail(RoleUserDetail roleUserDetail)
        {

            Transaction currentTrx = Transaction.Current;
            Transaction.Current = null;

            try
            {

                IDataWorkspace workspace = ApplicationProvider.Current.CreateDataWorkspace();
                workspace.SecurityData
                    .RoleAssignments
                    .GetQuery()
                    .Execute()
                    .Where(ra => ra.UserName == roleUserDetail.UserName && ra.RoleName == roleUserDetail.RoleName)
                    .First()
                    .Delete();

                workspace.SecurityData.SaveChanges();

            }
            finally
            {
                Transaction.Current = currentTrx;
            }

        }

        #endregion

    }
}
