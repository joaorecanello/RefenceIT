/// <reference path="~/GeneratedArtifacts/viewModel.js" />

/**
 * Render a color picker component on IconColor element;
 * @param {element} represent a DOM element;
 * @param {contentItem} represent a ls element;
 * @return void
 */
myapp.MenuAddEdit.IconColor_render = function (element, contentItem) {

    // using lsReference color picker helper;
    //lsReference.colorPickerInput(element, contentItem);

};

/**
 * OnCreated menu, render a combobox with screen methods (showScreen, AddEditScree, etc)
 * @param {screen} represent a screen parent LS element;
 * @return void
 */
myapp.MenuAddEdit.created = function (screen) {

    // get array with screen methods (OnClick);
    var onClickContentItem = screen.findContentItem("OnClick");
    // make a combobox with OnClick methods;
    lsReference.screenPickerInput(onClickContentItem);

};

myapp.MenuAddEdit.Icon1_render = function (element, contentItem) {

    contentItem.dataBind('value', function (value) {
        var htmlIcon =
            String.format(
                '<i class="fa fa-{0} {1}" style="font-size:35px;" />',
                contentItem.value,
                contentItem.data.IconColor
           );

        $(element).children().remove();
        $(htmlIcon).appendTo($(element));

    });

    $(element).css('text-align', 'center');

};

myapp.MenuAddEdit.Name1_postRender = function (element, contentItem) {

    $(element).attr('id', contentItem.data.Id);

    contentItem.dataBind('value', function (newValue) {
        $(String.format('#{0}', contentItem.data.Id)).text(String.format('{0} - {1}', contentItem.data.Name, contentItem.data.Label));
    });
};

myapp.MenuAddEdit.Label1_postRender = function (element, contentItem) {

    contentItem.dataBind('value', function (newValue) {
        $(String.format('#{0}', contentItem.data.Id)).text(String.format('{0} - {1}', contentItem.data.Name, contentItem.data.Label));
    });

};

myapp.MenuAddEdit.Name_postRender = function (element, contentItem) {
    // Write code here.
    $(element).addClass('firstFocus');
};

myapp.MenuAddEdit.AddMenu_Tap_execute = function (screen) {
    // Write code here.
    myapp.showMenuAddEdit(
        null, {
            beforeShown: function (addEditScreen) {
                var _newMenu = new myapp.Menu();
                _newMenu.setMenuPai(screen.Menu);
                addEditScreen.Menu = _newMenu;
            }

        })

};

myapp.MenuAddEdit.refButtonEditMenu_render = function (element, contentItem) {

    lsReference.renderButton(element, contentItem, lsRefButtonType.editButton, lsRefButtonSize.small, function () {
        myapp.showMenuAddEdit(contentItem.data);
    });

    $(element).css('text-align', 'center');


};

myapp.MenuAddEdit.refButtonDelMenu_render = function (element, contentItem) {

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