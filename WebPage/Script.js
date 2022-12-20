$(function () {

    function getOperations() {
        $.ajax({
            url: "http://localhost:8080/api/calculator/",
            type: "GET",
            success: function (result) {
                var oper = result;
                var appenddata1 = "";
                for (var i = 0; i < oper.length; i++) {
                    appenddata1 += "<option value = '" + oper[i].OperationID + " '>" + oper[i].OperationValue + " </option>";
                }
                $("#dropdownState").append(appenddata1);
                console.log.result;
            }
            });
    }
    getOperations();

    function getResult(field1, field2, operation) {
        var ex = {
            Field1: field1,
            Field2: field2,
            OperationID: operation
        };
        var value = JSON.stringify(ex);
        $.ajax({
            url: "http://localhost:8080/api/calculator/",
            type: "POST",
            data: { '': value },
            success: function (result) {
                res = result;
                $('#result').val(res);
                console.log.result;
            }
        });
    }

    $("#calculate").click(function () {
        var field1 = $('#field1').val();
        var field2 = $('#field2').val();
        var operation = $('#dropdownState').val();
        getResult(field1, field2, operation);
    });
    
})