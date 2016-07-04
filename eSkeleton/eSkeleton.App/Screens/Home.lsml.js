/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.Home.MasterMenusTemplate_render = function (element, contentItem) {

    // adiciona a classe que centraliza a imagem no meio do botão;
    $(element).parent().addClass('ref-li-menu-item');

    // cria a imagem do botão hexagono;
    var menuItemImage =
        String.format(
            '<a href="#" class="hd-sm-margin">' +
                '<span class="{0} hb hb-sm spin hb-{1}">' +
                    '<i class="{1}"></i>' +
                '</span>' +
            '</a>',
            contentItem.value.IconColor != '' ? contentItem.value.IconColor : '',
            contentItem.value.Icon);

    // cria um label para o botão na tela;
    var menuItemLabel =
        String.format('<p title="{0}" class="ref-home-menu-label">{1}</p>', contentItem.value.Description, contentItem.value.Label);

    // insere os itens na div element corrente;
    $(menuItemImage).appendTo($(element));
    $(menuItemLabel).appendTo($(element));


};

myapp.Home.MasterMenus_ItemTap_execute = function (screen) {
    // validate if object have OnClick Method...
    if (screen.MasterMenus.selectedItem.OnClick == null)
        // OnClick null, then show subMenus
        myapp.showHomeChildren(
            screen.MasterMenus.selectedItem.Id,
            screen.MasterMenus.selectedItem.Label);
    else
        // else... call OnClick method. 
        myapp[screen.MasterMenus.selectedItem.OnClick].call();

};
