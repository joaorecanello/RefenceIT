/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.HomeChildren.created = function (screen) {

    screen.details.displayName = String.format('{0} / {1}', 'eSkeleton', screen.ScreenTitle);

};

myapp.HomeChildren.ChildrenMenusTemplate_render = function (element, contentItem) {

    // add css class to center image on button;
    $(element).parent().addClass('ref-li-menu-item');

    // create hexagon image;
    var menuItemImage =
        String.format(
            '<a href="#" class="hd-sm-margin">' +
                '<span class="{0} hb hb-sm spin hb-{1}">' +
                    '<i class="{1}"></i>' +
                '</span>' +
            '</a>',
            contentItem.value.IconColor != '' ? contentItem.value.IconColor : '',
            contentItem.value.Icon);

    // create a label button;
    var menuItemLabel =
        String.format('<p title="{0}" class="ref-home-menu-label">{1}</p>', contentItem.value.Description, contentItem.value.Label);

    // append element to button div;
    $(menuItemImage).appendTo($(element));
    $(menuItemLabel).appendTo($(element));

};

myapp.HomeChildren.ChildrenMenus_ItemTap_execute = function (screen) {
    // if menu onclick null, call same screen with other param (recursive);
    if (screen.ChildrenMenus.selectedItem.OnClick == null)
        myapp.showHomeChildren(
            screen.ChildrenMenus.selectedItem.Id,
            screen.ChildrenMenus.selectedItem.Label);
    else // call onClick method of menu.
        myapp[screen.ChildrenMenus.selectedItem.OnClick].call();

};
