$(document).ready(function () {
    function loadPartial(viewName) {
        $.ajax({
            url: `/Home/${viewName}`,
            type: 'GET',
            success: function (data) {
                $('.content-wrapper').html(data);
            }
        });
    }

    $('#loadFacebook').click(function (e) {
        e.preventDefault();
        loadPartial('LoadFacebookPartial');
    });

    $('#loadYoutube').click(function (e) {
        e.preventDefault();
        loadPartial('LoadYoutubePartial');
    });

    $('#loadTiktok').click(function (e) {
        e.preventDefault();
        loadPartial('LoadTiktokPartial');
    });

    $('#loadClient').click(function (e) {
        e.preventDefault();
        loadPartial('LoadClientPartial');
    });
});
