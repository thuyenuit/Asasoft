/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('asasoft.admin',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('login', {
                url: '/admin/login',
                templateUrl: "Admin.html",               
                controller: "loginController"
            })
         .state('baseadminA', {
             url: '',
             templateUrl: "Admin.html",
             abstract: true
         })
            .state('homeadmin', {
                url: '/homeadmin',
               // parent: 'baseadminA',
                templateUrl: "/app/components/admin/home_admin/homeadminView.html",
                controller: "homeadminController"
            });
    }
})();