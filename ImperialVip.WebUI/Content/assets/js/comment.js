
(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        document.getElementById("comments").addEventListener("submit", function (event) {
            event.preventDefault();

            const adSoyad = document.querySelector('input[name="AdSoyad"]').value;
            const memnuniyetOyu = document.querySelector('input[name="MemnuniyetOyu"]').value;
            const yorum = document.querySelector('textarea[name="Yorum"]').value;

            var yorumModel = {
                AdSoyad: adSoyad,
                MemnuniyetOyu: memnuniyetOyu,
                Yorum: yorum
            };

            $.ajax({
                type: "POST",
                dataType: "Json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(yorumModel),
                url: "/Yorumlar",
                success: function (data) {
                    if (data.success === true) {
                        document.getElementById('comments').reset();
                        toastr.success(data.message, "", {
                            "closeButton": true,
                            "progressBar": true,
                            "timeOut": "5000"
                        })
                    }
                    else {
                        toastr.warning(data.message, "", {
                            "closeButton": true,
                            "progressBar": true,
                            "timeOut": "5000"
                        })
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error(error, "", {
                        "closeButton": true,
                        "progressBar": true,
                        "timeOut": "5000"
                    })
                }
            });
        });
    });
})();