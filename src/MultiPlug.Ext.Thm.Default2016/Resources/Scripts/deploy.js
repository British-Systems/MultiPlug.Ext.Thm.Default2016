﻿$(".btn-deploy").click(function (event) {
    event.preventDefault();

    var theRow = $(this).closest("tr");

    $.post($(this).attr('href'), function (data) {

    })
    .done(function () {
        $('.top-right').notify({
            message: {
                text: 'Recipes have been deployed and saved.'
            },
            type: 'adminflare'
        }).show()
    });
});