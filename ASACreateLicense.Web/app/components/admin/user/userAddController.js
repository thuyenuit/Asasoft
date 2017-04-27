
(function (app) {

    app.controller('userAddController', userAddController);

    userAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function userAddController($scope, $state, apiService, notificationService, commonService) {
        $scope.userinfo = {};

        $scope.AddUser = AddUser;
        $scope.ChooseImage = ChooseImage;
        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.userinfo.Avatar = fileUrl;
            }
            finder.popup();
        }

        $scope.myFuncUsername = function () {
            $scope.testUsername = false;
            $scope.userinfo.Username = commonService.replaceCharacter($scope.userinfo.Username);
        };

        $scope.myFuncEmail = function () {
            $scope.testEmail = false;
        };
     
        function AddUser() {

            $scope.submitted = true;
            var checkValueInput = validationInput();
            var checkEmail = CheckEmail();
            var checkUsername = CheckUsername();
        
            if (checkValueInput === true && checkEmail === true && checkUsername === true) {
                var url = 'api/user/create';
                apiService.post(url, $scope.userinfo, function (result) {
                    if (result.data == false) {
                        notificationService.displayError('Thêm người dùng thất bại. Vui lòng kiểm tra lại!');
                    }
                    else {
                        notificationService.displaySuccess('Thêm người dùng thành công.');
                        $state.go('users');
                    }
                      
                }, function (error) {
                    notificationService.displayError('Thêm người dùng thất bại. Vui lòng kiểm tra lại!');
                })
            }
        }

        function CheckEmail() {
            var url = 'api/user/selectbyemail';
            var consfig = {
                params: {
                    email: $scope.userinfo.Email
                }
            }
            apiService.get(url, consfig, function (result) {
                if (result.data === true) {
                    $scope.testEmail = true;
                }
                else
                    $scope.testEmail = false;
            }, function (error) {
                $scope.testEmail = false;
            })

            if ($scope.testEmail === false) 
                return true;
        
            return false;
        }

        function CheckUsername() {
            var url = 'api/user/selectbyusername';
            var consfig = {
                params: {
                    username: $scope.userinfo.Username
                }
            }
            apiService.get(url, consfig, function (result) {
                if (result.data === true) {
                    $scope.testUsername = true;
                }
                else
                    $scope.testUsername = false;
            }, function (error) {
                $scope.testUsername = false;
            })

            if ($scope.testUsername === false)
                return true;

            return false;
        }

        function validationInput() {
            if (($scope.userinfo.Username != "" && $scope.userinfo.Username != undefined)
                && ($scope.userinfo.FullName != "" && $scope.userinfo.FullName != undefined)
                && ($scope.userinfo.Email != "" && $scope.userinfo.Email != undefined)
                && ($scope.userinfo.CellPhone != "" && $scope.userinfo.CellPhone != undefined)) {
                return true;
            }
            return false;
        }
    }

})(angular.module('asasoft.user'));
