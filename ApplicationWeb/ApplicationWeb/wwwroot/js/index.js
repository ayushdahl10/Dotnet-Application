var city;
var country;
var lat;
var lon;

$(document).ready(function () {

    $("#search").click(function (event) {

        search(event);

    });

    $("#save").click(function (event) {
        sendData(event);
    });

});

function search(event) {

    var request;
    event.preventDefault();

    request = $.ajax({
        url: "https://api.weatherapi.com/v1/current.json?key=d2262d3659a24d84bcd53209211911&q=" + $("#citytext").val() + "&aqi=no",
        type: "get",


    });

    request.done(function (response) {
        formatUpdate(response);
    });

}

function formatUpdate(objData) {
    city = objData.location.name;
    country = objData.location.country;
    lat = objData.location.lat;
    lon = objData.location.lon;

    $("#lblCity").text(city);
    $("#lblCountry").text(country);
    $("#lbllon").text(lon);
    $("#lbllat").text(lat);


}

function sendData(event) {

    $.ajax({
        url: "/home/AddData",
        type: "post",
        data: { "city": city, "country": country, "lon": lon, "lat": lat },
        success: function (event) {
            alert("Data saved successfully");
        }

    });


}