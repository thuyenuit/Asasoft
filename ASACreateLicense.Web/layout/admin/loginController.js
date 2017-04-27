(function (app) {

    app.controller('loginController', loginController);

    loginController.$inject = ['$scope', '$state'];
    function loginController($scope, $state) {
        $scope.loginSubmit = function () {
            alert("vô");
            //$state.go('baseadminA');
        }
    }
})(angular.module('asasoft'));