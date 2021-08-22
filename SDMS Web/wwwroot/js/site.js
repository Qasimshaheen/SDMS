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
function loadProductForManufactureMaster() {
    $.get(`${API_URL}/Product/GetProducts`, function (data) {
        $('#ddlFormulaMasterProductId').append(`<option disabled selected readonly value="0">-- Please Select --</option>`);

        $(data).each((i, e) => {
            $('#ddlFormulaMasterProductId').append(`<option value="${e.id}">${e.name}</option>`);
        });
        //$('.js-select2').select2({
        //    theme: "bootstrap",
        //    width: '100%!Important'
        //});
    });
}
function loadProductFormulaMasterForGrid() {
    $("#FormulaTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ajax": {
            "url": `${API_URL}/ProductFormula/GetProductFormulas`,
            "dataSrc": ''
        },
        columns: [
            { data: 'productName' },
            {
                data: 'id', render: function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-info  fas fa-edit mr-1" onClick=productFormulaGET('${row.id}')></button> 
                            <button type="button" class="btn btn-primary fas fa-eye mr-1" onClick=productFormulaDetailsView('${row.id}')></button>
                            <button type="button" class="btn btn-danger fas fa-trash-alt mr-1" onClick=productFormulaDelete('${row.id}')></button>`;

                }
            }],
        columnDefs: [
            { targets: 1, className: "text-center" }
        ],
    });
}
function loadFormulaForManufactureLookup() {

    $("#FormullookupTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        "ordering": false,
        "paging": false,
        "searching": false,
        "info": false,
        "ajax": {
            "url": `${API_URL}/ProductFormula/GetProductFormulas`,
            "dataSrc": ''
        },
        columnDefs: [
            { targets: 1, className: "text-center" }
        ],
        columns: [
            { data: 'productName' },
            {
                data: 'id', render: function (data, type, row, meta) {
                    return `<button type="button" title="Edit" data-dismiss="modal" class="btn btn-info fas fa-edit mr-1" onClick=FormulaForManufacturingGET('${row.id}')></button>`;
                }
            }
        ]
    });
}
function loadWarehouseForddl() {
    $.get(`${API_URL}/Warehouse/GetWarehouses`, function (data) {
        $('#ddlWarehouseId').append(`<option disabled selected readonly value="0">-- Please Select --</option>`);

        $(data).each((i, e) => {
            $('#ddlWarehouseId').append(`<option value="${e.id}">${e.name}</option>`);
        });
        $('#ddlWarehouseId').select2({
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

function productFormulaDelete(recordID) {
    $.ajax({
        url: `${API_URL}/ProductFormula/DeleteProductFormulaById?productFormulaId=` + recordID,
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
            $("#FormulaTable").DataTable().clear();
            $("#FormulaTable").DataTable().ajax.reload();
        },
        error: function (err) {
            console.log(err.responseText);
        }
    });
}
function productFormulaGET(recordID) {
    $('#btnProductFormulaCreate').attr('disabled', 'disabled');
    $('#btnProductFormulaUpdate').removeAttr('disabled');
    $("#productFormulaDetailTable>tbody").html("");

    $.get(`${API_URL}/ProductFormula/GetProductFormulaById?productFormulaId=${recordID}`, function (data) {

        $('#hdnProductFormulaId').val(data.id);
        $('#ddlProduct').select2("trigger", "select", { data: { id: data.productId } });
        $(data.productFormulaDetails).each((index, element) => {
            $('#productFormulaDetailTable>tbody').append(
                `<tr>
                <td>${element.productName}</td>
                <td>${element.quantity}</td>
                <td>
                    <button type="button" id="btnEdit" value="${element.productId}" class="js-btnDeleteFormulaDetailProduct btn btn-danger fas fa-trash-alt"></button>
                </td>
             </tr>
            `);
        });

    });
}
function productFormulaDetailsView(recordID) {
    $('#btnProductFormulaCreate').attr('disabled', 'disabled');
    $('#btnProductFormulaUpdate').attr('disabled', 'disabled');
    $('#btnFormulaDetailAdd').attr('disabled', 'disabled');
    $('#txtQuantity').attr('disabled', 'disabled');
    $('#ddlProductDetails').attr('disabled', 'disabled');

    $("#productFormulaDetailTable>tbody").html("");
    $.get(`${API_URL}/ProductFormula/GetProductFormulaById?productFormulaId=${recordID}`, function (data) {

        $('#hdnProductFormulaId').val(data.id);
        $('#ddlProduct').select2("trigger", "select", { data: { id: data.productId } });
        $(data.productFormulaDetails).each((index, element) => {
            $('#productFormulaDetailTable>tbody').append(
                `<tr>
                <td>${element.productName}</td>
                <td>${element.quantity}</td>
             </tr>
            `);
        });

    });
}

function FormulaForManufacturingGET(recordID) {
    localStorage.removeItem('state');
    $('#productManufactureDetailTable>tbody').html("");
    $('#productRawMaterialTable>tbody').html("");
    $.get(`${API_URL}/ProductFormula/GetProductFormulaById?productFormulaId=${recordID}`, function (data) {
        
        $('#hdnFormulaMasterId').val(data.id);
        $('#ddlFormulaMasterProductId').val(data.productId);
        $(data.productFormulaDetails).each((index, element) => {
            $('#productManufactureDetailTable>tbody').append(
                `<tr>
                    <td>${element.productName}</td>
                    <td>${element.quantity}</td>
                    <td>0.00</td>
                    <td>0.00</td>
                    <td><input  type="radio" onClick=RawMaterialForManufacturingGET('${element.productId}') value="${element.productId}"  name="radioFinishGoodSelect"></td>
                </tr>`
            );
        });

    });
}
function localStorageManagement(recordID) {
    var state = localStorage.getItem('state');

    if (state) {
        state = JSON.parse(state);
        state.previousProductId = state.currentProductId;
        state.currentProductId = recordID;

        //if (state.previousProductId != state.currentProductId) {
        state[`productId_${state.previousProductId}`] = getCurrentRawMaterials();
        //}
    }
    else {
        var state = {
            previousProductId: 0,
            currentProductId: 0
        }
        state.currentProductId = recordID;
    }

    localStorage.setItem('state', JSON.stringify(state));

}
function RawMaterialForManufacturingGET(recordID) {

    localStorageManagement(recordID);

    $('#productRawMaterialTable>tbody').html("");

    var state = localStorage.getItem('state');
    if (state)
        state = JSON.parse(state);


    if (state[`productId_${recordID}`]) {
        renderRawMaterials(state[`productId_${recordID}`]);
    }
    else {
        $.get(`${API_URL}/ProductLedger/GetProductLedgerBalanceByProductId?productId=${recordID}`, function (data) {
            renderRawMaterials(data);
        });
    }
}


function renderRawMaterials(data) {
    $.each((data), function (i, e) {
        $('#productRawMaterialTable>tbody').append(
            `<tr>
                    <td>${e.warehouseId} ${e.warehouseName}</td>
                    <td>${e.batchNo}</td>
                    <td>${e.balance} Pcs</td>
                    <td><input  type="number" value="${e.rawQuantity || 0}" class="form-control js-Raw-Material__Quantity" min="0" placeholder="0" ></td>
                </tr>`
        );
    });
}

function submit() {
    var state = localStorage.getItem('state');
    if (state) {
        state = JSON.parse(state);
        state[`productId_${$('input[name="radioFinishGoodSelect"]:checked').val()}`] = getCurrentRawMaterials();
    }
}

function getCurrentRawMaterials() {

    let rawMaterials = [];

    $.each($('#productRawMaterialTable tbody tr'), function () {

        let warehouseId = parseInt($(this).find('td:nth-child(1)').text());
        let warehouseName = $(this).find('td:nth-child(1)').text().substring(2);
        let batchNo = $(this).find('td:nth-child(2)').text();
        let balance = parseInt($(this).find('td:nth-child(3)').text());
        let rawQuantity = +$(this).find('td:nth-child(4) input[type="number"]').val();

        rawMaterials.push({
            warehouseId: warehouseId,
            warehouseName: warehouseName,
            batchNo: batchNo,
            balance: balance,
            rawQuantity: rawQuantity
        });

    });

    return rawMaterials;

}

function getRawMaterialsFromStateByProductId(recordID) {
    let rawMaterials = [];

    var state = localStorage.getItem('state');

    state = JSON.parse(state);

    if (state[`productId_${recordID}`]) {

        $.each((state[`productId_${recordID}`]), function (index, element) {
            if (element.rawQuantity)
                rawMaterials.push({
                    warehouseId: element.warehouseId,
                    batchNo: element.batchNo,
                    quantity: element.rawQuantity
                });
        });
    }

    return rawMaterials;
}


//#endregion



// #region formData

$(function () {


    //$('body').on('click', '#productManufactureDetailTable tbody tr', function () {
    //    
    //    $(this).find('td:nth-child(5)').first('input[type="radio"]').prop('checked',true);
    //})

    $('body').on('blur', '.js-Raw-Material__Quantity', function () {
        let sumInsertedQuantity = 0;
        let availableQty = parseFloat($(this).closest('tr').find('td:nth-child(3)').text());
        let requiredQty = parseFloat($('input[name="radioFinishGoodSelect"]:checked').closest('tr').find('td:nth-child(3)').text());
        let rawMaterialQuantites = $('#productRawMaterialTable').find('.js-Raw-Material__Quantity');

        $.each($(rawMaterialQuantites), function (index, element) {
            sumInsertedQuantity += parseFloat(this.value ? this.value : 0);
        })

        let inputValue = +$(this).val();

        let validCase = inputValue <= requiredQty && inputValue <= availableQty && inputValue >= 0 && sumInsertedQuantity <= requiredQty;

        if (!validCase)
            $(this).addClass('is-invalid');
        else {
            $.each($('#productRawMaterialTable tbody tr'), function (index, element) {
                $(this).find('.js-Raw-Material__Quantity').removeClass('is-invalid');
            });
        }
    })

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


        document.getElementById("frmProduct").reset();

        //$(".js-select2").select2('val', '-- Please Select --');
        $(".js-select2").val('0');
        $('.js-select2').trigger('change');

    });


    $('body').on('click', '#btnProductCategoryCreate', function () {

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

    $('body').on('click', '.js-btnDeleteFormulaDetailProduct', function () {
        $(this).closest("tr").remove();
    });
    $('body').on('click', '#btnFormulaDetailAdd', function () {

        let tblData = {
            productName: $('#ddlProductDetails').select2('data'),
            quantity: $('#txtQuantity').val()
        };
        $('#productFormulaDetailTable>tbody').append(
            `<tr>
                <td>${tblData.productName[0].text}</td>
                <td>${tblData.quantity}</td>
                <td>
                    <button type="button" class="js-btnDeleteFormulaDetailProduct btn btn-danger fas fa-trash-alt" id="btnEdit" value="${tblData.productName[0].id}"></button>
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

        $('#btnProductFormulaUpdate').attr('disabled', 'disabled');
        $('#btnProductFormulaCreate').removeAttr('disabled');
        $('#btnFormulaDetailAdd').removeAttr('disabled');
        $('#txtQuantity').removeAttr('disabled');
        $('#ddlProductDetails').removeAttr('disabled');

        $(".js-select2").val('0');
        $('.js-select2').trigger('change');
    });
    $('body').on('click', '#btnProductFormulaCreate', function () {
        let TableData = [];

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
                
                $("#FormulaTable").DataTable().clear();
                $("#FormulaTable").DataTable().ajax.reload();

                
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

                console.log(err);
            }
        });
    });
    $('body').on('click', '#btnProductFormulaUpdate', function () {

        let TableData = [];
        $.each($('#productFormulaDetailTable tbody tr'), function () {
            TableData.push({
                productId: $(this).find('#btnEdit').val(),
                quantity: $(this).find('td:eq(1)').html()
            });
        });

        let frmData = {
            id: $('#hdnProductFormulaId').val(),
            productid: $('#ddlProduct').val(),
            productFormulaDetails: TableData
        };
        $.ajax({
            url: `${API_URL}/ProductFormula/EditProductFormulaById`,
            type: "PUT",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
                $("#productFormulaDetailTable>tbody").html("");

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Update',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Updated Successfully.'
                });

                document.getElementById("frmProductFormula").reset();

                $(".js-select2").val('0');
                $('.js-select2').trigger('change');
            },
            error: function (err) {
                console.log(err);
            },
            complete: function () {

                $('#btnProductFormulaUpdate').attr('disabled', 'disabled');
                $('#btnProductFormulaCreate').removeAttr('disabled');
            }
        });
    });

    $('body').on('click', '#btnManufactureReset', function () {
        document.getElementById("frmManufacturing").reset();
        $("#productManufactureDetailTable>tbody").html("");
        $("#productRawMaterialTable>tbody").html("");
        $("#btn‏ManufactureUpdate").attr('disabled', 'disabled');
        $("#btn‏ManufactureCreate").removeAttr('disabled');

        $(".js-select2").val('0');
        $('.js-select2').trigger('change');
    });
    $('body').on('blur', '#txtQuantity', function () {

        let quantity = +$(this).val();
        if (!quantity)
            $(this).addClass('is-invalid');
        else
            $(this).removeClass('is-invalid');
        $.each($('#productManufactureDetailTable tbody tr'),

            function (i, e) {
                let unit = +$(this).find('td:nth-child(2)').text();
                $(this).find('td:nth-child(3)').text(quantity * unit);
            });

    });
    $('body').on('click', '#btnManufactureCreate', function () {
        let tableData = [];
        localStorageManagement($('input[name="radioFinishGoodSelect"]:checked').val());

        $.each($('#productManufactureDetailTable tbody tr'), function (index, element) {
            
            let currentProductId = $(this).find('input[name="radioFinishGoodSelect"]').val();
            tableData.push({
                productId: currentProductId,
                manufacturingRawDetails: getRawMaterialsFromStateByProductId(currentProductId)
            });
        });

        let frmData = {
            formulaMasterId: $('#hdnFormulaMasterId').val(),
            productId: $('#ddlFormulaMasterProductId').val(),
            date: $('#dtpManufactureDate').val(),
            batchNo: $('#txtBatchNo').val(),
            warehouseId: $('#ddlWarehouseId').val(),
            quantity: $('#txtQuantity').val(),
            isPosted: false,
            addedBy: 1,
            addedOn: $('#dtpManufactureDate').val(),
            manufacturingDetails: tableData
        };
        
        $.ajax({
            url: `${API_URL}/Manufacturing/CreateManufacturing`,
            type: "POST",
            data: JSON.stringify(frmData),
            contentType: 'application/json',
            success: function (response) {
                
                $("#productManufactureDetailTable>tbody").html("");
                $("#productRawMaterialTable>tbody").html("");

                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Saved',
                    subtitle: '',
                    autohide: true,
                    delay: 750,
                    body: 'Record Added Successfully.'
                });

                document.getElementById("frmManufacturing").reset();

                $(".js-select2").val('0');
                $('.js-select2').trigger('change');
            },
            error: function (err) {
                
                console.log(err);
            }
        });
    })


});
// #endregion

// #region Clear Fields

//#endregion