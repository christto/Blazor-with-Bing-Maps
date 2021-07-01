function addPushpin(sitePin) {
    var pushpin = new Microsoft.Maps.Pushpin(sitePin.location, {
        visible: true,
        icon: sitePin.icon,
        color: sitePin.color
    });
    pushpin.metadata = {
        title: sitePin.title,
        subTitle: sitePin.subTitle,
        text: sitePin.text
    };
    Microsoft.Maps.Events.addHandler(pushpin, 'click', pushpinEvent);
    bingMap.map.entities.push(pushpin);
    pushpinList.push(pushpin);
}
function pushpinEvent(e) {
    if (e.target.metadata) {
        if (bingMap.pushpinSelected != undefined && bingMap.pushpinSelected.title == e.target.metadata.title) {
            bingMap.infobox.setOptions({
                visible: false
            });
            bingMap.pushpinSelected = undefined;
        }
        else {
            bingMap.infobox.setOptions({
                location: e.target.getLocation(),
                htmlContent: infoboxTemplate.replace('{title}', e.target.metadata.title).replace('{subtitle}', e.target.metadata.subTitle).replace('{description}', e.target.metadata.text),
                visible: true
            });
            bingMap.pushpinSelected = e.target.metadata;
        }
    }
}
function clearPushpin() {
    for (var i = bingMap.map.entities.getLength() - 1; i >= 0; i--) {
        var pushpin = bingMap.map.entities.get(i);
        if (pushpin instanceof Microsoft.Maps.Pushpin) {
            bingMap.map.entities.removeAt(i);
        }
    }
}

//function updatePushpin(sitePin) {
//    var pushinToUpdate;
//    var location = new Microsoft.Maps.Location(0, 0);
//    for (var i = 0; i < pushpinList.length; i += 2) {
//        var pinId = pushpinList[i];
//        if (pinId == sitePin.vehicleId) {
//            pushinToUpdate = pushpinList[i + 1];
//            pushpinList.splice(i, 2);
//        }
//    }

//    if (pushinToUpdate != undefined) {
//        for (var i = bingMap.map.entities.getLength() - 1; i >= 0; i--) {
//            var pushpin = bingMap.map.entities.get(i);
//            if (pushpin instanceof Microsoft.Maps.Pushpin && pushpin.id == pushinToUpdate.id) {
//                bingMap.map.entities.removeAt(i);
//                var pin = new Microsoft.Maps.Pushpin(sitePin.location, {
//                    visible: true,
//                    icon: sitePin.icon,
//                    color: sitePin.color
//                });
//                pin.metadata = {
//                    title: sitePin.driverName,
//                    subTitle: sitePin.unitNumber,
//                    text: sitePin.subrouteName
//                };
//                Microsoft.Maps.Events.addHandler(pin, 'click', pushpinEvent);
//                bingMap.map.entities.push(pin);
//                pushpinList.push(sitePin.vehicleId, pin);
//            }
//        }
//    }
//}