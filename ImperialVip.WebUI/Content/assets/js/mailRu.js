
(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {

        document.getElementById("emailUsRu").addEventListener("submit", function (event) {
            event.preventDefault();

            const adSoyad = document.querySelector('input[name="AdSoyad"]').value;
            const telefon = document.querySelector('input[name="Telefon"]').value;
            const email = document.querySelector('input[name="Email"]').value;
            const mesaj = document.querySelector('textarea[name="Mesaj"]').value;

            var bizeUlasinModel = {
                AdSoyad: adSoyad,
                Telefon: telefon,
                Email: email,
                Mesaj: mesaj
            };

            $.ajax({
                type: "POST",
                dataType: "Json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(bizeUlasinModel),
                url: "/ru/ContactUs",
                success: function (data) {
                    if (data.success === true) {
                        document.getElementById('emailUsRu').reset();
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
        document.getElementById("commentsRu").addEventListener("submit", function (event) {
            event.preventDefault();

            const adSoyad = document.querySelector('input[name="CommentAdSoyad"]').value;
            const memnuniyetOyu = document.querySelector('input[name="CommentMemnuniyetOyu"]').value;
            const yorum = document.querySelector('textarea[name="CommentYorum"]').value;

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
                url: "/ru/Comments",
                success: function (data) {
                    if (data.success === true) {
                        document.getElementById('commentsRu').reset();
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