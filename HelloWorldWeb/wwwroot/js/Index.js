$(document).ready(function () {

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
                $("#teamList").append(
                    `<li>
                <span class="memberName">
                        ${newcomerName}
                    </span >
                <span class="delete fa fa-remove" onclick="deleteMember(${result})">
                    </span>
                <span class="pencil fa fa-pencil">
                    </span>
                </li>`);
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
                location.reload();
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
        var currentName = targetMemberTag.find(".memberName").text();
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
                location.reload();
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
            location.reload();
        }
    })
}

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