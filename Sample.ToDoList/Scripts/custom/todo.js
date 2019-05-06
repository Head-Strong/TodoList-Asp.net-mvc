$(function () {
    $('.taskCompleteChkBox').change(function () {
        var parenttr = $(this).parent("td").parent("tr");
        var status = $(this).prop("checked");
        var id = $(this).attr('id');
        var url = 'todo/UpdateStatus?id=' + id + '&status=' + status;
        $.ajax({
            type: 'POST',
            url: url,           
            dataType: 'json',
            success: function (jsonData) {
                var message = "";
                if (status == true) {
                    message = "Task completed.";
                    $(parenttr).find("span").addClass("taskComplete");
                }
                else {
                    message = "Task opened again.";
                    $(parenttr).find("span").removeClass("taskComplete");
                }
                alert(message);

            },
            error: function () {
                alert('Error occurred. Please contact tech team.');
            }
        });
    });
});