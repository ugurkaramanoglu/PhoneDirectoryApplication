$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/api/report/GetAllReport",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#tabloReport").DataTable({

                data: data,
                "columns": [
                    { data: "createdDateTime", "autoWidth": true },
                    { data: "reportName", "autoWidth": true, },
                    { data: "recordUserCount", "autoWidth": true },
                    { data: "recordPhoneCount", "autoWidth": true },
                    { data: "location", "autoWidth": true },
                    { data: "status", "autoWidth": true },

                    {
                        "render": function (data, type, row) {
                            return "<a href='#' class='btn btn-danger' onclick=DeleteUser('" + row.id + "')  >DELETE REPORT</a>";
                        }
                    },

                ]

            });

        }
    });


    $("#PostNewReport").click(function () {
        var ReportName = $("#myInput").val();
        var Location = $("#mySelectLocation").val();
        debugger;

        $.ajax({
            type: "POST",
            url: "https://localhost:44386/api/report/postreport",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ 'ReportName': ReportName, 'Location': Location }),
            success: function (data) {
                window.location.reload();
                alert(data);
                console.log("ready!");
            }
        });
    });

});

function DeleteUser(id) {
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44386/api/report/RemoveReport",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'ID': id }),
        success: function (data) {
            window.location.reload();
            console.log("ready!");
        }
    });
}