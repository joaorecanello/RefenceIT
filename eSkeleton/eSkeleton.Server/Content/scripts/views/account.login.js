$(document).ready(function () {
    
});

// método chamado quando existe problema de comunicação ao enviar a chamada de login para o servidor;
function onLoginFailure() {
    $.notify("Falha de comunicação!", "error");
}

// método chamado quando a requisição de login foi encaminhada com sucesso ao servidor;
function onLoginSuccess(data) {

    if (data.userValidated) {
        window.location.href = data.redirectUrl;
    } else {
        $.notify(data.error, "error");
        $('.initialFocus').focus();
    }

}