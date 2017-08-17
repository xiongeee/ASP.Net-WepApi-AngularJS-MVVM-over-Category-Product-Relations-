//angular da bir modüle ihtiyacımız var. öncelikle referansımızı yazalım ki, angular js içindeki kütüğhaneler çalışabilsin. 

/// <reference path="angular.js"/> 
/// <reference path="appmodule.js"/>

var app = angular.module("northapp", ["ngRoute",'naif.base64']); /*ikinci kısım dependency injection dır. Burada eksradan bir kütüphane kullanacaksak yazıyoruz içine. Yukarıda tanımlamış olduğumuz atıyoruz ngroot nesnesi var, root yapan, gidip onun direkt ismini yazıyoruz, çalışıyor. Değişik değişik şeyler var. ngmodules.org dan bakabilirsin. Önce js nesnesini indiriyorsunuz. Index içerisinde varsa angularjs in bir üstünde tanımlanmış ve iş yaptırmak istediğimiz bir modül, onu o araya tanımlarız isim olarak ve çalışır. Şimdi biz angular.route yükledik. Buraya onu yükleyeceğiz. BU uygulama üzerinde ngRoute yi kullanacağız. Bu naif.base64 ise angular-base64 den gelen dependency injection. Resimler için kullanacağız. */
app.controller("categoryCtrl", function ($scope) {  //bu scope two way datamining dediğimiz şeyi yapıyor. 

    $scope.ad = "Kamil";
}); //şimdi bunu nasıl aktaracağız. index içinde div ile ve ya başka şeyler ile ng-model ile çağır geç


//şimdi biraz ajax yapacağız. 
app.factory("api", function ($http) {
    var apiurl = "http://localhost:60614/api/"; //projemizin adresi

    //biraz bll e benziyor buradaki return bakınız.
    return {
        getallcategories: function (success) { //success callback function barındıtıyor.

            $http({
                url: apiurl + 'Category', //apiurl imiz bu. 
                method: 'GET',
                dataType: 'JSON' //tip bu

            }).then(function (response) {
                success(response.data); //iş success olursa response adında bir geri veri alacak. 
            });
        },
        getcategorybyid: function (id, success) {
            $http({
                url: apiurl + 'Category/'+id, //bu /id yi koymazsan kategori id si gelmez.  
                method: 'GET',
                dataType: 'JSON' //tip bu

            }).then(function (response) {
                success(response.data); //iş success olursa response adında bir geri veri alacak. 
                
            });
        },
        updatecategory: function (model, success) {
            $http({
                url: apiurl + 'Category/',  
                data:model,
                method: 'PUT', //update yi put ile
                dataType: 'JSON' //tip bu

            }).then(function (response) {
                success(response.data); //iş success olursa response adında bir geri veri alacak. 
            });
        },
        insertcategory: function (model, success) {
            $http({
                url: apiurl + 'Category/',
                data: model,
                method: 'POST', //insert ü put ile yaparuz. 
                dataType: 'JSON' 

            }).then(function (response) {
                success(response.data);  
            });
        },
        deletecategory: function (id, success) {
            $http({
                url: apiurl + 'Category/'+id,
                method: 'DELETE', //Silme işini Delete ile yaparız.  
                dataType: 'JSON'

            }).then(function (response) {
                success(response.data);
            });

        },
    }
});
//ajax kalıbı bu kadar. Yapı budur. Factory tanımla, url tanımla, fonksiyon döndür. Şimdi appcontrollere a gidelim kullanalım bunu

app.config(function ($routeProvider) {//rootprovider, ng-root tan gelmekte
    $routeProvider   
        .when('/', {/*hiç bir şey yazılmamışsa bu switch case gibi bu aşağıdaki.*/ 
            templateUrl: 'views/category.html', //viewlerin içindeki html leri gidecek index.html deki ng-view içine basacak.
            controller: 'categoryCtrl',
            controllersAs: 'category'

        })
        .when('/kategoriguncelle/:id', {/*detay id / varsa detay html detaycontroller kullan. id gibi parametreler böyle kullanılır. :id olarak yazılır, önüne iki nokta üstüste alır.*/
            templateUrl: 'views/kategoriguncelle.html', /*budosyaları Views klasörünün içinden çekiyor */
            controller: 'KategoriGuncelleCtrl',
            controllersAs: 'kategoriguncelle'

        })
        .when('/kategoriekle', {
            templateUrl: 'views/kategoriekle.html',
            controller: 'KategoriEkleCtrl',
            controllerAs:'kategoriekle'

        })
        .otherwise({/* Hiç bir şeyyoksa ana sayfaya yolla*/
            redirectTo: '/'

        });
});  