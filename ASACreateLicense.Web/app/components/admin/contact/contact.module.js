(function () {
    angular.module('asasoft.contact',
        ['asasoft.common']).config(config);

	config.$inject = ['$stateProvider', '$urlRouterProvider'];

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('contact', {
		    url: '/contact',
		    parent: 'base',
		    templateUrl: "/app/components/admin/contact/contactListView.html",
		    controller: "contactListController"
		});

	}
})();