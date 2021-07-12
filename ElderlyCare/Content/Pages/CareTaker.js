$(document).ready(function () {
    getRegistrationList();
});

var saveRegistration = function () {
    var name = $("#txtName").val();
    var age = $("#txtAge").val();
    var contactno = $("#txtContactno").val();
    var address = $("#txtAddress").val();
    var patientrelation = $("#txtPatientRelation").val();
 
    var model = { Name: name, Age: age, Contactno: contactno, Address: address, PatientRelation: patientrelation } ;
    $.ajax({
        url: "/CareTakerRegistration/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Registration Successful");
        }

    });
}

var getRegistrationList = function () {
    $.ajax({
        url: "/CareTakerRegistration/GetRegistrationList",
        method: "post",

        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblCareTaker tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.CareTakerId + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Age + "</td><td>" + elementValue.Contactno + "</td><td>" + elementValue.Address + "</td><td>" + elementValue.PatientRelation + "</td></tr>"
            });
            $("#tblCareTaker tbody").append(html);

        }
    });
}