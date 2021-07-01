var bingMap, infobox;
var pushpinSelected;
var pushpinList = [];
var infoboxTemplate = '<div class="customInfobox"><div class="title">{title}</div><div class="subtitle">{subtitle}</div>{description}</div>';
var BingMap = /** @class */ (function () {
    function BingMap() {
        this.map = new Microsoft.Maps.Map('#myMap',
            {
                navigationBarOrientation: 1,
                center: new Microsoft.Maps.Location(19.047292, -98.198344),
                mapTypeId: Microsoft.Maps.MapTypeId.road,
                zoom: 12
            });
        this.infobox = new Microsoft.Maps.Infobox(this.map.getCenter(), {
            visible: false
        });
        this.infobox.setMap(this.map);
        this.pushpinSelected = undefined;
    }
    return BingMap;
}());
function loadMap() {
    bingMap = new BingMap();
}
function clearMap() {
    for (var i = bingMap.map.entities.getLength() - 1; i >= 0; i--) {
        bingMap.map.entities.removeAt(i);
    }
}