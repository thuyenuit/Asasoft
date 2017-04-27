(function (app) {

    app.controller('changepasswordController', changepasswordController);

    changepasswordController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService']; // khởi tạo

    function changepasswordController($scope, apiService, $ngBootbox, notificationService) {
        $scope.NewPassword = '';
        $scope.ConfirmPassword = '';

        $scope.userinfo = {
            Username: 'admin'
        };

        $scope.myFuncConfrimPass= function () {
            $scope.testConfirmPass = false;
        };
   
        $scope.ChangePassword = ChangePassword;
        function ChangePassword() {
            $scope.submitted = true;      
            var checkValueInput = validationInput();
            if (checkValueInput === true)
            {
                $scope.userinfo.Password = scope.NewPassword;
                var url = 'api/user/changepasss';
                apiService.put(url, $scope.userinfo, function (result) {
                    if (result.data === true)
                        notificationService.displaySuccess('Bạn đã đổi mật khẩu thành công.');
                }, function (error) {
                    notificationService.displayError('Đổi mật khẩu thất bại. Vui lòng kiểm tra lại');
                })
            }
        }

        function validationInput() {
            if (($scope.userinfo.Username != "" && $scope.userinfo.Username !== 'undefined')
                && ($scope.userinfo.Password != "" && $scope.userinfo.Password !== 'undefined')
                && ($scope.NewPassword != "" && $scope.NewPassword !== 'undefined')
                && ($scope.ConfirmPassword != "" && $scope.ConfirmPassword !== 'undefined')) {

                if ($scope.NewPassword != $scope.ConfirmPassword)
                {
                    $scope.testConfirmPass = true;
                    return false;
                }

                return true;
            }
            return false;
        }
    }
})(angular.module('asasoft'));