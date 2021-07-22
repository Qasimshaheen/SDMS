const API_URL = `https://localhost:44309/api`;


function loadProducts() {
    $.get(`${API_URL}/Product/GetProducts`, function (data) {

        $('#productTable>tbody').html('');

        $(data).each((i, e) => {

            $('#productTable>tbody').append(
                `<tr>
                                <td>${e.id}</td>
                                <td>${e.code}</td>
                                <td>${e.name}</td>
                                <td>${e.date}</td>
                                <td>${e.categoryName}</td>
                                <td>${e.measureUnitName}</td>
                             </tr>`);
        });

        $('#productTable').DataTable();

    });

}

$(function () {

    $.get(`${API_URL}/ProductCategory/GetProductCategories`, function (data) {

        $('#ddlProductCategory').append(`<option disabled selected readonly>-- Please Select --</option>`);

        $(data).each((i, e) => {
            $('#ddlProductCategory').append(`<option value="${e.id}">${e.name}</option>`);
        });

        $('#ddlProductCategory').select2({
            theme: "bootstrap"
        });

    });

    $("#frmProduct").submit(function (event) {
        event.preventDefault();

        let frmData = {
            "measureUnitId": $('select[name="measureUnitId"]').val(),
            "productCategoryId": $('select[name="measureUnitId"]').val(),
            "name": $('input[name="name"]').val(),
            "date": $('input[name="date"]').val(),
            "retailPrice": $('input[name="retailPrice"]').val(),
            "actualPrice": $('input[name="actualPrice"]').val(),
            "remarks": $('textarea[name="remarks"]').val(),
            "isActive": true,
            "costOfGoodsSoldCOAId": $('select[name="costOfGoodsSoldCOAId"]').val(),
            "inventoryCOAId": $('select[name="inventoryCOAId"]').val(),
            "saleCOAId": $('select[name="saleCOAId"]').val(),
            "saleDiscountCOAId": $('select[name="saleDiscountCOAId"]').val(),
            "saleReturnCOAId": $('select[name="saleReturnCOAId"]').val()
        };

        $.ajax({
            url: `${API_URL}/Product/CreateProduct`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);

                loadProducts();

                alert('Data Saved Succesfully!');
            },
            error: function (err) {
                console.log(err);
            }
        });


    });

});
