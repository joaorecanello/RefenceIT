/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.RoleDetailAddEdit.refButtonNewPermission_render = function (element, contentItem) {

    // call ReferenceIt Helper to render AddButton, Small
    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {

        myapp.showPermissionDetailsSearch ({
            beforeShown: function (searchScreen) {
                searchScreen.PermissionDetail = null;
            },

            afterClosed: function (searchScreen, navigationAction) {

                if (navigationAction == msls.NavigateBackAction.commit) {

                    var newRolePermission = new myapp.RolePermissionDetail();
                    newRolePermission.setPermissionId(searchScreen.PermissionDetail.Id);
                    newRolePermission.setPermissionDetail(searchScreen.PermissionDetail);
                    newRolePermission.setRoleDetail(contentItem.data.RoleDetail);
                    newRolePermission.setRoleName(contentItem.data.RoleDetail.Name);

                }

            }

        });

    });


};

myapp.RoleDetailAddEdit.refButtonNewUser_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.addButton, lsRefButtonSize.small, function () {

        myapp.showUserDetailsSearch({
            // beforeShown, prepare screen with empty question object;
            beforeShown: function (addEditScreen) {
                addEditScreen.UserDetail = null;
            },

            afterClosed: function (searchScreen, navigationAction) {

                if (navigationAction == msls.NavigateBackAction.commit) {

                    var newRoleUser = new myapp.RoleUserDetail();
                    newRoleUser.setUserName(searchScreen.UserDetail.UserName);
                    newRoleUser.setUserDetail(searchScreen.UserDetail);
                    newRoleUser.setRoleDetail(contentItem.data.RoleDetail);
                    newRoleUser.setRoleName(contentItem.data.RoleDetail.Name);

                }
            }
        });
    });

};

myapp.RoleDetailAddEdit.refButtonDelRolePermission_render = function (element, contentItem) {

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

myapp.RoleDetailAddEdit.Name_postRender = function (element, contentItem) {
    // Write code here.
    $(element).addClass('firstFocus');
};

myapp.RoleDetailAddEdit.refButtonDelRoleUser_render = function (element, contentItem) {

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