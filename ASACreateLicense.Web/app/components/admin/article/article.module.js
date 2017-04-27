(function () {
    angular.module('asasoft.article',
        ['asasoft.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('articles', {
            url: '/article-list',
            parent: 'base',
            templateUrl: "/app/components/admin/article/articleListView.html",
            controller: "articleListController"
        })
        .state('articleadd', {
            url: '/article-add',
            parent: 'base',
            templateUrl: "/app/components/admin/article/articleAddView.html",
            controller: "articleAddController"
        })
        .state('articleedit', {
            url: '/article-edit/:id',
            parent: 'base',
            templateUrl: "/app/components/admin/article/articleEditView.html",
            controller: "articleEditController"
        });
    }
})();