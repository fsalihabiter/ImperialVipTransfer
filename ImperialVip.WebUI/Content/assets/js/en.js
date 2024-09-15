

(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        var emailUs = document.getElementById("emailUs");
        var comments = document.getElementById("commentUs");

        emailUs.addEventListener("submit", function (event) {

            var adSoyad = document.getElementById("AdSoyad");
            var telefon = document.getElementById("Telefon");
            var email = document.getElementById("Email");
            var mesaj = document.getElementById("Mesaj");

            const bizeUlasinModel = {
                AdSoyad: adSoyad,
                Telefon: telefon,
                Email: email,
                Mesaj: mesaj
            }

            $.ajax({
                url: "/en/EmailUs",
                data: JSON.stringify(bizeUlasinModel),
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "Json",
                success: function (data) {
                    if (data.success === true) {
                        document.getElementById('rezervasyonForm').reset();
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
                    console.log(xhr);
                    toastr.success(error, status, {
                        "closeButton": true,
                        "progressBar": true,
                        "timeOut": "5000"
                    })
                }
            });
        });
        comments.addEventListener("submit", function (event) {

            var adSoyad = document.getElementById("AdSoyad");
            var telefon = document.getElementById("Telefon");
            var email = document.getElementById("Email");
            var mesaj = document.getElementById("Mesaj");

            const bizeUlasinModel = {
                AdSoyad: adSoyad,
                Telefon: telefon,
                Email: email,
                Mesaj: mesaj
            }

            $.ajax({
                url: "/en/Comments",
                data: JSON.stringify(bizeUlasinModel),
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "Json",
                success: function (data) {
                    if (data.success === true) {
                        document.getElementById('rezervasyonForm').reset();
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
                    console.log(xhr);
                    toastr.success(error, status, {
                        "closeButton": true,
                        "progressBar": true,
                        "timeOut": "5000"
                    })
                }
            });
        });
    });
})();