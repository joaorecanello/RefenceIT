/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.MenusBrowse.Icon_render = function (element, contentItem) {

    // update icon of item on changed...
    contentItem.dataBind('value', function (value) {
        var htmlIcon =
            String.format(
                '<i class="{0} {1}" style="font-size:35px;" />',
                contentItem.value,
                contentItem.data.IconColor
           );

        // prevent remove old icon;
        $(element).children().remove();
        // add new icon;
        $(htmlIcon).appendTo($(element));

    });

    $(element).css('text-align', 'center');

};

myapp.MenusBrowse.Name_postRender = function (element, contentItem) {

    $(element).attr('id', contentItem.data.Id);

    contentItem.dataBind('value', function (newValue) {
        if (newValue != undefined)
            $(String.format('#{0}', contentItem.data.Id)).text(String.format('{0} - {1}', contentItem.data.Name, contentItem.data.Label));
    });

    $(element).addClass();

};

myapp.MenusBrowse.Label_postRender = function (element, contentItem) {

    contentItem.dataBind('value', function (newValue) {
        if (newValue != undefined)
            $(String.format('#{0}', contentItem.data.Id)).text(String.format('{0} - {1}', contentItem.data.Name, contentItem.data.Label));
    });

};

myapp.MenusBrowse.refButtonEditMenu_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.editButton, lsRefButtonSize.small, function () {
        myapp.showMenuAddEdit(contentItem.data);
    });

    $(element).css('text-align', 'center');

};

myapp.MenusBrowse.refButtonDelMenu_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.delButton, lsRefButtonSize.small, function () {

        msls.showMessageBox('Deseja excluir a questão?', {
            title: 'Confirmar exclusão',
            buttons: msls.MessageBoxButtons.yesNo
        }).then(function (resultMessage) {
            if (resultMessage == msls.MessageBoxResult.yes) {

                contentItem.data.deleteEntity();

                msls.showProgress(
                    myapp.applyChanges().then(
                        function () {
                            contentItem.screen.Menus.refresh();
                        },
                        function fail(e) {
                            msls.showMessageBox(String.format('Erro ao excluir: {0}', e.message), {
                                title: 'Ocorreu um erro ao excluir o registro'
                            });

                            myapp.activeDataWorkspace.ApplicationData.details.discardChanges();
                        })
                    );
            }
        })

    });

    $(element).css('text-align', 'center');


};

myapp.MenusBrowse.created = function (screen) {
    // Write code here.
    screen.IsMaster = true;
};