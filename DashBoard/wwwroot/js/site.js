$(document).ready(function () {
    function loadPartial(viewName, id) {
        $.ajax({
            url: `/Home/${viewName}`,
            data: { iduser: id },
            type: 'GET',
            success: function (data) {
                $('.content-wrapper').html(data);
            }
        });
    }


    $('#loadFacebook').click(function (e) {
        e.preventDefault();
        var id = $(this).data('iduser');
        loadPartial('LoadFacebookPartial', id);
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
