/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.UserDetailAddEdit.AddRole_execute = function (screen) {

    myapp.showRoleDetailsSearch({
        // beforeShown, prepare screen with empty question object;
        beforeShown: function (addEditScreen) {
            addEditScreen.RoleDetail = null;
        },

        afterClosed: function (searchScreen, navigationAction) {

            if (navigationAction == msls.NavigateBackAction.commit) {

                var newRoleUser = new myapp.RoleUserDetail();

                newRoleUser.setUserName(screen.UserDetail.UserName);
                newRoleUser.setUserDetail(screen.UserDetail);
                newRoleUser.setRoleDetail(searchScreen.RoleDetail);
                newRoleUser.setRoleName(searchScreen.RoleDetail.Name);
            }
        }
    });

};

myapp.UserDetailAddEdit.refButtonDelRoleUser_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.delButton, lsRefButtonSize.small, function () {

        msls.showMessageBox('Deseja excluir a permissão?', {
            title: 'Confirmar exclusão',
            buttons: msls.MessageBoxButtons.yesNo
        }).then(function (resultMessage) {
            if (resultMessage == msls.MessageBoxResult.yes) {
                contentItem.data.deleteEntity();
            }
        })

    });

    $(element).css('text-align', 'center');
};

myapp.UserDetailAddEdit.refButtonNewRole_render = function (element, contentItem) {

    // call ReferenceIt Helper to render AddButton, Small
    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {

        myapp.showRoleDetailsSearch({
            beforeShown: function (searchScreen) {
                searchScreen.RoleDetail = null;
            },

            afterClosed: function (searchScreen, navigationAction) {

                if (navigationAction == msls.NavigateBackAction.commit) {

                    var newRoleUserDetail = new myapp.RoleUserDetail();

                    newRoleUserDetail.setRoleDetail(searchScreen.RoleDetail);
                    newRoleUserDetail.setUserDetail(contentItem.data.UserDetail);
                    newRoleUserDetail.setRoleName(searchScreen.RoleDetail.Name);
                    newRoleUserDetail.setUserName(contentItem.data.UserDetail.UserName);


                }

            }

        });

    });


};

myapp.UserDetailAddEdit.UserDetail_Password_postRender = function (element, contentItem) {
    $(element).find("input").get(0).type = "password";
};
myapp.UserDetailAddEdit.FullName_postRender = function (element, contentItem) {
    // Write code here.
    $(element).addClass('firstFocus');

};