(function (app) {
    app.controller('userEditController', userEditController);

    userEditController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$stateParams', 'commonService', '$state']; // khởi tạo

    function userEditController($scope, apiService, $ngBootbox, notificationService, $stateParams, commonService, $state) {
        $scope.userinfo = {};

        $scope.ChooseImage = ChooseImage;
        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.userinfo.Avatar = fileUrl;
            }
            finder.popup();
        }

        function loadUserInfo() {
            var consfig = {
                params: {
                    username: $stateParams.username
                }
            }
            var url = 'api/user/getbyusername';
            apiService.get(url, consfig, function (result) {
                $scope.userinfo = result.data;
            }, function () {
                notificationService.displayError('Không có dữ liệu! Vui lòng kiểm tra lại.');
            })
        }

        loadUserInfo();

        $scope.myFuncUsername = function () {
            $scope.testUsername = false;
            $scope.userinfo.Username = commonService.replaceCharacter($scope.userinfo.Username);
        };

        $scope.myFuncEmail = function () {
            $scope.testEmail = false;
        };

        $scope.EditUser = EditUser;
        function EditUser() {

            $scope.submitted = true;
            var checkValueInput = validationInput();
            var checkEmail = CheckEmail();

            if (checkValueInput === true && checkEmail === true) {
                var url = 'api/user/update';
                apiService.put(url, $scope.userinfo, function (result) {
                    if (result.data == false) {
                        notificationService.displayError('Cập nhật người dùng thất bại. Vui lòng kiểm tra lại!');
                    }
                    else {
                        notificationService.displaySuccess('Cập nhật người dùng thành công.');
                        $state.go('users');
                    }

                }, function (error) {
                    notificationService.displayError('Cập nhật người dùng thất bại. Vui lòng kiểm tra lại!');
                })
            }
        }

        function CheckEmail() {
            var url = 'api/user/checkemailuserwhenupdate';
            var consfig = {
                params: {
                    email: $scope.userinfo.Email,
                    username: $scope.userinfo.Username
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

        function validationInput() {
            if (($scope.userinfo.FullName != "" && $scope.userinfo.FullName != undefined)
                && ($scope.userinfo.Email != "" && $scope.userinfo.Email != undefined)
                && ($scope.userinfo.CellPhone != "" && $scope.userinfo.CellPhone != undefined)) {
                return true;
            }
            return false;
        }

    }
})(angular.module('asasoft.user'));