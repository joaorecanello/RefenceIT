/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.PermissionDetailsSearch.refButtonSelectPermission_render = function (element, contentItem) {
    // call ReferenceIt Helper to render AddButton, Small
    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {
        contentItem.screen.PermissionDetail = contentItem.data;
        myapp.commitChanges();
    });

};