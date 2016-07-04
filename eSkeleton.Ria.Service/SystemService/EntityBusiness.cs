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
    public class EntityBusiness
    {

        private IUser _currentUser = ApplicationProvider.Current.User;

        public EntityDetail getEntityDetails(string entityName)
        {

            EntityDetail _entityDetail = new EntityDetail();

            switch (entityName)
            {
                case "Ad":
                    _entityDetail.Name = "Ad";
                    _entityDetail.CanDelete = Ads_DeletePermissions();
                    _entityDetail.CanRead = Ads_ReadPermissions();
                    _entityDetail.CanUpdate = Ads_UpdatePermissions();
                    _entityDetail.CanInsert = Ads_InsertPermissions();
                    break;

                case "ResourceEnabling":
                    _entityDetail.Name = "ResourceEnabling";
                    _entityDetail.CanDelete = ResourceEnablings_DeletePermissions();
                    _entityDetail.CanRead = ResourceEnablings_ReadPermissions();
                    _entityDetail.CanUpdate = ResourceEnablings_UpdatePermissions();
                    _entityDetail.CanInsert = ResourceEnablings_InsertPermissions();
                    break;

                case "QuestionnaireTemplate":
                    _entityDetail.Name = "QuestionnaireTemplate";
                    _entityDetail.CanDelete = QuestionnaireTemplates_DeletePermissions();
                    _entityDetail.CanRead = QuestionnaireTemplates_ReadPermissions();
                    _entityDetail.CanUpdate = QuestionnaireTemplates_UpdatePermissions();
                    _entityDetail.CanInsert = QuestionnaireTemplates_InsertPermissions();
                    break;

                case "Survey":
                    _entityDetail.Name = "Survey";
                    _entityDetail.CanDelete = Surveys_DeletePermissions();
                    _entityDetail.CanRead = Surveys_ReadPermissions();
                    _entityDetail.CanUpdate = Surveys_UpdatePermissions();
                    _entityDetail.CanInsert = Surveys_InsertPermissions();
                    break;

                case "ResourceVisualization":
                    _entityDetail.Name = "ResourceVisualization";
                    _entityDetail.CanDelete = ResourceVisualizations_DeletePermissions();
                    _entityDetail.CanRead = ResourceVisualizations_ReadPermissions();
                    _entityDetail.CanUpdate = ResourceVisualizations_UpdatePermissions();
                    _entityDetail.CanInsert = ResourceVisualizations_InsertPermissions();
                    break;


                default:
                    break;
            }

            return
                _entityDetail;

        }

        #region ad acceptances

        public bool AdAcceptances_CanRead()
        {

            return
                _currentUser.HasPermission(Permissions.Ad_CanDelete) ||
                _currentUser.HasPermission(Permissions.AdReport_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool AdAcceptances_CanDelete()
        {

            return
                _currentUser.HasPermission(Permissions.Ad_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool AdAcceptances_CanInsert()
        {

            return
                _currentUser.HasPermission(Permissions.AdAcceptances_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool AdAcceptances_CanUpdate()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region ad permissions

        public bool Ads_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Ad_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Ads_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Ad_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Ads_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Ad_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Ads_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Ad_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
               _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region answers permissions

        public bool Answers_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Answers_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Answer_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Answers_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Answers_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SurveyReport_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region menus

        public bool Menus_CanRead()
        {

            return
                true;

        }

        public bool Menus_CanDelete()
        {

            return
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Menus_CanInsert()
        {

            return
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Menus_CanUpdate()
        {

            return
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }


        #endregion

        #region questionalternatives permissions

        public bool QuestionAlternatives_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternatives_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternatives_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternatives_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questionalternativetemplates permissions

        public bool QuestionAlternativeTemplates_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternativeTemplates_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternativeTemplates_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionAlternativeTemplates_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questionnaireresponses permissions

        public bool QuestionnaireResponses_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireResponses_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireResponse_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireResponses_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireResponses_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questionnaires permissions

        public bool Questionnaires_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questionnaires_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questionnaires_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questionnaires_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questionnairetemplates permissions

        public bool QuestionnaireTemplates_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireTemplates_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireTemplates_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionnaireTemplates_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region question permissions

        public bool Questions_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questions_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questions_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Questions_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questiontemplates permissions

        public bool QuestionTemplates_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTemplates_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTemplates_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTemplates_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region questiontypes permissions

        public bool QuestionTypes_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTypes_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTypes_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool QuestionTypes_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanRead) ||
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanInsert) ||
                _currentUser.HasPermission(Permissions.QuestionnaireTemplate_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region resouceenablings permissions

        public bool ResourceEnablings_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.ResourceEnabling_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceEnablings_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.ResourceEnabling_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceEnablings_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.ResourceEnabling_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceEnablings_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.Ad_CanRead) ||
                _currentUser.HasPermission(Permissions.Ad_CanInsert) ||
                _currentUser.HasPermission(Permissions.Ad_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region resoucevisualizations permissions

        public bool ResourceVisualizations_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceVisualizations_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.ResourceVisualization_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceVisualizations_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool ResourceVisualizations_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.AdReport_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region surveyresponses permissions

        public bool SurveyResponses_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool SurveyResponses_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SurveyResponse_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool SurveyResponses_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool SurveyResponses_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SurveyReport_CanRead) ||
                _currentUser.HasPermission(Permissions.SurveyResponse_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region survey permissions

        public bool Surveys_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.Survey_CanDelete) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Surveys_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanInsert) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Surveys_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Surveys_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SurveyReport_CanRead) ||
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion

        #region system permissions

        public bool Systems_DeletePermissions()
        {
            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Systems_InsertPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Systems_UpdatePermissions()
        {

            return
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        public bool Systems_ReadPermissions()
        {

            return
                _currentUser.HasPermission(Permissions.Survey_CanRead) ||
                _currentUser.HasPermission(Permissions.Ad_CanRead) ||
                _currentUser.HasPermission(Permissions.ResourceEnabling_CanInsert) ||
                _currentUser.HasPermission(Permissions.ResourceEnabling_CanUpdate) ||
                _currentUser.HasPermission(Permissions.SecurityAdministration) ||
                _currentUser.HasPermission(Permissions.SystemAdministration);

        }

        #endregion



    }


}
