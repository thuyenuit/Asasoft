/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('asasoft',
        ['asasoft.licenseinfo',
            'asasoft.contact',
            'asasoft.customerinfo',
            'asasoft.article',
            'asasoft.contract',
            'asasoft.requestlicense',
            'asasoft.user',
            'asasoft.common']).config(config); //.config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('base', {
            url: '',
            templateUrl: '/app/shared/view/baseView.html',
            abstract: true
        }).state('login', {
            url: "/login",
            templateUrl: "/app/components/admin/login/loginView.html",
            controller: "loginController"
        }).state('dashboard', {
             url: "/dashboard",
             parent: 'base',
             templateUrl: "/app/components/admin/dashboard/dashboardView.html",
             controller: "dashboardController"
         }).state('serverconfig', {
            url: "/serverconfig",
            parent: 'base',
            templateUrl: "/app/components/admin/server_config/serverConfigConnectView.html",
            controller: "serverConfigConnectController"
        });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();
