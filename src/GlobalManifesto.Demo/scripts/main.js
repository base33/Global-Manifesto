$(document).ready(function() {
    /* NON-BREAKPOINT / NON-BROWSER SPECIFIC INITIATORS ================================================== */
	
	//OWL CAROUSEL MULTI CAROUSEL
	if($("#owl-multi-carousel").length > 0)
    {
        $("#owl-multi-carousel").owlCarousel({
            autoPlay: 3000, //Set AutoPlay to 3 seconds
            items : 4,
            itemsDesktop : [1199,3],
            itemsDesktopSmall : [979,3],
            lazyLoad : true
        });
    }
	
	//OWL CAROUSEL SINGLE CAROUSEL
    if($("#owl-single-carousel").length > 0)
    {
        $("#owl-single-carousel").owlCarousel({
            navigation : false, // Show next and prev buttons
            slideSpeed : 300,
            paginationSpeed : 400,
            singleItem:true,
            lazyLoad : true
         
            // "singleItem:true" is a shortcut for:
            // items : 1, 
            // itemsDesktop : false,
            // itemsDesktopSmall : false,
            // itemsTablet: false,
            // itemsMobile : false
        });
    }
    /* =================================================================================================== */

    /* BREAKPOINT / BROWSER SPECIFIC INITIATORS ========================================================== */
    //Breakpoint configuration
    var jRes = jRespond([{
        label: 'handheld',
        enter: 0,
        exit: 768
    }, {
        label: 'desktop',
        enter: 769,
        exit: 10000
    }]);

    //If IE8 or lower initiate desktop js, otherwise add breakpoint event handlers.
    if ($("html").hasClass("lt-ie9")) {
        enterDesktopJS();
    } else {
        /* HANDHELD BREAKPOINT DETECTOR ================================================================== */
        jRes.addFunc({
            breakpoint: 'handheld',
            enter: function() {
                enterHandheldJS();
            }
        });
        /* =============================================================================================== */

        /* DESKTOP DETECTOR ============================================================================== */
        jRes.addFunc({
            breakpoint: 'desktop',
            enter: function() {
                enterDesktopJS();
            }
        });
        /* =============================================================================================== */
    }

    /* HANDHELD INITIATORS =============================================================================== */
    function enterHandheldJS() {
        window.console && console.log("handheld breakpoint active");

        // handheld main navigation 
        $(function () {
            var pull = $('.btn-menu');
            submenu = $('.sub-menu');
            menu = $('.menu');
            menuHeight = menu.height();

            $(pull).on('click', function (e) {
                e.stopPropagation();
                if (submenu.is(':visible')) {
                    submenu.hide('fast');
                    pull.removeClass("menu-down");
                }
                e.preventDefault();
                menu.stop().fadeToggle();
                pull.addClass("menu-down")
                $(".search-bar").fadeToggle()
            });

            $(window).resize(function () {
                var w = $(window).width();
                if (w > 200 && menu.is(':hidden')) {
                    menu.removeAttr('style');
                }
            });
        });

        $('.btn-close').on("click", function () {
            $(this).parent().fadeOut();
        });

        //destroy desktop main nav menu
        $('ul.sf-menu').superfish('destroy');

        
        // sub-navigation
        $(function() {
            var pulli = $('#pull-i');
            menui = $('ul.sub-navigation');
            menuHeight = menui.height();

            $(pulli).on('click', function(e) {
                e.preventDefault();
                menui.slideToggle();
                pulli.toggleClass("menu-down");
            });
        });

        // switch owl slider desktop image to mobile
        $.each($("#hero #owl-single-carousel .owl-item img"), function (e) {
            var mobileImage = $(this).attr("data-mob-src");
            $(this).attr("src", mobileImage);
        });
    }
    /* =================================================================================================== */

    /* DESKTOP INITIATORS ================================================================================ */
    function enterDesktopJS() {
        window.console && console.log("desktop breakpoint active");
        // Turn off mobile main nav button
        $(".btn-menu").off();

        // enable main nav menu 
        $("ul.sf-menu").superfish();

        /* Disable trigger and remove style from submenu */
        if ($(".sub-navigation-block").length) {
            var pulli = $('#pull-i');
            menui = $('ul.sub-navigation');
            $(pulli).off();
            if (menui.is(':hidden')) {
                menui.removeAttr('style');
            }
        }

        // switch owl slider mobile image to desktop
        $.each($("#hero #owl-single-carousel .owl-item img"), function (e) {
            var desktopImage = $(this).attr("data-dt-src");
            $(this).attr("src", desktopImage);
        });
    }
    /* ================================================================================================== */
});

/* HELPERS ============================================================================================== */

/* ====================================================================================================== */