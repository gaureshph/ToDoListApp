$(document).ready(function () {
    window.onclick = function (e) {
        if ($(e.target).parents('.glyphiconIconContainerUserProfile').length > 0) {

        }
        else {
            if ($('#ulTopNavDropDownList').hasClass('forceDisplayInlineBlock')) {
                $('#ulTopNavDropDownList').removeClass('forceDisplayInlineBlock');
            }
        }
    };
});

$('.glyphiconIconContainerUserProfile').off('click').on('click', function () {
    if (!$('#ulTopNavDropDownList').hasClass('forceDisplayInlineBlock')) {
        $('#ulTopNavDropDownList').addClass('forceDisplayInlineBlock');
    }
    else {
        $('#ulTopNavDropDownList').removeClass('forceDisplayInlineBlock');
    }
});