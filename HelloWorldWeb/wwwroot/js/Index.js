﻿// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation
        $("#list").append(`<li>${newcomerName}</li>`);

        $("#nameField").val("");
    })
});