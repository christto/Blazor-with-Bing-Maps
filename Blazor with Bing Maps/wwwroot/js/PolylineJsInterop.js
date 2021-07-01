function addPolyline(sitePolyline) {
    var polyline = new Microsoft.Maps.Polyline(sitePolyline.line, sitePolyline.options);
    bingMap.map.entities.push(polyline);
}
function clearPolyline() {
    for (var i = bingMap.map.entities.getLength() - 1; i >= 0; i--) {
        var polyline = bingMap.map.entities.get(i);
        if (polyline instanceof Microsoft.Maps.Polyline) {
            bingMap.map.entities.removeAt(i);
        }
    }
}