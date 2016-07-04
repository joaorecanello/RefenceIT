/// <reference path="~/GeneratedArtifacts/viewModel.js" />


myapp.BrowseRoleDetailSearches.refButtonSelectRoleDetail_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {
        contentItem.screen.RoleDetails = contentItem.data;
        myapp.commitChanges();
    });

};