(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$scope', '$state', 'apiService', '$ngBootbox', 'notificationService', 'Data']; // khởi tạo

    function rootController($scope,$state, apiService, $ngBootbox, notificationService, Data) {

        $scope.logOut = function () {
           // alert(Data.userlogin);
            $scope.username = Data.userlogin;
            //$scope.username = 'admin';
            $state.go('login');
        }

        $scope.lang = '';
        $scope.defaultLanguage = defaultLanguage;
        function defaultLanguage() {
            var url = 'api/dashboard/defaultlanguage';
            apiService.get(url, null, function (result) {
                $scope.lang = result.data;
            }, function () {

            })
        }
        $scope.defaultLanguage();

        $scope.setLanguage = function () {
            SetLanguage();
        }

        function SetLanguage() {

            var consfigs = {
                params: {
                    lgID: $scope.lang
                }
            }

            var url = 'api/dashboard/setlanguage';
            apiService.get(url, consfigs, function (result) {
                $scope.lang = result.data;
            }, function () {

            })
        }
    }
})(angular.module('asasoft'));