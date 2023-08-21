$(document).ready(function () {
    var editor = CKEDITOR.instances['aciklama'];
    if (editor) {
        editor.destroy(true);
    }
    CKEDITOR.replace('aciklama', {
        enterMode: CKEDITOR.ENTER_BR,
        filebrowserUploadUrl: '/Home/UploadCKEDITOR',
        filebrowserBrowseUrl: '/Home/FileBrowserCKEDITOR',

    })
})