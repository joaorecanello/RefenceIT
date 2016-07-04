using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
using System.Linq.Expressions;
using System.Data.Entity;
using eSkeleton.Ria.Service.SystemService;


namespace LightSwitchApplication
{

    public partial class ApplicationDataService
    {

        #region menus permissions

        partial void Menus_Filter(ref Expression<Func<Menu, bool>> filter)
        {

            if (!this.Application.User.HasPermission(Permissions.SecurityAdministration))
            {
                filter = m => m.Id == -1;
            }

        }

        partial void Menus_CanDelete(ref bool result)
        {
            result =
                new EntityBusiness().Menus_CanDelete();
        }

        partial void Menus_CanInsert(ref bool result)
        {
            result = new EntityBusiness().Menus_CanInsert();
        }

        partial void Menus_CanUpdate(ref bool result)
        {
            result = new EntityBusiness().Menus_CanUpdate();
        }

        partial void Menus_CanRead(ref bool result)
        {
            result =
                new EntityBusiness().Menus_CanRead();

        }


        #endregion

    }
}
