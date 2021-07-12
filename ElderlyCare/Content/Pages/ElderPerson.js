$(document).ready(function () {
    getRegistrationList();
});

var saveRegistration = function () {
    var name = $("#txtName").val();
    var age = $("#txtAge").val();
    var address = $("#txtAddress").val();
    var contactno = $("#txtContactno").val();
    var doctorname = $("#txtDoctorName").val();
    var doctorcontactno = $("#txtDoctorContactno").val();
    var hospitalname = $("#txtHospitalName").val();
    var hospitalcontactno = $("#txtHospitalContactno").val();
    var caretaker = $("#txtCareTaker").val();

    var model = { Name: name, Age: age, Address: address, Contactno: contactno, DoctorName: doctorname, DoctorContactno: doctorcontactno, HospitalName: hospitalname, HospitalContactno: hospitalcontactno, CareTaker: caretaker};
    $.ajax({
        url: "/ElderPersonRegistration/SaveRegistration",
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
        url: "/ElderPersonRegistration/GetRegistrationList",
        method: "post",

        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblElderPerson tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ElderPersonId + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Age + "</td><td>" + elementValue.Address + "</td><td>" + elementValue.Contactno + "</td><td>" + elementValue.DoctorName + "</td><td>" + elementValue.DoctorContactno + "</td><td>" + elementValue.HospitalName + "</td><td>" + elementValue.HospitalContactno + "</td><td>" + elementValue.CareTaker + "</td></tr>"
            });
            $("#tblElderPerson tbody").append(html);

        }
    });
}