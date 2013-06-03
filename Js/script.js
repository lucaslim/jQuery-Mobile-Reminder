$(document).ready(function () {
    $('.mark-complete').on({
        click: function() {
            var isComplete = $(this).attr('data-icon') == 'check' ? 'false' : 'true';
            $.ajax({
                type: "GET",
                url: "MarkComplete.ashx",
                data: { c: isComplete, id: get_querystring('id') },
                success: function(data) {
                    if (data.success) {
                        location.reload();
                    }
                }
            });
        }
    });
});

function get_querystring(val) {
    val = val.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var results =  new RegExp("[\\?&]" + val + "=([^&#]*)").exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}