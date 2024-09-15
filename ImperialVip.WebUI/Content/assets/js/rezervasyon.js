
(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        var alisNoktasi = document.getElementById("AlisNoktasiId");

        alisNoktasi.addEventListener("change", varisNoktasiBelirle);

        function varisNoktasiBelirle(event) {
            var id = event.target.value;
            $.ajax({
                url: "/tr/VarisNoktasiBelirle",
                data: { alisNoktasiId: id },
                type: "POST",
                dataType: "Json",
                success: function (data) {
                    $("#VarisNoktasiId").empty();
                    for (var i = 0; i < data.length; i++) {
                        $("#VarisNoktasiId").append("<option value='" + data[i].Value + "' >" +
                            data[i].Text + "</option>")
                    }
                }
            });
        }

        /********************************************************************************************************* */
        // Dönüş transferi istiyorum işaretlenince Dönüş Bilgileri kısmı gösterilecek.
        var donustransferiCheck = document.querySelector("#DonusTransferi");
        const donusVarMi = donustransferiCheck.checked;

        if (donusVarMi) {
            document.getElementById("DonusBilgileri").style.display = "flex";
        }
        else {
            document.getElementById("DonusBilgileri").style.display = "none";
        }

        donustransferiCheck.addEventListener('change', handleChangeDonusTransferi);

        function handleChangeDonusTransferi() {
            var donustransferiCheck = document.querySelector("#DonusTransferi");
            const donusVarMi = donustransferiCheck.checked;

            if (donusVarMi) {
                document.getElementById("DonusBilgileri").style.display = "flex";
            } else {
                document.getElementById("DonusBilgileri").style.display = "none";
            }
        }
        /********************************************************************************************************* */

        /********************************************************************************************************* */
        // Yetişkin Bilgileri ile ilgili işlemler
        var yetiskinSayisiInput = document.getElementById('YetiskinSayisi');
        const yetiskinSayisi = parseInt(yetiskinSayisiInput.value);
        const yetiskinBilgileriDiv = document.getElementById("YetiskinBilgileri");

        /* Yetişkin sayısı 2 ve daha fazla olsuğunda ad soyad girilen alanın görünürlüğünü ayarlar */
        if (yetiskinSayisi > 1) {
            yetiskinBilgileriDiv.style.display = "block";
        } else {
            yetiskinBilgileriDiv.style.display = "none";
        }

        /* Yetişkin sayısı 2 ve daha fazla olsuğunda ad soyad girilen alanın her değişimde kontrol edilmesini sağlar */
        yetiskinSayisiInput.addEventListener('change', function (event) {
            const yetiskinSayisi = parseInt(event.target.value);

            if (yetiskinSayisi > 1) {
                yetiskinBilgileriDiv.style.display = "block";
            } else {
                yetiskinBilgileriDiv.style.display = "none";
            }
        });
        /********************************************************************************************************* */

        /********************************************************************************************************* */
        // Çocuk Bilgileri ile ilgili işlemler
        var cocukSayisiInput = document.getElementById('CocukSayisi');
        const cocukSayisi = parseInt(cocukSayisiInput.value);
        const cocukKisiBilgileriDiv = document.getElementById("CocukBilgileriDiv");
        const cocukKisiBilgileri = document.getElementById("CocukBilgileri");

        let cocukKoltuguDiv = document.getElementById("CocukKoltuguDiv");

        if (cocukSayisi > 0) {
            cocukKoltuguDiv.style.display = "block";
        }
        else {
            cocukKoltuguDiv.style.display = "none";
        }

        /* Çocuk sayısı 1 ve daha fazla olsuğunda ad soyad girilen alanın görünürlüğünü ayarlar */
        if (cocukSayisi > 0) {
            cocukKisiBilgileriDiv.style.display = "block";
        } else {
            cocukKisiBilgileriDiv.style.display = "none";
        }

        /* Çocuk sayısı 2 ve daha fazla olsuğunda ad soyad girilen alanın her değişimde kontrol edilmesini sağlar */
        cocukSayisiInput.addEventListener('change', function (event) {
            const cocukSayisi = parseInt(event.target.value);
            if (cocukSayisi > 0) {
                cocukKisiBilgileriDiv.style.display = "block";
            } else {
                cocukKisiBilgileriDiv.style.display = "none";
            }
        });
        /********************************************************************************************************* */

        /********************************************************************************************************* */
        // Yetişkin sayısı değiştiğinde güncellemeyi çalıştır
        yetiskinSayisiInput.addEventListener('change', yetiskinBilgiFields);

        // Yetişkin sayısı değiştiğinde güncelleyen fonksiyon
        function yetiskinBilgiFields() {
            let currentCount = yetiskinBilgileriDiv.children.length;
            let desiredCount = parseInt(yetiskinSayisiInput.value);

            // Kişi alanı ekleme
            while (currentCount < desiredCount) {
                currentCount++;
                const newPersonField = document.createElement('div');
                newPersonField.classList.add('mb-3');

                newPersonField.innerHTML = `
                    <div class="input-group">
                        <span class="input-group-text" id="basic-addon3">${currentCount}. Ad Soyad</span>
                        <input class="form-control" type="text" required="required" id="AdSoyad${currentCount}" aria-describedby="basic-addon3 basic-addon4" name="YetiskinAdSoyad">
                    </div>
                `;
                yetiskinBilgileriDiv.appendChild(newPersonField);
            }

            // Kişi alanı kaldırma
            while (currentCount > desiredCount) {
                yetiskinBilgileriDiv.removeChild(yetiskinBilgileriDiv.lastChild);
                currentCount--;
            }
        }
        /********************************************************************************************************* */

        /********************************************************************************************************* */
        // Yetişkin sayısı değiştiğinde güncellemeyi çalıştır
        cocukSayisiInput.addEventListener('change', cocukBilgiFields);

        // Yetişkin sayısı değiştiğinde güncelleyen fonksiyon
        function cocukBilgiFields() {
            let currentCount = cocukKisiBilgileri.children.length;
            let desiredCount = parseInt(cocukSayisiInput.value);

            // Kişi alanı ekleme
            while (currentCount < desiredCount) {
                currentCount++;
                const newPersonField = document.createElement('div');
                newPersonField.classList.add('mb-3');

                newPersonField.innerHTML = `
                    <div class="input-group">
                        <span class="input-group-text" id="basic-addon3">${currentCount}. Ad Soyad</span>
                        <input class="form-control" type="text" required="required" id="AdSoyad${currentCount}" aria-describedby="basic-addon3 basic-addon4" name="CocukAdSoyad">
                    </div>
                `;
                cocukKisiBilgileri.appendChild(newPersonField);
            }

            // Kişi alanı kaldırma
            while (currentCount > desiredCount) {
                cocukKisiBilgileri.removeChild(cocukKisiBilgileri.lastChild);
                currentCount--;
            }

            if (desiredCount > 0) {
                cocukKoltuguDiv.style.display = "block";
            }
            else {
                cocukKoltuguDiv.style.display = "none";
            }
            var cocukKoltuguInput = document.getElementById('CocukKoltuguSayisi');

            cocukKoltuguInput.setAttribute('max', desiredCount);
            
        }
        /********************************************************************************************************* */


        document.getElementById("rezervasyonForm").addEventListener("submit", function (event) {
            event.preventDefault(); // Formun otomatik gönderimini durduruyoruz.


            // Diğer form verilerini topluyoruz
            const alisNoktasi = document.querySelector('select[name="AlisNoktasiId"]').value;
            const varisNoktasi = document.querySelector('select[name="VarisNoktasiId"]').value;
            const aracId = document.querySelector('select[name="AracId"]').value;
            const gelisZamani = document.querySelector('input[name="GelisZamani').value;
            const ucusNumarasi = document.querySelector('input[name="UcusNumarasi"]').value;
            const donusTransferi = false;
            /*const donusTransferi = document.querySelector('input[name="DonusTransferi"]').checked;*/
            const donusTransferiElement = document.querySelector('input[name="DonusTransferi"]');
            if (donusTransferiElement) {
                donusTransferi = donusTransferiElement.checked;
            }
            const donusZamani = document.querySelector('input[name="DonusZamani"]').value;
            const donusUcusNumarasi = document.querySelector('input[name="DonusUcusNumarasi"]').value;
            const yetiskinSayisi = document.querySelector('input[name="YetiskinSayisi"]').value;
            const cocukSayisi = document.querySelector('input[name="CocukSayisi"]').value;
            const cocukKoltuguSayisi = document.querySelector('input[name="CocukKoltuguSayisi"]').value;
            const adSoyad = document.querySelector('input[name="AdSoyad"]').value;
            const telefon = document.querySelector('input[name="Telefon"]').value;
            const email = document.querySelector('input[name="Email"]').value;
            const ozelNot = document.querySelector('textarea[name="OzelNot"]').value;
            // Otel adı dropdown listesinden seçilen öğenin textini ve değerini alıyoruz
            const otelAdiSelect = document.querySelector('select[name="OtelAdi"]');
            const otelAdiText = otelAdiSelect.options[otelAdiSelect.selectedIndex].text;

            const fiyat = document.querySelector('#FiyatYaz').innerHTML;
            console.log("fiyat");
            console.log(fiyat);

            var currentLanguageElement = document.getElementById('currentLanguage');

            // Aria-valuetext değerini al
            var dilKodu = currentLanguageElement.getAttribute('aria-valuetext');

            // Yetişkin Ad Soyad bilgilerini al
            var yetiskinAdSoyadInputs = document.querySelectorAll('input[name="YetiskinAdSoyad"]');
            var yetiskinAdSoyadArray = Array.from(yetiskinAdSoyadInputs).map(function (input) {
                return {
                    AdSoyad: input.value,
                    YetiskinMi: 1
                };
            });

            // Çocuk Ad Soyad bilgilerini al
            var cocukAdSoyadInputs = document.querySelectorAll('input[name="CocukAdSoyad"]');
            var cocukAdSoyadArray = Array.from(cocukAdSoyadInputs).map(function (input) {
                return {
                    AdSoyad: input.value,
                    YetiskinMi: 0
                };
            });

            // Tüm kişileri birleştir
            var kisiBilgileri = yetiskinAdSoyadArray.concat(cocukAdSoyadArray);


            // Tüm bilgileri bir nesne içinde topluyoruz
            const rezervasyonBilgileri = {
                otelAdi: otelAdiText,
                alisNoktasi: alisNoktasi,
                varisNoktasi: varisNoktasi,
                aracId: aracId,
                gelisZamani: gelisZamani,
                ucusNumarasi: ucusNumarasi,
                donusTransferi: donusTransferi,
                donusZamani: donusZamani,
                donusUcusNumarasi: donusUcusNumarasi,
                yetiskinSayisi: yetiskinSayisi,
                cocukSayisi: cocukSayisi,
                cocukKoltuguSayisi: cocukKoltuguSayisi,
                adSoyad: adSoyad,
                telefon: telefon,
                email: email,
                ozelNot: ozelNot,
                dilKodu: dilKodu,
                fiyat: fiyat,
                KisiBilgileri: kisiBilgileri
            };

            // Nesneyi konsola yazdırıyoruz
            console.log(rezervasyonBilgileri);

            $.ajax({
                url: "/tr/Rezervasyon",
                data: JSON.stringify(rezervasyonBilgileri),
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


        /********************************************************************************************************* */

        document.getElementById("AlisNoktasiId").addEventListener("change", alisNoktasiYaz);
        function alisNoktasiYaz(event) {
            var alis = event.target.value;
            var varis = document.querySelector("#VarisNoktasiId").value;
            var arac = document.querySelector(" #AracId").value;
            const changeMod = "1";
            fiyatBelirle(alis, varis, arac, changeMod);
        }

        document.getElementById("VarisNoktasiId").addEventListener("change", varisNoktasiYaz);
        function varisNoktasiYaz(event) {
            var varis = event.target.value;
            var alis = document.querySelector("#AlisNoktasiId").value;
            var arac = document.querySelector(" #AracId").value;
            const changeMod = "2";
            fiyatBelirle(alis, varis, arac, changeMod);
        }

        document.getElementById("AracId").addEventListener("change", aracYaz);
        function aracYaz(event) {
            var arac = event.target.value;
            var alis = document.querySelector(" #AlisNoktasiId").value;
            var varis = document.querySelector("#VarisNoktasiId").value;
            const changeMod = "3";
            fiyatBelirle(alis, varis, arac, changeMod);
        }

        function fiyatBelirle(alisNoktasiId, varisNoktasiId, aracId, changeMod) {
            $.ajax({
                url: "/tr/FiyatBelirle",
                data: { alisNoktasiId, varisNoktasiId, aracId, changeMod },
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    ekranaYazdir(data.alis, data.varis, data.arac, data.fiyat);
                },
                error: function (xhr, status, error) {
                    console.error("Hata:", status, error);
                }
            });
        }

        //document.getElementById("OtelAdi").addEventListener("change", selectDegerYazdır);
        //function selectDegerYazdır(event) {
        //    var konum = event.target.id + "Yaz";
        //    document.getElementById(konum).innerHTML = event.target.options[event.target.selectedIndex].text;
        //}

        //document.getElementById("GelisZamani").addEventListener("change", inputDegerYazdır);

        //function inputDegerYazdır(event) {
        //    var konum = event.target.id + "Yaz";
        //    console.log(event.target.value);
        //    document.getElementById(konum).innerHTML = event.target.value.replace("T"," ");
        //}

        function ekranaYazdir(alis, varis, arac, fiyat) {
            document.getElementById("AlisNoktasiIdYaz").innerHTML = alis;
            document.getElementById("VarisNoktasiIdYaz").innerHTML = varis;
            document.getElementById("AracIdYaz").innerHTML = arac;
            document.getElementById("FiyatYaz").innerHTML = fiyat + "€";
        }
    });
})();