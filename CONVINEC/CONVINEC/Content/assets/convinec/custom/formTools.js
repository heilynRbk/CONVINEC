﻿$(document).ready(function () {
    $('#fkOccupation').select2({
        theme: 'bootstrap4',
        width: 'style'
    });

    $("#DNI").mask("9-0999-0999");
    $('#birthdate').datepicker({
        format: 'dd/mm/yyyy',
        maxDate: '01/01/2002',
        minDate: '01/01/1985',
        uiLibrary: 'materialdesign',
        icons: {
            rightIcon: ' <i class="mdi mdi-cake-variant"></i>'
        }
    });
});