'use strict';

$(document).ready(function () {

    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    connection.on("NewTeamMemberAdded", function (name, id) {
        console.log(`New team member added: ${name}, ${id}`);
        createNewcomer(name, id)
    });

    connection.on("TeamMemberDeleted", function (memberId) {
        onMemberDelete(memberId);
    });

    connection.on('UpdatedTeamMember', function (memberId, name) {
        onMemberEdit(memberId, name);
    })

    connection.start().then(function () {
        console.log("signalr connected");
    }).catch(function (err) {
        return console.error(err.toString());
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        var length = $("#teamMembers").children().length;
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: (result) => {
                console.log(result);                
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
            },
            error: function (err) {
                console.log(err);
            }
        })

    });

    $("#clearButton").click(function ClearFields() {
        document.getElementById("nameField").value = "";
    });

    $("#teamList").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text().trim();
        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        var name = $("#classmateName").val();
        var id = $ ('#editClassmate').attr('data-member-id');
        $.ajax({
            url: "/Home/RenameMember",
            method: "Post",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                console.log('successfully renamed : ${id}');
            }
        })
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

});

function deleteMember(id) {

    $.ajax({
        url: "/Home/RemoveMember",
        method: "DELETE",
        data: {
            "id": id
        },
        success: function (result) {
            console.log("deleete:" + id);
        }
    })
}

function createNewcomer(name, id) {
    // Remember string interpolation
    $("#teamList").append(`
        <li class="member" data-member-id="${id}">
            <span class="memberName">${name}</span>
            <span class="delete fa fa-remove" onclick="deleteMember(${id})"></span>
            <span class="pencil fa fa-pencil"></span>
        </li>`);
}

/*$("#clear").click(function () {
    $("#newcomer").val("");
})*/

(function () {
    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("createButton").disabled = false;
        } else {
            document.getElementById("createButton").disabled = true;
        }
    });
}());

function onMemberDelete(id) {
    $(`li[data-member-id=${id}]`).remove();
}

function onMemberEdit(id, name) {
    $(`li[data-member-id=${id}]`).find(".memberName").text(name);
}

/*
const removeTeamMemberFromList = (teamMemberId) => $(`li[data-member-id=${teamMemberId}]`).remove();

const updateTeamMemberFromList = (teamMemberId, teamMemberName) => $(`li[data-member-id=${teamMemberId}]`).children(".name").text(teamMemberName)*/

