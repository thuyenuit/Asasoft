(function (app) {

    app.controller('rootController', rootController);

    rootController.$inject = ['$state', '$scope'];
    function rootController($state, $scope) {
        $scope.login = function () {
            $state.go('baseAdmin');
        } 
    }
})(angular.module('asasoft'));
