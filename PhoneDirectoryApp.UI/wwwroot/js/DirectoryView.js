$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/api/user/user/getallperson",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#tablo").DataTable({

                data: data,
                "columns": [
                    { data: "name", "autoWidth": true },
                    { data: "surname", "autoWidth": true, },
                    { data: "companyName", "autoWidth": true },
                    { data: "id", "autoWidth": true },


                    {
                        "render": function (data, type, row) {
                            return "<a href='#' class='btn btn-danger' onclick=getContactInfo('" + row.id + "') data-toggle='modal' data-target='#ViewContactModal' >VİEW CONTACT</a>";
                        }
                    },

                    //{
                    //    "render": function (data, type, row) {
                    //        return "<a href='#' class='btn btn-danger addContentByUser' id='" + row.id + "' data-toggle='modal' data-target='#addContactModal' >ADD CONTACT</a>";
                    //    }
                    //},
                    {
                        "render": function (data, type, row) {
                            return "<a href='#' class='btn btn-danger' onclick=DeleteUser('" + row.id + "') >DELETE PERSON</a>";
                        }
                    }


                ]

            });

        }
    });



    $("#AddPersonButton").click(function () {
        var Name = $("#Name").val();
        var Surname = $("#Surname").val();
        var CompanyName = $("#CompanyName").val();
        var PhoneNumber = $("#PhoneNumber").val();
        var Email = $("#Email").val();
        var Address = $("#mySelectPerson").val();

        $.ajax({
            type: "POST",
            url: "https://localhost:44386/api/user/user/createperson",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ 'Name': Name, 'Surname': Surname, 'CompanyName': CompanyName, 'PhoneNumber': PhoneNumber, 'Email': Email, 'Address': Address }),
            success: function (data) {
                window.location.reload();
                console.log("ready!");
            }
        });
    });




    $("#AddContentInfo").click(function () {
        document.getElementById("addId").innerHTML = document.getElementById("userID").innerHTML;
    });

    $("#AddContactBtn").click(function () {
        var UserID = document.getElementById("addId").innerHTML;
        var PhoneNumber = $("#phoneNumber").val();
        var Email = $("#email").val();
        var Address = $("#mySelect").val();
        debugger;
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/api/user/user/CreateContactInfo",
            dataType: "JSON",
            contentType: "application/json; charset-utf-8",
            data: JSON.stringify({ 'PhoneNumber': PhoneNumber, 'Email': Email, 'Address': Address, 'UserID': UserID }),
            success: function (data) {
                window.location.reload();
                console.log("Contact Added");
            }
        });
    });

    $("#iconReload").click(function () {
        window.location.reload();
    });
    $("#closeReload").click(function () {
        window.location.reload();
    });


});



function getContactInfo(id) {
    $.ajax({
        type: "POST",
        url: "https://localhost:44386/api/user/user/getallcontactInfo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'ID': id }),
        success: function (data) {
            $("#tabloContact").DataTable({
                data: data,
                "columns": [
                    { data: "phoneNumber", "autoWidth": true },
                    { data: "email", "autoWidth": true },
                    { data: "address", "autoWidth": true },

                    {
                        "render": function (data, type, row) {
                            return "<a href='#' class='btn btn-danger' onclick=DeleteContactInfo('" + row.id + "') data-toggle='modal' data-target='#ViewContactModal' >DELETE CONTACT</a>";
                        }
                    }
                ]
            });
           
        }
    });

    document.getElementById("userID").innerHTML = id;
}

function DeleteContactInfo(id) {
    var Id = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44386/api/user/user/DeleteContactInfo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'ID': Id }),
        success: function (data) {
            window.location.reload();
            console.log("ready!");
        }
    });
}

function DeleteUser(id) {
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44386/api/user/user/deleteperson",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'ID': id }),
        success: function (data) {
            window.location.reload();
            console.log("ready!");
        }
    });
}