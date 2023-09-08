var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/anime/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'start_Date', "width": "15%" },
            { data: 'end_Date', "width": "10%" },
            { data: 'number_Of_Episodes', "width": "20%" },
            { data: 'genre.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/anime/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Editar</a>
                     <a onClick=Delete('/admin/anime/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Excluir</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Tem certeza?',
        text: "Essa ação é irreversível!",
        icon: 'warning',
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Deletar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}