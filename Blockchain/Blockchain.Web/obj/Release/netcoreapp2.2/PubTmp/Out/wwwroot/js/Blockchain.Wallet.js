Blockchain = {};
Blockchain.Wallet = {

    CreateWallet: function () {
        var url = '/Home/CreateWallet';
        $('#modalWallet div.modal-body').load(url, function () {
            $('#modalWallet').modal({ show: true, backdrop: 'static' });
            Blockchain.Wallet._bindFormValidation('#modalWallet form');
        });
    },

    SaveWallet: function () {

        if ($('#modalWallet form').valid()) {
            $("#formWallet").submit();
            $('#modalWallet').modal('hide');
        }
        else {
            $('#modalWallet').modal('handleUpdate');
        }

    },

    Send: function () {
        var url = '/Home/Send';
        $('#modalTransfer div.modal-body').load(url, function () {
            $('#modalTransfer').modal({ show: true, backdrop: 'static' });
            Blockchain.Wallet._bindFormValidation('#modalTransfer form');
        });
    },

    SaveTransaction: function () {

        if ($('#modalTransfer form').valid()) {
            $("#formTransfer").submit();
            $('#modalTransfer').modal('hide');
        }
        else {
            $('#modalTransfer').modal('handleUpdate');
        }

    },

    RemoveTransaction: function (txId) {

        var modalConfirm = function (callback) {

            $("#mi-modal").modal('show');

            $("#modal-btn-si").on("click", function () {
                callback(true);
            });

            $("#modal-btn-no").on("click", function () {
                callback(false);
                $("#mi-modal").modal('hide');
            });
        };

        modalConfirm(function (confirm) {
            if (confirm) {
                var url = '/Home/RemoveTransaction?txId=' + txId;
                $.ajax({
                    url: url,
                    type: "GET",
                    success: function (retorno) {
                        $("#mi-modal").modal('hide');
                        location.reload();
                    }
                });

            } else {
                //Acciones si el usuario no confirma

            }
        });

    },

    _bindFormValidation: function (formSelector) {
        $(formSelector).removeData('validator');
        $(formSelector).removeData('unobtrusiveValidation');
        $(formSelector).each(function () { $.data($(this)[0], 'validator', false); }); //enable to display the error messages
        $.validator.unobtrusive.parse(formSelector);
    }

}