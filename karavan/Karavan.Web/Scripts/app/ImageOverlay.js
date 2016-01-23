function hideAllPanels () {
    $('.js-overlayPanel .imagePanel-overlay').animate({ 'margin-top': '0', 'height': '0' }, 300);
    $('.js-overlayPanel .imagePanel-overlayText').hide().animate({ 'margin-top': '0', 'height': '100px', 'display': 'none' }, 300);
    $('.js-overlayPanel').data('hidden', true);
    if ($('.js-moreOptions-button span').hasClass('glyphicon-chevron-down')) {
        $('.js-moreOptions-button span').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    };
}

var k = {

    init: function () {
        $('.js-moreOptions-button').click(function () { k.hideOrShowPanel('moreOptions') });
        $('.js-comments-button').click(function () { k.hideOrShowPanel('comments') });
    },

    hideOrShowPanel: function (panelName) {
        if ($('.js-' + panelName + '-panel').data('hidden') === true) {
            hideAllPanels();
            k.showPanel(panelName);
        } else {
            k.hidePanel(panelName)
        }
    },

    hidePanel: function(panel) {
        $('.js-' + panel + '-panel .imagePanel-overlay').stop().animate({ 'margin-top': '0', 'height': '0' }, 300);
        $('.js-' + panel + '-panel .imagePanel-overlayText').stop().hide().animate({ 'margin-top': '0', 'height': '100px', 'display': 'none' }, 300, function () {
            $('.js-' + panel + '-panel').data('hidden', true);
            if ($('.js-' + panel + '-button span').hasClass('glyphicon-chevron-down')) {
                $('.js-' + panel + '-button span').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
            };
            console.log('hide' + panel);
        });       
    },

    showPanel: function(panel) {
        $('.js-' + panel + '-panel .imagePanel-overlay').stop().animate({ 'margin-top': '-136px', 'height': '100px' }, 300);
        $('.js-' + panel + '-panel .imagePanel-overlayText').stop().animate({ 'margin-top': '-145px', 'height': '0', 'display': 'block' }, 300, function () {
            $('.js-' + panel + '-panel .imagePanel-overlayText').show();
            if ($('.js-' + panel + '-button span').hasClass('glyphicon-chevron-up')) {
                $('.js-' + panel + '-button span').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
            };
            $('.js-' + panel + '-panel').data('hidden', false);
            console.log('show' + panel);
        });
    }
}

k.init();






