using LightSwitchApplication.Implementation;
using eSkeleton.Ria.Service.SystemService;
using eSkeleton.Ria.Service.SystemServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.EntityClient;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Web.Configuration;


namespace eSkeleton.Ria
{


    public class SystemService : DomainService
    {

        #region Business Classes

        private MenuBusiness menuBusiness = new MenuBusiness();
        private SecurityBusiness securityBusiness = new SecurityBusiness();
        private EntityBusiness entityBusiness = new EntityBusiness();

        #endregion

        #region User Details

        [Query(IsDefault = true)]
        public IQueryable<UserDetail> UserDetails()
        {

            return
                securityBusiness.getUserDetails();

        }

        [Insert]
        public void InsertUserDetail(UserDetail userDetail)
        {
            securityBusiness.insertUserDetail(userDetail);
        }

        [Update]
        public void UpdateUserDetail(UserDetail userDetail)
        {
            securityBusiness.updateUserDetail(userDetail);
        }

        [Delete]
        public void DeleteUserDetail(UserDetail userDetail)
        {
            securityBusiness.deleteUserDetail(userDetail);
        }

        #endregion

        #region Role Detail

        [Query(IsDefault = true)]
        public IQueryable<RoleDetail> RoleDetails()
        {

            return
                securityBusiness.getRoleDetails();

        }

        [Insert]
        public void InsertRoleDetail(RoleDetail roleDetail)
        {
            securityBusiness.insertRoleDetail(roleDetail);
        }

        [Delete]
        public void DeleteRoleDetail(RoleDetail roleDetail)
        {
            securityBusiness.deleteRoleDetail(roleDetail);
        }

        #endregion

        #region Permission Detail

        [Query(IsDefault = true)]
        public IQueryable<PermissionDetail> PermissionDetails()
        {

            return
                securityBusiness.getPermissionDetails();

        }

        #endregion

        #region Role Permission Detail

        [Query(IsDefault = true)]
        public IQueryable<RolePermissionDetail> RolePermissionDetails()
        {

            return
                securityBusiness.getRolePermissionDetails();

        }

        [Insert]
        public void InsertRolePermissionDetail(RolePermissionDetail rolePermissionDetail)
        {

            securityBusiness.insertRolePermissionDetail(rolePermissionDetail);

        }

        [Delete]
        public void DeleteRolePermissionDetail(RolePermissionDetail rolePermissionDetail)
        {

            securityBusiness.deleteRolePermissionDetail(rolePermissionDetail);

        }

        #endregion

        #region Role User Detail

        [Query(IsDefault = true)]
        public IQueryable<RoleUserDetail> RoleUserDetails()
        {

            return
                securityBusiness.getRoleUserDetails();

        }

        [Insert]
        public void InsertRoleUserDetail(RoleUserDetail roleUserDetail)
        {

            securityBusiness.insertRoleUserDetail(roleUserDetail);

        }

        [Delete]
        public void DeleteRoleUserDetail(RoleUserDetail roleUserDetail)
        {

            securityBusiness.deleteRoleUserDetail(roleUserDetail);

        }

        #endregion

        #region Menus

        [Query(IsDefault = true)]
        public IQueryable<MenuDetail> MenuDetails()
        {

            return
                menuBusiness.getMenuDetails();

        }

        [Query(IsDefault = false)]
        public IEnumerable<MenuDetail> MasterMenus()
        {

            return
                menuBusiness.getMasterMenus();

        }

        /// <summary>
        /// Return all childrens menu of parentId
        /// </summary>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        [Query(IsDefault = false)]
        public IQueryable<MenuDetail> ChildrenMenus(int? idMenu)
        {

            return
                menuBusiness.getChildrenMenus(idMenu);

        }

        #endregion

        #region Entity Details

        [Query(IsDefault=true)]
        public IQueryable<EntityDetail> EntityDetails()
        {
            return null;
        }

        public EntityDetail EntityDetailByName(string entityName)
        {

            return
                entityBusiness.getEntityDetails(entityName);

        }

        #endregion

        /// <summary>
        /// Method to paging LS work;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        protected override int Count<T>(IQueryable<T> query)
        {
            return query.Count();
        }

    }

}
