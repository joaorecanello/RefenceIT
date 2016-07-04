/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.RoleDetailsSearch.refButtonSelectRoleDetail_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {
        contentItem.screen.RoleDetail = contentItem.data;
        myapp.commitChanges();
    });
    $(element).css('text-align', 'center');

};