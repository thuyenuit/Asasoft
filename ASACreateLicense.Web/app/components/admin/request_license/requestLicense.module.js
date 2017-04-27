(function () {
    angular.module('asasoft.requestlicense',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('requestlicense', {
            url: "/request-license",
            parent: 'base',
            templateUrl: "/app/components/admin/request_license/requestLicenseListView.html",
            controller: "requestLicenseListController"
        })
         .state('requestlicensedetail', {
             url: '/requestlicense-detail/:id',
             parent: 'base',
             templateUrl: "/app/components/admin/request_license/requestLicenseDetailView.html",
             controller: "requestLicenseDetailController"
         });
    }
})();