// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function parseObservableResponseError(response) {
    if (response.hasOwnProperty("message"))
        return Observable.throw(response);
    if (response.hasOwnProperty("Message")) {
        response.message = response.Message;
        return Observable.throw(response);
    }

    // always create an error object
    let err = new ErrorInfo();
    err.response = response;
    err.message = response.statusText;

    try {
        let data = response.json();
        if (data && data.message)
            err.message = data.message;
    }
    catch (ex) { }

    if (!err.message)
        err.message = "Unknown server failure.";

    return Observable.throw(err);
};