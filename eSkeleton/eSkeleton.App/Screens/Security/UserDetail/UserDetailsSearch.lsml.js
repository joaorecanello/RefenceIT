/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.UserDetailsSearch.refButtonSelectUserDetail_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {
        contentItem.screen.UserDetail = contentItem.data;
        myapp.commitChanges();
    });

};

myapp.UserDetailsSearch.Search_postRender = function (element, contentItem) {
    // Write code here.
    $(element).addClass('firstFocus');

};