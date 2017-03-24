var camera;
var snapshot;

$(function () {
    camera = new JpegCamera("#camera");
});

$("#captureBtn").on("click", function () {
    snapshot = camera.capture();
    snapshot.show();
});

$("#validateBtn").on("click", function () {
    snapshot.get_blob(function (blob) {
        UploadPhtoto(blob);
    });
});

function UploadPhtoto(blob) {
    $.post("http://localhost:30967/picture", blob).done(function (response) {
        this.discard();
    }).fail(function (status_code, error_message, response) {
        alert("Upload failed with status " + status_code);
    });
}