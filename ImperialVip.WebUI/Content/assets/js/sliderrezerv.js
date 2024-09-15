
(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        var alisNoktasi = document.getElementById("AlisNoktasiId");

        alisNoktasi.addEventListener("change", function (event) {
            var id = event.target.value;
            $.ajax({
                url: "/tr/VarisNoktasiBelirle",
                data: { alisNoktasiId: id },
                type: "POST",
                dataType: "Json",
                success: function (data) {
                    $("#VarisNoktasiId").empty(); $("#VarisNoktasiId").append("<option value='' >Varış Noktası Seçiniz</option>")
                    for (var i = 0; i < data.length; i++) {
                        $("#VarisNoktasiId").append("<option value='" + data[i].Value + "' >" +
                            data[i].Text + "</option>")
                    }
                }
            });
        });
    });
})();