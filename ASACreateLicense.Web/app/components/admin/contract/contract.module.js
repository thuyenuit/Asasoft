(function () {
    angular.module('asasoft.contract',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('contractlist', {
                url: '/contract-list',
                parent: 'base',
                templateUrl: "/app/components/admin/contract/contractListView.html",
                controller: "contractListController"
            }).state('contractadd', {
                url: '/contract-add',
                parent: 'base',
                templateUrl: "/app/components/admin/contract/contractAddView.html",
                controller: "contractAddController"
            }).state('contractedit', {
                url: '/contract-edit/:id',
                parent: 'base',
                templateUrl: "/app/components/admin/contract/contractEditView.html",
                controller: "contractEditController"
            }).state('contractsdetail', {
               url: '/contract-detail/:id',
               parent: 'base',
               templateUrl: "/app/components/admin/contract/contractsDetailView.html",
               controller: "contractsDetailController"
           });
    }
})();