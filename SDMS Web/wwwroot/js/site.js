﻿const API_URL = `https://localhost:44309/api`;

// #region LoadSelect
function loadProducts() {

    $("#productTable").DataTable({
        ajax: {

            url: `${API_URL}/Product/GetProducts`,
            dataSrc:''
        },
        columns: [
            { data: 'id' },
            { data: 'code' },
            { data: 'name' },
            { data: 'date' },
            { data: 'categoryName' },
            { data: 'measureUnitName' },
        ]
    });
}

function loadCategories() {

    $("#CategoryTable").DataTable({
        "ajax": {
            "url": `${API_URL}/ProductCategory/GetProductCategories`,
            "dataSrc": ''
        },
        columns: [
            { data: 'id' },
            { data: 'name' }
        ]
    });

}

function loadMeasures() {

    $("#MeasureTable").DataTable({
        "ajax": {
            "url": `${API_URL}/MeasureUnit/GetMeasureUnits`,
            "dataSrc" : ''
        },
        columns: [
            { data: 'id' },
            {data: 'name'}
        ]

    });
}

$(function () {

    $.get(`${API_URL}/ProductCategory/GetProductCategories`, function (data) {

        $('.js-select2').append(`<option disabled selected readonly value="0">-- Please Select --</option>`);

        $(data).each((i, e) => {
            $('#ddlProductCategory').append(`<option value="${e.id}">${e.name}</option>`);
        });

        $('.js-select2').select2({
            theme: "bootstrap",
            width: '100%!Important'
        });

    });

    $.get(`${API_URL}/MeasureUnit/GetMeasureUnits`, function (data) {

        $(data).each((i, e) => {
            $('#ddlProductUnit').append(`<option value="${e.id}">${e.name}</option>`);
        });
    });


    $.get(`${API_URL}/ChartOfAccount/GetChartOfAccounts`, function (data) {

        $(data).each((i, e) => {
            $('.chartofAccount-select2').append(`<option value="${e.id}">${e.name}</option>`);
        });
    });

});

// #endregion


// #region formData

$(function () {
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

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });
                
                document.getElementById("frmProduct").reset();

                //$(".js-select2").select2('val', '-- Please Select --');
                $(".js-select2").val('0');
                $('.js-select2').trigger('change');
                //$('.js-select2').val(null).trigger('change');

                //alert('Data Saved Succesfully!');
            },
            error: function (err) {
                console.log(err);
            }
        });


    });

    $("#frmCategories").submit(function (event) {
        event.preventDefault();
        let frmData = {
            "name": $('input[name="name"]').val()
        };
        $.ajax({
            url: `${API_URL}/ProductCategory/CreateProductCategory`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);

                $("#CategoryTable").DataTable().clear();
                $("#CategoryTable").DataTable().ajax.reload();

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });

                document.getElementById("frmCategories").reset();
            },
            error: function (err) {
                console.log(err);
            }
        });

    });

    $("#frmMeasureUnit").submit(function (event) {
        event.preventDefault();
        let frmData = {
            "name": $('input[name="name"]').val()
        };
        $.ajax({
            url: `${API_URL}/MeasureUnit/CreateMeasureUnit`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                
                $("#MeasureTable").DataTable().clear();
                $("#MeasureTable").DataTable().ajax.reload();

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });

                document.getElementById("frmMeasureUnit").reset();

            },
            error: function (err) {
                console.log(err);
            }
        });
    });

});
// #endregion

// #region Clear Fields

//#endregion