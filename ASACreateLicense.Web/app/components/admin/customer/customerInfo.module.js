(function () {
    angular.module('asasoft.customerinfo',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('customer', {
                url: '/customer',
                parent: 'base',
                templateUrl: "/app/components/admin/customer/customerInfoListView.html",
                controller: "customerListController"
            }).state('customer-add', {
                url: '/customer-add',
                parent: 'base',
                templateUrl: "/app/components/admin/customer/customerInfoAddView.html",
                controller: "customerAddController"
            }).state('customer-edit', {
                url: '/customer-edit',
                parent: 'base',
                templateUrl: "/app/components/admin/customer/customerInfoEditView.html",
                controller: "customerEditController"
            });
     
    }
})();