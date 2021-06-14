    $(document).ready(function () {

    var btnLanguage = undefined

    $(".btn-language__main").mouseup(function (e) {

        if (btnLanguage) {
            $(btnLanguage[0].parentNode).find(".btn-language__list").css("height", "0");
            btnLanguage = undefined;

        } else {
            var elemt = $(this);
            $(elemt[0].parentNode).find(".btn-language__list").css("height", "auto");
            btnLanguage = elemt;
        }
    })

    $(".btn-language").click(function (e) {
        e.stopPropagation()
    })

    $("body").click(function () {
        if (btnLanguage) {
            $(btnLanguage[0].parentNode).find(".btn-language__list").css("height", "0");
            btnLanguage = undefined
        }
    })

    $(".btn-language__list__item").mouseup(function () {

        var linkImg = $(this).css("background-image")
        $(".btn-language__main").css("background-image", linkImg)

        $(btnLanguage[0].parentNode).find(".btn-language__list").css("height", "0");
        btnLanguage = undefined;

    })

    // ---

    var arrayDescriptionNews = $(".new__description-content")
    var arrProducts = $(".products__content")
    var arrAbouts = $(".abouts__content")
    var arrIndustries = $(".industries__content")

    var shortenText = (arrText) => {

        for (let index = 0; index < arrText.length; index++) {

            var text = arrText[index].innerHTML

            if (text.length > 150) {
                var newText = text.substr(0, 140);

                arrText[index].innerHTML = newText + ' ...';
            }
        }
    }

    if (arrayDescriptionNews.length > 0) shortenText(arrayDescriptionNews)
    if (arrProducts.length > 0) shortenText(arrProducts)
    if (arrAbouts.length > 0) shortenText(arrAbouts)
    if (arrIndustries.length > 0) shortenText(arrIndustries)

    // --- 

    $(".header .list-nav").mouseover(function () {
        $(this).find("ul").addClass("list-nav__link-active");
    });


    $(".header .list-nav").mouseout(function () {
        $(this).find("ul").removeClass("list-nav__link-active");
    });

    // ---

    $(".btn-menu").click(function () {
        $(".mobile-menu").css("width", "100%");
        setTimeout(() => {
            $("main").css("display", "none");

        }, 200);
    })

    $(".btn-close-menu").click(function () {
        $(".mobile-menu").css("width", "0");
        $("main").css("display", "block");
    })

    // ---


    var elementMobileMenu = undefined


    $(".header .mobile-menu form").click(function () {
        closeMobileMenu()
    });

    $(".header .mobile-menu button").click(function () {
        closeMobileMenu()
    });

    var closeMobileMenu = () => {
        if (elementMobileMenu) {

            var elemt = $(elementMobileMenu)
            var elemtParent = $(elemt[0].parentNode)

            $(elemtParent).find(".mobile-menu__btn-open").removeClass("d-none")
            $(elemtParent).find(".mobile-menu__btn-close").addClass("d-none")

            $(elemtParent[0].parentNode).find("ul").removeClass("mobile-menu__list-nav__link-active");

            elementMobileMenu = undefined

        }
    }


    $(".mobile-menu__btn-open").click(function () {

        var elemt = $(this)
        var elemtParent = $(elemt[0].parentNode)

        $(elemtParent).find(".mobile-menu__btn-open").addClass("d-none")
        $(elemtParent).find(".mobile-menu__btn-close").removeClass("d-none")

        $(elemtParent[0].parentNode).find("ul").addClass("mobile-menu__list-nav__link-active");

        elementMobileMenu = this
    })

    $(".mobile-menu__btn-close").click(function () {
        closeMobileMenu()
    })

    // ---

    var btnLeftMenu = undefined

    $(".left-menu__btn-open").click(function () {

        if (btnLeftMenu) {
            var elemt2 = $(btnLeftMenu)
            var elemtParent2 = $(elemt2[0].parentNode)

            $(elemtParent2).find(".left-menu__btn-open").removeClass("d-none")
            $(elemtParent2).find(".left-menu__btn-close").addClass("d-none")

            var x = $(elemtParent2[0].parentNode).find(".left-menu__sub-menu").css("height", "0")
        }

        var elemt = $(this)
        var elemtParent = $(elemt[0].parentNode)

        $(elemtParent).find(".left-menu__btn-open").addClass("d-none")
        $(elemtParent).find(".left-menu__btn-close").removeClass("d-none")

        $(elemtParent[0].parentNode).find(".left-menu__sub-menu").css("height", "100%")

        btnLeftMenu = this
    })


    $(".left-menu__btn-close").click(function () {
        var elemt = $(this)

        var elemtParent = $(elemt[0].parentNode)

        $(elemtParent).find(".left-menu__btn-open").removeClass("d-none")
        $(elemtParent).find(".left-menu__btn-close").addClass("d-none")

        var x = $(elemtParent[0].parentNode).find(".left-menu__sub-menu").css("height", "0")
    })
})