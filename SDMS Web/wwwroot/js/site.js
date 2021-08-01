const API_URL = `https://localhost:44309/api`;

// #region LoadSelect
function loadProductsForGrid() {

    $("#productTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        ajax: {

            url: `${API_URL}/Product/GetProducts`,
            dataSrc: ''
        },
        columns: [
            { data: 'code' },
            { data: 'name' },
            { data: 'date' },
            { data: 'categoryName' },
            { data: 'measureUnitName' },
            {
                data: 'id', render: function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-info fas fa-edit mr-1" onClick=productGET('${row.id}')></button> 
                            <button type="button" class="btn btn-danger fas fa-trash-alt mr-1" onClick=productDelete('${row.id}')></button>`;
                }
            }
        ]
    });
}

function loadCategoriesForGrid() {

    $("#CategoryTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": `${API_URL}/ProductCategory/GetProductCategories`,
            "dataSrc": ''
        },
        columns: [
            { data: 'name' },
            {
                data: 'id', render: function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-info fas fa-edit mr-1" onClick=productCategoryGET('${row.id}')></button> 
                            <button type="button" class="btn btn-danger fas fa-trash-alt mr-1" onClick=productCategoryDelete('${row.id}')></button>`;

                }
            }
        ]
    });

}

function loadMeasureUnitsForGrid() {

    $("#MeasureTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": `${API_URL}/MeasureUnit/GetMeasureUnits`,
            "dataSrc": ''
        },
        columns: [
            { data: 'name' },
            {
                data: 'id', render: function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-info fas fa-edit mr-1" onClick=measureUnitGET('${row.id}')></button> 
                            <button type="button" class="btn btn-danger fas fa-trash-alt mr-1" onClick=deleteMeasureUnit('${row.id}')></button>`;
                }
            }
        ]

    });
}

function loadProductCategories() {
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

}

function loadMeasureUnits() {
    $.get(`${API_URL}/MeasureUnit/GetMeasureUnits`, function (data) {

        $(data).each((i, e) => {
            $('#ddlProductUnit').append(`<option value="${e.id}">${e.name}</option>`);
        });
    });

}

function loadChartOfAccounts() {
    $.get(`${API_URL}/ChartOfAccount/GetChartOfAccounts`, function (data) {

        $(data).each((i, e) => {
            $('.chartofAccount-select2').append(`<option value="${e.id}">${e.name}</option>`);
        });
    });
}
function loadProductForFormulaMaster() {
    $.get(`${API_URL}/Product/GetProducts`, function (data) {
        $('.js-select2').append(`<option disabled selected readonly value="0">-- Please Select --</option>`);

        $(data).each((i, e) => {
            $('.js-select2').append(`<option value="${e.id}">${e.name}</option>`);
        });
        $('.js-select2').select2({
            theme: "bootstrap",
            width: '100%!Important'
        });
    });
}
// #endregion


//#region userDefineFunctions
function productGET(recordId) {

    $('#btnProductCreate').attr('disabled', 'disabled');
    $('#btnProductUpdate').removeAttr('disabled');


    $.get(`${API_URL}/Product/GetProductById?productId=${recordId}`, function (data) {
        debugger
        $('#hdnProductId').val(data.id);
        $('#txtProductCode').val(data.code);
        $('#txtProductName').val(data.name);
        $('#txtRemarks').val(data.remarks);
        $('#txtretailPrice').val(data.retailPrice);
        $('#txtunitPrice').val(data.actualPrice);
        $('#dtpProductDate').val(data.date);
        $("#ddlProductUnit").select2("trigger", "select", {
            data: { id: data.measureUnitId }
        });
        $("#ddlProductCategory").select2("trigger", "select", {
            data: { id: data.categoryId }
        });
        $('#chkProduct').prop('checked', data.status == 1);
        $("#ddlCostOfGodsSold").select2("trigger", "select", {
            data: { id: data.costOfGoodsSoldCOAId }
        });
        $("#ddlInventory").select2("trigger", "select", {
            data: { id: data.inventoryCOAId }
        });
        $("#ddlSales").select2("trigger", "select", {
            data: { id: data.saleCOAId }
        });
        $("#ddlSalesDiscount").select2("trigger", "select", {
            data: { id: data.saleDiscountCOAId }
        });
        $("#ddlSalesReturn").select2("trigger", "select", {
            data: { id: data.saleReturnCOAId }
        });

    });

}
function productDelete(recordId) {
    $.ajax({
        url: `${API_URL}/Product/DeleteProductById?productId=` + recordId,
        method: 'DELETE',
        success: function (date) {
            $(document).Toasts('create', {
                class: 'bg-danger',
                title: 'Deleted',
                subtitle: '',
                autohide: true,
                delay: 750,
                body: 'Record Deleted Successfully.'
            });
            $("#productTable").DataTable().clear();
            $("#productTable").DataTable().ajax.reload();
        },
        error: function (err) {
            console.log(err.responseText);
        }
    });
}

function deleteMeasureUnit(recordID) {

    $.ajax({
        url: `${API_URL}/MeasureUnit/DeleteMeasureUnitById?mesureUnitId=` + recordID,
        method: 'DELETE',
        success: function (data) {
            $(document).Toasts('create', {
                class: 'bg-danger',
                title: 'Deleted',
                subtitle: '',
                autohide: true,
                delay: 750,
                body: 'Record Deleted Successfully.'
            });
            $("#MeasureTable").DataTable().clear();
            $("#MeasureTable").DataTable().ajax.reload();

        },
        error: function (err) {
            console.log(err.responseText);
        }
    });


}
function measureUnitGET(recordId) {
    debugger
    $('#btnMeasureUnitCreate').attr('disabled', 'disabled');
    $('#btnMeasureUnitUpdate').removeAttr('disabled');


    $.get(`${API_URL}/MeasureUnit/GetMeasureUnitsById?mesureUnitId=${recordId}`, function (data) {
        $('#hdnMeasureUnitId').val(data.id);
        $('#txtMeasureUnit').val(data.name);
    });

}

function productCategoryGET(recordId) {

    $('#btnProductCategoryCreate').attr('disabled', 'disabled');
    $('#btnProductCategoryUpdate').removeAttr('disabled');


    $.get(`${API_URL}/ProductCategory/GetProductCategoryById?ProductCategoryId=${recordId}`, function (data) {
        $('#hdnProductCategoryId').val(data.id);
        $('#txtProductCategoryName').val(data.name);
    });

}
function productCategoryDelete(recordID) {

    $.ajax({
        url: `${API_URL}/ProductCategory/DeleteProductCategoryById?ProductCategoryId=` + recordID,
        method: 'DELETE',
        success: function (data) {
            $(document).Toasts('create', {
                class: 'bg-danger',
                title: 'Deleted',
                subtitle: '',
                autohide: true,
                delay: 750,
                body: 'Record Deleted Successfully.'
            });
            $("#CategoryTable").DataTable().clear();
            $("#CategoryTable").DataTable().ajax.reload();

        },
        error: function (err) {
            console.log(err.responseText);
        }
    });


}

//#endregion



// #region formData

$(function () {

    $('body').on('click', '#btnProductCreate', function () {
        let frmData = {
            measureUnitId: $('#ddlProductUnit').val(),
            productCategoryId: $('#ddlProductCategory').val(),
            name: $('#txtProductName').val(),
            date: $('#dtpProductDate').val(),
            retailPrice: $('#txtretailPrice').val(),
            actualPrice: $('#txtunitPrice').val(),
            remarks: $('#txtRemarks').val(),
            isActive: $('#chkProduct').prop('checked') == true ? true : false,
            costOfGoodsSoldCOAId: $('#ddlCostOfGodsSold').val(),
            inventoryCOAId: $('#ddlInventory').val(),
            saleCOAId: $('#ddlSales').val(),
            saleDiscountCOAId: $('#ddlSalesDiscount').val(),
            saleReturnCOAId: $('#ddlSalesReturn').val()
        };
        $.ajax({
            url: `${API_URL}/Product/CreateProduct`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                debugger
                $("#productTable").DataTable().clear();
                $("#productTable").DataTable().ajax.reload();
                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });

                document.getElementById("frmProduct").reset();

                $(".js-select2").val('0');
                $('.js-select2').trigger('change');
            },
            error: function (err) {
                console.log(err.responseText);
            }
        });

    });

    $('body').on('click', '#btnProductUpdate', function () {
        debugger
        let frmData = {
            id: $('#hdnProductId').val(),
            measureUnitId: $('#ddlProductUnit').val(),
            productCategoryId: $('#ddlProductCategory').val(),
            name: $('#txtProductName').val(),
            date: $('#dtpProductDate').val(),
            retailPrice: $('#txtretailPrice').val(),
            actualPrice: $('#txtunitPrice').val(),
            remarks: $('#txtRemarks').val(),
            isActive: $('#chkProduct').prop('checked') == true ? true : false,
            costOfGoodsSoldCOAId: $('#ddlCostOfGodsSold').val(),
            inventoryCOAId: $('#ddlInventory').val(),
            saleCOAId: $('#ddlSales').val(),
            saleDiscountCOAId: $('#ddlSalesDiscount').val(),
            saleReturnCOAId: $('#ddlSalesReturn').val()
        };
        $.ajax({
            url: `${API_URL}/Product/EditProduct`,
            type: "PUT",
            data: JSON.stringify(frmData),
            contentType: "application/json",
            success: function (response) {
                $("#productTable").DataTable().clear();
                $("#productTable").DataTable().ajax.reload();
                debugger


                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Update',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Updated Successfully.'
                });



                document.getElementById("frmProduct").reset();
                $(".js-select2").val('0');
                $('.js-select2').trigger('change');
            },
            error: function (err) {
                console.log(err.responseText);
            },
            complete: function () {
                $('#btnProductUpdate').attr('disabled', 'disabled');
                $('#btnProductCreate').removeAttr('disabled');
            }

        });
    });

    $('body').on('click', '#btnProductReset', function () {
        debugger

        document.getElementById("frmProduct").reset();

        //$(".js-select2").select2('val', '-- Please Select --');
        $(".js-select2").val('0');
        $('.js-select2').trigger('change');

    });


    $('body').on('click', '#btnProductCategoryCreate', function () {
        debugger
        let frmData = {
            name: $('#txtProductCategoryName').val()
        };
        $.ajax({
            url: `${API_URL}/ProductCategory/CreateProductCategory`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                debugger
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

    $('body').on('click', '#btnProductCategoryUpdate', function () {
        debugger
        let frmData = {
            id: $('#hdnProductCategoryId').val(),
            name: $('#txtProductCategoryName').val()
        };
        $.ajax({
            url: `${API_URL}/ProductCategory/EditProductCategory`,
            type: "PUT",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                debugger


                $("#CategoryTable").DataTable().clear();
                $("#CategoryTable").DataTable().ajax.reload();

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Update',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Updated Successfully.'
                });

                document.getElementById("frmCategories").reset();

            },
            error: function (err) {
                console.log(err);
            },
            complete: function () {

                $('#btnProductCategoryUpdate').attr('disabled', 'disabled');
                $('#btnProductCategoryCreate').removeAttr('disabled');

            }
        });
    });


    $('body').on('click', '#btnMeasureUnitCreate', function () {
        debugger
        let frmData = {
            name: $('#txtMeasureUnit').val()
        };
        $.ajax({
            url: `${API_URL}/MeasureUnit/CreateMeasureUnit`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                debugger
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

    $('body').on('click', '#btnMeasureUnitUpdate', function () {
        debugger
        let frmData = {
            id: $('#hdnMeasureUnitId').val(),
            name: $('#txtMeasureUnit').val()
        };
        $.ajax({
            url: `${API_URL}/MeasureUnit/EditMeasureUnt`,
            type: "PUT",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                debugger


                $("#MeasureTable").DataTable().clear();
                $("#MeasureTable").DataTable().ajax.reload();

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Update',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Updated Successfully.'
                });

                document.getElementById("frmMeasureUnit").reset();

            },
            error: function (err) {
                console.log(err);
            },
            complete: function () {

                $('#btnMeasureUnitUpdate').attr('disabled', 'disabled');
                $('#btnMeasureUnitCreate').removeAttr('disabled');

            }
        });
    });


    $('body').on('click', '#btnFormulaDetailAdd', function () {
        debugger
        var tblData = {
            productName: $('#ddlProductDetails').select2('data'),
            quantity: $('#txtQuantity').val()
        };
        $('#productFormulaDetailTable>tbody').append(
            `<tr>
                <td>${tblData.productName[0].text}</td>
                <td>${tblData.quantity}</td>
                <td>
                    <button type="button" class="btn btn-info fas fa-edit mr-1" id="btnEdit" value="${tblData.productName[0].id}" onClick=productGET('${tblData.productName[0].id}')></button>
                    <button type="button" class="btn btn-danger fas fa-trash-alt" onClick=productDelete('${tblData.productName[0].id}')></button>
</td>
             </tr>
        `);
        $('#txtQuantity').val(0);
        $('#ddlProductDetails').val(0);
        $('#ddlProductDetails').trigger('change');
    });
    $('body').on('click', '#btnProductFormulaReset', function () {
        document.getElementById("frmProductFormula").reset();
        $("#productFormulaDetailTable>tbody").html("");
        $(".js-select2").val('0');
        $('.js-select2').trigger('change');
    });

    $('body').on('click', '#btnProductFormulaCreate', function () {
        var TableData = [];
        debugger
        $.each($('#productFormulaDetailTable tbody tr'), function () {
            TableData.push({
                productId: $(this).find('#btnEdit').val(),
                quantity: $(this).find('td:eq(1)').html()
            });

        });
        let frmData = {
            productId: $('#ddlProduct').val(),
            productFormulaDetails: TableData
        };
        $.ajax({
            url: `${API_URL}/ProductFormula/CreateProductFormula`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                debugger
                console.log(response);
                $("#productFormulaDetailTable>tbody").html("");

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });

                document.getElementById("frmProductFormula").reset();

                $(".js-select2").val('0');
                $('.js-select2').trigger('change');

            },
            error: function (err) {
                debugger
                console.log(err);
            }
        });
    });

});
// #endregion

// #region Clear Fields

//#endregion