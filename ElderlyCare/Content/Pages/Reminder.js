var saveRegistration = function () {
    var remindertext = $("#txtReminderText").val();
    var description = $("#txtDescription").val();
    var starttime = $("#txtStartTime").val();
    var endtime= $("#txtEndTime").val();
    var elderpersonid = $("#txtElderPersonId").val();

    var model = { ReminderText: remindertext, Description: description, StartTime: starttime, EndTime: endtime, ElderPersonId: elderpersonid };
    $.ajax({
        url: "/ReminderRegistration/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Registration Successful");
        }

    });
}