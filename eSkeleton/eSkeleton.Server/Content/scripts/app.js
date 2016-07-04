$(document).ready(function () {

    $('.initialFocus').focus();

});

function showProgress() {

    NProgress.start();

    setTimeout(function () {
        NProgress.done();
    }, 1000);

}

