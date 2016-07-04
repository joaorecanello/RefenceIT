// Definition of Reference Buttons Types;
var lsRefButtonType = {

    addButton: { cssClasses: 'fa fa-plus-square ref-button ref-add-button', title: "Novo" },
    delButton: { cssClasses: 'fa fa-trash-o ref-button ref-del-button', title: "Apagar" },
    editButton: { cssClasses: 'fa fa-pencil-square-o ref-button ref-edit-button', title: "Editar" },
    dashboardButton: { cssClasses: 'fa fa-tachometer ref-button ref-dashboard-button', title: "Visualizar" },
    printButton: { cssClasses: 'fa fa-print ref-button ref-print-button ', title: "Imprimir" },
    makeButton: { cssClasses: 'fa fa-bolt ref-button ref-make-button', title: 'Gerar' },
    chartButton: { cssClasses: 'fa fa-pie-chart ref-button ref-chart-button', title: 'Gráfico' },


};

// Definition of Reference Buttons Sizes;
var lsRefButtonSize = {

    small: { cssClass: 'ref-small-button' },
    normal: { cssClass: 'ref-normal-button' },
    big: { cssClass: 'ref-big-button' }

};

var lsFormatDate = {
    dateFormat: "DD/MM/YYYY"
};

var lsReference = (function () {

    var screenArray = [];

    /**
     * Render color picker input component
     * @param {element} represent a DOM element;
     * @param {contentItem} represent a ls element;
     * @return void
     */
    var colorPickerInput = (function (element, contentItem) {

        /// <summary>Initialize an Element to be a color picker</summary>
        /// <param name="element">The element you want to be the picker</param>
        /// <param name="contentItem">ContentItem of the field</param>

        // Wrap in a timeout to make sure jQuery Mobile is done
        setTimeout(function () {

            // Make sure the container to hold our color picker has
            // the base LightSwitch class
            $(element).addClass("ui-mini");

            // Create and add the input tag to the DOM
            var inputElement = $("<input />");
            inputElement.appendTo($(element));

            // Make our color picker based on our parameters
            inputElement.spectrum({
                color: contentItem.value,
                showInput: true,
                theme: "sp-LightSwitch",
                preferredFormat: "hex",
                allowEmpty: true,
                showPalette: true,
                showSelectionPalette: true,
                palette: [],
                localStorageKey: "spectrumColors",
                change: function (newValue) {
                    var newColor = null;
                    if (newValue) {
                        newColor = newValue.toString();
                    }
                    contentItem.value = newColor;
                }
            });

        }, 0);

    });

    var sortHTMLElements = function (ulList, elementText) {

        ulList.children('li').detach().sort(function (a, b) {
            return $(a).find(elementText).text().localeCompare($(b).find(elementText).text());
        }).appendTo(ulList);

    };


    /**
     * Render screenPicker component  with list of screens application;
     * @param {contentItem} represent a ls element;
     * @param {required} indicate required input, adding blank item when true;
     * @return void
     */
    var screenPickerInput = (function (contentItem, required) {

        /// <summary>Turn an existing field to a screen dropdown picker</summary>
        /// <param name="contentItem">ContentItem of the field</param>
        /// <param name="required">Allow a blank selection?</param>

        // If our screens have not been populated, go do it
        if (screenArray.length === 0) screens();
        var values = screenArray;

        // if not a required field, allow a blank
        if (!required) {
            values.splice(0, 0, { value: "", stringValue: "" });
        }

        // Replace the existing choiceList with our screens
        contentItem.choiceList = values;

    });

    /**
     * Render a reference button
     * @param {element} represent a DOM element;
     * @param {contentItem} represent a ls element;
     * @param {buttonType} Indicate button type to render (add, edit, del, etc);
     * @param {buttonSize} Indicate button size to render (small, normal, big);
     * @param {onClick} Indicate a function method to be called onClick button;
     * @return void
     */
    var renderButton = function (element, contentItem, buttonType, buttonSize, onClick) {

        $('<div/>', {
            class: String.format('{0} {1}', buttonType.cssClasses, buttonSize.cssClass),
            click: onClick,
            title: buttonType.title
        }).appendTo($(element));

    }

    /**
     * render loading inside element
     * @param {element} represent a DOM element;
     * @param {promise} promise function to use a return ajax call
     * @return void
     */
    var showLoadOnElement = function (element, promise, onCompleteReturn, onErrorReturn) {

        $(element).addClass('ref-mini-loader');

        promise.then(function onComplete(data) {
            $(element).find('.ref-mini-loader').removeClass('ref-mini-loader');
            onCompleteReturn(data);
        }, function onError(error) {
            $(element).find('.ref-mini-loader').removeClass('ref-mini-loader');
            onErrorReturn(error);
        });

    }

    var screens = (function (screensToExclude, forceRefresh) {

        /// <summary>Returns and array of screen names and methods to show them</summary>
        /// <param name="screensToExclude">Optional - Array of screen names to exclude</param>
        /// <param name="forceRefresh">Pass true if you want to force a refresh of the list</param>

        // If our internal array is empty, lets fill it, or if we were told to force a refresh
        if (screenArray.length == 0 || forceRefresh) {

            // Loop over each function within our app space
            $.each(window.myapp, function (funcName) {

                try {

                    // Look for "show" screen functions
                    if (funcName.slice(0, 4) === "show") {

                        // Get the actual name of the screen object
                        var name = funcName.substring(4);

                        // Do we need to create the details
                        if (window.myapp[name].prototype.details == undefined) {

                            // Create the details
                            window.myapp[name].prototype.constructor([], undefined);
                        }

                        // Last check for wildcard exclusion
                        if (!internalHelpers.valueInArray(name, screensToExclude)) {

                            // Push the important parts into our global list so we only have to do this on startup
                            screenArray.push({
                                Name: funcName,
                                stringValue: window.myapp[name].prototype.details.displayName,
                                value: funcName
                            });

                        }
                    }
                } catch (e) {
                    // Do nothing... 
                }
            });

            // Sort our list
            screenArray.sort(internalHelpers.sortByName);

        }

        // Return the array of screen listings
        return screenArray;

    });

    var internalHelpers = {

        // =================================================================================================
        // Does any element in an array contain our string
        // =================================================================================================
        valueInArray: function (value, a) {
            var result = false;

            if (a) {
                for (var i = 0; i < a.length; i++) {
                    if (value.indexOf(a[i]) !== -1) {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

    }

    return {
        colorPickerInput: colorPickerInput,
        screenPickerInput: screenPickerInput,
        renderButton: renderButton,
        showLoadOnElement: showLoadOnElement,
        sortHTMLElements: sortHTMLElements
    };

})(); 