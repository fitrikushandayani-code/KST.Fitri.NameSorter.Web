$(document).ready(function () {
    $('#smtUpload').on('click', function () {
        document.getElementById("uploadForm").submit();
    });
})

function SimpanList() {
    var namelist = ReadTable();
    $.ajax({
        url: '/home/save/',
        type: "POST",
        data: { namelist: namelist },
        success: function (data) {
            window.location.href = data.redirectTo;
        }
    });
}

function ReadTable() {
    var result = "";
    var myTab = document.getElementById('sortlist');
    for (i = 0; i < myTab.rows.length; i++) {
        if (i == myTab.rows.length - 1) {
            result += myTab.rows[i].cells[1].innerHTML;
        } else {
            result += myTab.rows[i].cells[1].innerHTML + ",";
        }
    }
    return result;

} 
