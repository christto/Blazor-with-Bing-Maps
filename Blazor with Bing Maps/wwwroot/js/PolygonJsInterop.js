function addPolygon(sitePolygon) {
    var polygon = new Microsoft.Maps.Polygon(sitePolygon.shape, sitePolygon.options);
    bingMap.map.entities.push(polygon);
}
function clearPolygon() {
    for (var i = bingMap.map.entities.getLength() - 1; i >= 0; i--) {
        var polygon = bingMap.map.entities.get(i);
        if (polygon instanceof Microsoft.Maps.Polygon) {
            bingMap.map.entities.removeAt(i);
        }
    }
}