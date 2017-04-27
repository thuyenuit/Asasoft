(function (app) {

    app.controller('loginController', loginController);

    loginController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'Data'];

    function loginController($scope, $state, apiService, notificationService, Data) {
        $scope.loginSubmit = function () {

            //$scope.username = '';
            //$scope.password = '';

            var consfig = {
                params: {
                    userName: $scope.username,
                    password: $scope.password
                }
            }

            var url = 'api/account/login';
            apiService.get(url, consfig, function (result) {
                if (result.data === 0) {
                    Data.userlogin = $scope.username;
                    $state.go('dashboard');
                }
                else if (result.data === 1) {
                    notificationService.displayError('Tài khoản đã bị khóa. Vui lòng kiểm tra lại!');
                }
                else if (result.data === -1) {
                    notificationService.displayError('Tài khoản hoặc mật khẩu không đúng. Vui lòng kiểm tra lại!');
                }
            }, function () {
                notificationService.displayError('Đăng nhập thất bại. Vui lòng kiểm tra lại!');
            })
        }
    }

    app.factory('Data', function () {
        return { userlogin: '' };
    });

})(angular.module('asasoft'));