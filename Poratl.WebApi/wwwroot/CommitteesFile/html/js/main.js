$(document).ready(function () {   

    $('.owl-ch').owlCarousel({

        rtl:true,
        margin:10,
        nav:true,
        dots:false,
        responsive:{
            0:{
                items:1,
                nav:false,
            },
            700:{
                items:2
            },
            1000:{
                items:1
            },
            1200:{
                items:2
            },
            1400:{
                items:3
            }
        }
    })
    $(".tap-itme li:first").addClass("active");
    $(".taps-contant").hide();
    $(".taps-contant:first").show();
    $(".tap-itme li").on("click", function () {
        $(".tap-itme li").removeClass("active");
        $(this).addClass("active");
        $(".taps-contant").hide();
        $($(this).data("taps")).fadeIn();

    });
    $('.owl-review').owlCarousel({
        loop:true,
        margin:10,
        rtl:true,
        nav:true,
        dots:false,
    
        responsive:{
            0:{
                items:1,
                nav:false,
            },
            600:{
                items:2
            },
            1000:{
                items:3
            }
        }
    })
  


    $('.item-nav-responsive div').on("click", function () {
        $(".item-nav").addClass('open')
    })
    $('.item-close div').on("click", function () {
        $(".item-nav").removeClass('open')
    });
    $('.item-i').on('keyup', function () {
        if (this.value.length >= 1) {
            $(this).next().focus();
            $(this).addClass('back');
        }
    });



    $(".list-back li").click(function () {
        $(".list-back li").removeClass("active");
        $(this).addClass("active");
    });
    
    $(".list-meal li").click(function () {
        $(".list-meal li").removeClass("active");
        $(this).addClass("active");
    });
});


