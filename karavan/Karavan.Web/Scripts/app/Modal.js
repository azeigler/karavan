function modalShow(modal) {
    $('.js-modal-bg').fadeIn();    
    $(modal).show();
}

function modalHide(modal) {
    $('.js-modal-bg').fadeOut();    
    $(modal).hide();
}

var k = {
    init: function () {
        $('.js-closeButton').click(function () {
            modalHide('.js-modal'); return false;
        });
        $('.js-gridImage').click(function () {
            modalShow('.js-modal'); return false;
        });
    },
}

k.init();






