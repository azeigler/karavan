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
            modalShow('.js-modal');
            $(".js-imageInfoContainer").height(($(".js-imagePreviewContainer").height() + 30) + "px");
            var commentsPanelHeight = $(".js-imageInfoContainer").height() - $(".js-locationPanel").height();
            $(".js-commentsPanel").height((commentsPanelHeight - 30) + "px");
            return false;
        });
    }
}

k.init();






