myapp.addScreenValidation = function (screen) {

    var model, collectionProperties, entityName, propName, property;
    model = screen.details.getModel();
    //get addEdit screen entityProperty
    entityProperty = msls.iterate(model.properties)
                    .where(function (p) {
                        return p.propertyType.__isEntityType;
                    })
                    .array[0];
    //get entity name  
    var entityType = entityProperty.name;//"Account"
    //get entity
    var screenEntity = screen[entityType];
    //get the entity class - this object contains all methods defined in Account.lsml.js
    var entityClass = myapp[entityType]

    //build an array of property names from '_validate' methods
    var properties = [];
    for (var p in entityClass) {
        if (typeof entityClass[p] === "function" && p.indexOf("_validate") > 0) {
            prop = { name: p.split("_")[0], type: String };
            properties.push(prop);
        }
    };

    //console.log(properties);

    properties.forEach(function (prop, index) {
        propName = prop.name;
        //get validate method
        var validateMethod = entityClass[propName + "_validate"];
        //find contentItem
        var contentItem = screen.findContentItem(propName);

        if (contentItem) {// contentItem found
            //listen for a change on value
            contentItem.dataBind("value", function (newValue, oldValue) {
                if (newValue) {
                    setTimeout(function () {
                        //call validateMethod passing and returning validationResults array
                        validationResult = validateMethod.call(this, screen[entityType], oldValue);
                        if (validationResult == undefined)
                            contentItem.validationResults = [];
                        else
                            contentItem.validationResults = validationResult;
                    }, 10);
                }
            });
        }
    });
};