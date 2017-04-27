(function () {
    angular.module('asasoft.licenseinfo',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('licenseinfolist', {
            url: '/licenseinfo-list',
            parent: 'base',
            templateUrl: "/app/components/admin/licenseinfo/licenseInfoListView.html",
            controller: "licenseInfoListController"
        })
         .state('licenseinfodetail', {
             url: '/licenseinfo-detail/:id',
             parent: 'base',
             templateUrl: "/app/components/admin/licenseinfo/licenseInfoDetailView.html",
             controller: "licenseInfoDetailController"
         })
        .state('licenseinfoadd', {
            url: '/licenseinfo-add',
            parent: 'base',
            templateUrl: "/app/components/admin/licenseinfo/licenseInfoAddView.html",
            controller: "licenseInfoAddController"
        });
    }
})();