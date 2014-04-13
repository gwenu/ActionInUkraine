$(".upload").change(function () {
    var fileObj = this,
        file;

    if (fileObj.files) {
        file = fileObj.files[0];
        var fr = new FileReader;
        fr.onloadend = changeimg;
        fr.readAsDataURL(file)
    } else {
        file = fileObj.value;
        changeimg(file);
    }
});

function onbrowse() {
    document.getElementById('browse').click();
}

function changeimg(str) {
    if (typeof str === "object") {
        str = str.target.result; // file reader
    }

    $(".unknown").css({
        "background-size": "100px 100px",
        "background-image": "url(" + str + ")"
    });
}