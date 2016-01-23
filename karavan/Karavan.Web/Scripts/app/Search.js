var k = {

    init: function () {
        $('.js-hide-button').click(k.close);
        $('.js-edit-button').click(k.open);
    },

    close: function () {
        $('.js-searchPanel').slideUp(500);
        $('.js-hide-button').hide();
        $('.js-edit-button').show();
    },

    open: function () {
        $('.js-searchPanel').slideDown(500);
        $('.js-edit-button').hide();
        $('.js-hide-button').show();
    }
}

k.init();
