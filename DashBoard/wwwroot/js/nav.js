$(document).ready(function () {
    function loadPartial(viewName, iduser) {
        $.ajax({
            url: `/Home/${viewName}`,
            type: 'GET',
            data: { iduser: iduser },
            success: function (data) {
                $('.content-wrapper').html(data);
            }
        });
    }

    $('#loadFacebook').click(function (e) {
        e.preventDefault();
        var iduser = $(this).data('iduser');
        loadPartial('LoadFacebookPartial', iduser);
    });

    $('#loadYoutube').click(function (e) {
        e.preventDefault();
        var iduser = $(this).data('iduser');
        loadPartial('LoadYoutubePartial', iduser);
    });

    $('#loadTiktok').click(function (e) {
        e.preventDefault();
        var iduser = $(this).data('iduser');
        loadPartial('LoadTiktokPartial', iduser);
    });

    $('#loadClient').click(function (e) {
        e.preventDefault();
        var iduser = $(this).data('iduser');
        loadPartial('LoadClientPartial', iduser);
    });
});
