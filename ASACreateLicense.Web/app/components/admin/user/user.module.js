(function () {
    angular.module('asasoft.user',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('changepassword', {
            url: '/change-password',
            parent: 'base',
            templateUrl: "/app/components/admin/user/changepasswordView.html",
            controller: "changepasswordController"
        }).state('users', {
            url: '/users',
            parent: 'base',
            templateUrl: "/app/components/admin/user/userListView.html",
            controller: "userListController"
        })
        .state('useradd', {
            url: '/user-add',
            parent: 'base',
            templateUrl: "/app/components/admin/user/userAddView.html",
            controller: "userAddController"
        })
        .state('useredit', {
            url: '/user-edit/:username',
            parent: 'base',
            templateUrl: "/app/components/admin/user/userEditView.html",
            controller: "userEditController"
        });
    }
})();