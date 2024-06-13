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

    // Thêm lớp active vào thẻ li khi thẻ a được click
    $('.nav-item .nav-link').click(function (e) {
        e.preventDefault();
        // Xóa lớp active khỏi tất cả các thẻ li
        $('.nav-item').removeClass('active');
        // Thêm lớp active vào thẻ li chứa thẻ a được click
        $(this).closest('.nav-item').addClass('active');
    });

    $('#loadDashboard').click(function (e) {
        e.preventDefault();
        var id = $(this).data('iduser');
        loadPartial('LoadDashboardPartial', id);
    });

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

    $('#loadAction').click(function (e) {
        e.preventDefault();
        var iduser = $(this).data('iduser');
        loadPartial('LoadActionPartial', iduser);
    });
});
