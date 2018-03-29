$(function () {

    var input = $("#file").value;
    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imgpreview').css('visibility', 'visible');
            $('#imgpreview').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }

});