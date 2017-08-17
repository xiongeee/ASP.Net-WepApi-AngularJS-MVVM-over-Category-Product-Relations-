/// <reference path="angular.js"/> 
/// <reference path="appmodule.js"/>

app.controller("categoryCtrl", function ($scope,api) {  //bu scope two way datamining dediğimiz şeyi yapıyor. 

    $scope.ad = "Kamil";
    $scope.kategoriler = [];
    $scope.getir = function () {
        api.getallcategories(function (response) {
            $scope.kategoriler = response;
            console.log(response);
        });
    }
    $scope.sil = function (id) { //sil modülünü de controllerinu da yazdık. Şimdi kullanacağız burada. 
        var kategori = {};
        var index = 0;
        for (var i = 0; i < $scope.kategoriler.length; i++) {
            if ($scope.kategoriler[i].categoryID==id) {
                kategori = $scope.kategoriler[i];
                index = i;
                break;
            }
        }
        if (confirm(kategori.categoryName+" isimli kategori silinecektir")) {
            api.deletecategory(id, function (data) {
                alert(data.message);
                $scope.getir();
            });
        } else {
            alert("Tamam silmedim");
        }
    };
});
//şimdi bunun tetiklenmesi için index içinde bir buton yapıp kullanalım.
app.controller("KategoriGuncelleCtrl",
    function ($scope, api, $routeParams) { /* id parametresini taşıyabilmek için routeparamsı kullanıyoruz.
        $scope.kategori = {}; /*boş olarak bir kategori tanımladık*/
        $scope.id = $routeParams.id;
        api.getcategorybyid($routeParams.id,
            function (data) {
                console.log(data);
                $scope.kategori = data; /*data burada app module de getcategorybyid deki response.data*/
            });
        $scope.guncelle = function () {
            if ($scope.resim != null)
                $scope.kategori.Picture = $scope.resim.base64;
            api.updatecategory($scope.kategori,
                function (data) {
                    console.log(data);
                    $scope.message = data.message;
                });
        };
    });

app.controller("KategoriEkleCtrl",  //bu controller isimlerini modüllerin içinde çaırıyoruz. 
    function ($scope, api, $location) {
        $scope.ekle = function () {
            if ($scope.resim != null)
                $scope.kategori.Picture = $scope.resim.base64;
            api.insertcategory($scope.kategori,
                function (data) {
                    console.log(data);
                    $scope.message = data.message;
                    setTimeout(function () { //bu bir delay koyar. 
                        $location.path('/');
                    }, 1000);
                });
        };

    });
