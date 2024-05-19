$(document).ready(function () {


    $('#btn-eliminar').click(function () {

        var guid = $(this).data('id');

        swal({
            title: "¿Estas seguro?",
            text: "Una vez que confirmes, no podras deshacer esta acción.",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then(async (willDelete) => {
                if (willDelete) {

                    var response = await fetch(`/User/DeleteUser/${guid}`, {
                        method: 'DELETE',
                    });

                    var responseData = await response.json();

                    swal(responseData.message, {
                        icon: "success",
                    });
                } else {
                    // Si el usuario hace clic en "no", muestra un mensaje de cancelación
                    swal("La accion ha sido cancelada.", {
                        icon: "info",
                    });
                }
            });


    });


    //$('#btn-save').click(function () {


    //    var formData = new FormData($('#formulario'));

    //    var response = await fetch(`/User`, {
    //        method: 'POST',
    //        body: formData
    //    });

    //})



});