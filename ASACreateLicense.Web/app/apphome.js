/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('asasoft.home',
        ['asasoft.common.home']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: "/home",
                templateUrl: "/app/components/client/home/homeView.html",
                controller: "homeController"
            })
             .state('requestlicense', {
                 url: "/request-license",
                 templateUrl: "/app/components/client/request_license/requestLicenseView.html",
                 controller: "requestLicenseController"
             })
            .state('contact', {
                url: "/contact",
                templateUrl: "/app/components/client/contact/contactView.html",
                controller: "contactController"
            });

        $urlRouterProvider.otherwise('/home');
    }
})();
