using eSkeleton.Ria.Service.SystemServiceModels;
using Microsoft.LightSwitch.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.LightSwitch.Security;
using LightSwitchApplication;
using System.Transactions;


namespace eSkeleton.Ria.Service.SystemService
{
    public class MenuBusiness
    {

        public IQueryable<MenuDetail> getMenuDetails()
        {

            var _currentUser = ApplicationProvider.Current.User;
            List<MenuDetail> _listMenuDetails = null;

            if (_currentUser.IsAuthenticated)
            {

                if (_currentUser.HasPermission(Permissions.SecurityAdministration))
                {

                    using (ApplicationDataConnection _applicationDataConnection = new ApplicationDataConnection())
                    {

                        using (TransactionScope transaction = new TransactionScope())
                        {
                            _listMenuDetails =
                                (from Menu in _applicationDataConnection.ApplicationDataContext.Menus
                                 select new MenuDetail()
                                 {
                                     Icon = Menu.Icon,
                                     IconColor = Menu.IconColor,
                                     Id = Menu.Id,
                                     Label = Menu.Label,
                                     Description = Menu.Description,
                                     OnClick = Menu.OnClick,
                                     HasChildren = (
                                     from MenuChildren in _applicationDataConnection.ApplicationDataContext.Menus
                                     where MenuChildren.MenuPai == Menu
                                     select MenuChildren).Count() > 0
                                 }).ToList();
                        }

                    }

                }

            }

            return
                _listMenuDetails.AsQueryable();

        }

        public IQueryable<MenuDetail> getMasterMenus()
        {

            var _currentUser = ApplicationProvider.Current.User;
            List<MenuDetail> _listMasterMenus = null;

            if (_currentUser.IsAuthenticated)
            {

                using (ApplicationDataConnection _applicationDataConnection = new ApplicationDataConnection())
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {

                        _listMasterMenus =
                            (from Menu in _applicationDataConnection.ApplicationDataContext.Menus
                             where Menu.IsMaster == true
                             select new MenuDetail()
                             {
                                 Icon = Menu.Icon,
                                 IconColor = Menu.IconColor,
                                 Id = Menu.Id,
                                 Label = Menu.Label,
                                 OnClick = Menu.OnClick,
                                 Order = Menu.Order,
                                 Description = Menu.Description,
                                 IsSecurity = Menu.IsSecurity.HasValue ? Menu.IsSecurity.Value : false,
                                 IsSystem = Menu.IsSystem.HasValue ? Menu.IsSystem.Value : false,
                                 HasChildren = (
                                    from MenuChildren in _applicationDataConnection.ApplicationDataContext.Menus
                                    where MenuChildren.MenuPai == Menu
                                    select MenuChildren).Count() > 0
                             }).ToList();

                            if (!(_currentUser.HasPermission(Permissions.SystemAdministration)))
                            {
                                _listMasterMenus = _listMasterMenus.Where(lmm => !lmm.IsSystem).ToList();

                                if (!(_currentUser.HasPermission(Permissions.SecurityAdministration)))
                                {
                                    _listMasterMenus = _listMasterMenus.Where(lmm => !lmm.IsSecurity).ToList();

                                }

                            }


                            for (int i = _listMasterMenus.Count-1; i >= 0; i--)
                            {

                                if ((_listMasterMenus[i].IsSecurity) || (_listMasterMenus[i].IsSystem))
                                    continue;

                                switch (_listMasterMenus[i].Id)
                                {

                                    #region master menu Ad

                                    case 1: // master Ad Menu;
                                        if (!
                                            (_currentUser.HasPermission(Permissions.Ad_CanDelete) ||
                                             _currentUser.HasPermission(Permissions.Ad_CanInsert) ||
                                             _currentUser.HasPermission(Permissions.Ad_CanUpdate) ||
                                             _currentUser.HasPermission(Permissions.Ad_CanRead) ||
                                             _currentUser.HasPermission(Permissions.AdReport_CanRead) ||
                                             _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                             _currentUser.HasPermission(Permissions.SystemAdministration))) _listMasterMenus.RemoveAt(i);
                                        break;

                                    #endregion

                                    #region master menu Survey

                                    case 2: // master Survey Menu;
                                        if (!
                                            (_currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                                             _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                                             _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanDelete) ||
                                             _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead)   ||
                                             _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                                             _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                                             _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                                             _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                                             _currentUser.HasPermission(Permissions.SurveyReport_CanRead) ||
                                             _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                             _currentUser.HasPermission(Permissions.SystemAdministration))) _listMasterMenus.RemoveAt(i);
                                        break;


                                    #endregion

                                    #region master menu System Helper

                                    case 1010:
                                        if (!
                                             _currentUser.HasPermission(Permissions.SystemAdministration)) _listMasterMenus.RemoveAt(i);
                                        break;

                                    #endregion

                                    default:
                                        break;

                                }


                            }


                        transaction.Complete();

                    }

                }

            }

            return
                _listMasterMenus.AsQueryable();

        }

        public IQueryable<MenuDetail> getChildrenMenus(int? idMenu)
        {

            var _currentUser = ApplicationProvider.Current.User;
            List<MenuDetail> _listChildrenMenus = null;

            if (_currentUser.IsAuthenticated)
            {

                using (ApplicationDataConnection _applicationDataConnection = new ApplicationDataConnection())
                {

                    using (TransactionScope transaction = new TransactionScope())
                    {

                        // load a list of menus children;
                        _listChildrenMenus =
                            (from Menu in _applicationDataConnection.ApplicationDataContext.Menus.Include("MenuPai")
                             where Menu.IsMaster == false
                                && Menu.MenuPai.Id == idMenu
                             select new MenuDetail()
                             {
                                 Icon = Menu.Icon,
                                 IconColor = Menu.IconColor,
                                 Id = Menu.Id,
                                 Label = Menu.Label,
                                 Description = Menu.Description,
                                 OnClick = Menu.OnClick,
                                 Order = Menu.Order,
                                 ParentTitle = Menu.MenuPai.Label,
                                 IsSecurity = Menu.IsSecurity.HasValue ? Menu.IsSecurity.Value : false,
                                 IsSystem = Menu.IsSystem.HasValue ? Menu.IsSystem.Value : false,
                                 HasChildren = (
                                    from MenuChildren in _applicationDataConnection.ApplicationDataContext.Menus
                                    where MenuChildren.MenuPai == Menu
                                    select MenuChildren).Count() > 0
                             }).ToList();

                        if (!(_currentUser.HasPermission(Permissions.SystemAdministration)))
                        {
                            _listChildrenMenus = _listChildrenMenus.Where(lmm => !lmm.IsSystem).ToList();

                            if (!(_currentUser.HasPermission(Permissions.SecurityAdministration)))
                            {
                                _listChildrenMenus = _listChildrenMenus.Where(lmm => !lmm.IsSecurity).ToList();
                            }

                        }

                        for (int i = _listChildrenMenus.Count - 1; i >= 0; i--)
                        {

                            if ((_listChildrenMenus[i].IsSecurity) || (_listChildrenMenus[i].IsSystem))
                                continue;


                            switch (_listChildrenMenus[i].Id)
                            {

                                #region survey menu

                                case 4: // survey
                                    if (!
                                        (_currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                                         _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                                         _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                                         _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                                         _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                         _currentUser.HasPermission(Permissions.SystemAdministration))) _listChildrenMenus.RemoveAt(i);
                                    break;


                                #endregion

                                #region questionnaire menu

                                case 5: // questionnaire
                                    if (!
                                        (_currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                                         _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                                         _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanDelete) ||
                                         _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead) ||
                                         _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                         _currentUser.HasPermission(Permissions.SystemAdministration))) _listChildrenMenus.RemoveAt(i);
                                    break;


                                #endregion

                                #region survey report menu

                                case 1013: // survey report
                                    if (!
                                        (_currentUser.HasPermission(Permissions.SurveyReport_CanRead) ||
                                         _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                         _currentUser.HasPermission(Permissions.SystemAdministration))) _listChildrenMenus.RemoveAt(i);
                                    break;

                                #endregion

                                #region ad report menu

                                case 1014: // ad report
                                    if (!
                                        (_currentUser.HasPermission(Permissions.AdReport_CanRead) ||
                                         _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                         _currentUser.HasPermission(Permissions.SystemAdministration))) _listChildrenMenus.RemoveAt(i);
                                    break;

                                #endregion

                                #region ad menu

                                case 1015: // ad
                                    if (!
                                        (_currentUser.HasPermission(Permissions.Ad_CanDelete) ||
                                         _currentUser.HasPermission(Permissions.Ad_CanInsert) ||
                                         _currentUser.HasPermission(Permissions.Ad_CanUpdate) ||
                                         _currentUser.HasPermission(Permissions.Ad_CanRead)   ||
                                         _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                                         _currentUser.HasPermission(Permissions.SystemAdministration))) _listChildrenMenus.RemoveAt(i);
                                    break;


                                #endregion

                                default:
                                    break;

                            }


                        }

                        // create a back button to add in menu list;
                        MenuDetail _backMenuDetail = new MenuDetail()
                        {
                            HasChildren = false,
                            Icon = "fa fa-hand-o-left",
                            IconColor = "clgreydark",
                            Id = 0,
                            Label = "Voltar",
                            OnClick = "navigateBack"
                        };

                        // insert back button in first item of list;
                        _listChildrenMenus.Insert(0, _backMenuDetail);

                        transaction.Complete();

                    }

                }

            }

            return
                _listChildrenMenus.AsQueryable().OrderBy(md => md.Order);

        }

    }

}
