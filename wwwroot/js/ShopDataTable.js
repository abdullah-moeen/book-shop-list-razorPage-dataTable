var dataTable;
$(document).ready(function () {
    loadShopDT();
});

function loadShopDT() {
    dataTable = $("#Shop_DT").DataTable({
        "ajax": {
            "url": "/api/shop",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "shopName", "width": "20%" },
            { "data": "owner", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                    <a href="/Shop/EditShop?id=${data}" class="btn btn-success" style="cursor: pointer; width: 70px;">
                        Edit</a>
                    <a class="btn btn-danger text-white" style="cursor: pointer; width: 70px;"
                     onclick = Delete('/api/shop?id='+${data})>
                        Delete</a>
                    </div>
                    `;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No data available"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure",
        text: "Once deleted, you will not be able to retrive it",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}