// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                console.log(result);
                $("#list").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            },
            error: function (err) {
                console.log(err);
            }
        })
    })

    $("#deleteField").click(function () {
        var newcomerName = $("#memberField").val();

        $.ajax({
            method: "POST",
            url: "/Home/DeleteTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                console.log(result);
                $("#list").remove(`<li>${newcomerName}</li>`);
                $("#memberField").val("");
            },
            error: function (err) {
                console.log(err);
            }
        })
    })


});