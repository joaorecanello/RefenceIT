/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.RoleDetailsBrowse.refButtonEditRoleDetail_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.editButton, lsRefButtonSize.small, function () {
        myapp.showRoleDetailAddEdit(contentItem.data);
    });
    $(element).css('text-align', 'center');

};

myapp.RoleDetailsBrowse.refButtonDelRoleDetail_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.delButton, lsRefButtonSize.small, function () {

        msls.showMessageBox('Deseja excluir questionário?', {
            title: 'Confirmar exclusão',
            buttons: msls.MessageBoxButtons.yesNo
        }).then(function (resultMessage) {
            if (resultMessage == msls.MessageBoxResult.yes) {
                contentItem.data.deleteEntity();

                msls.showProgress(
                    myapp.applyChanges().then(
                        function () {
                            contentItem.screen.RoleDetails.refresh();
                        },
                        function fail(e) {
                            msls.showMessageBox(String.format('Erro ao excluir: {0}', e.message), {
                                title: 'Ocorreu um erro ao excluir o registro'
                            });
                            myapp.activeDataWorkspace.ApplicationData.details.discardChanges();
                        }));
            }
        })

    });

    $(element).css('text-align', 'center');
};

myapp.RoleDetailsBrowse.Search_postRender = function (element, contentItem) {
    // Write code here.
    $(element).addClass('firstFocus');
};