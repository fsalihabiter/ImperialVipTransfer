
(function () {
    "use strict";

    document.addEventListener('DOMContentLoaded', function () {
        var alisNoktasi = document.getElementById("AlisNoktasiId");
        for (var i = 0; i < length; i++) {

        }
        var model = {
            alisNoktasiId = alisNoktasi.Value
            kisiler: 
        };
        alisNoktasi.addEventListener("change", function (event) {
            var id = event.target.value;
            $.ajax({
                url: "/Anasayfa/VarisNoktasiBelirle",
                data: JSON.stringify(model),
                type: "POST",
                dataType: "Json",
                success: function (data) {
                    $("#VarisNoktasiId").empty();
                    $("#VarisNoktasiId").append("<option value='' >Varış Noktası Seçiniz</option>")
                    for (var i = 0; i < data.length; i++) {
                        $("#VarisNoktasiId").append("<option value='" + data[i].Value + "' >" +
                            data[i].Text + "</option>")
                    }
                }
            });
        });

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
                        <input class="form-control" type="text" required="required" id="AdSoyad${currentCount}" aria-describedby="basic-addon3 basic-addon4" name="AdSoyad">
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
                        <input class="form-control" type="text" required="required" id="AdSoyad${currentCount}" aria-describedby="basic-addon3 basic-addon4" name="AdSoyad">
                    </div>
                `;
                cocukKisiBilgileri.appendChild(newPersonField);
            }

            // Kişi alanı kaldırma
            while (currentCount > desiredCount) {
                cocukKisiBilgileri.removeChild(cocukKisiBilgileri.lastChild);
                currentCount--;
            }

            console.log(desiredCount);
            if (desiredCount > 0) {
                cocukKoltuguDiv.style.display = "block";
            }
            else {
                cocukKoltuguDiv.style.display = "none";
            }
            var cocukKoltuguInput = document.getElementById('CocukKoltugu');

            cocukKoltuguInput.setAttribute('max', desiredCount);

        }
        /********************************************************************************************************* */

    });
})();