(function (app) {

    app.controller('serverConfigConnectController', serverConfigConnectController);

    serverConfigConnectController.$inject = ['$scope', 'apiService', 'notificationService', '$state']

    function serverConfigConnectController($scope, apiService, notificationService, $state) {

        $scope.serverConfig = {};
        $scope.ServerConfigConnect = ServerConfigConnect;
        function ServerConfigConnect() {
            $scope.submitted = true;
            var checkValueInput = validationInput();

            if(checkValueInput === true){
                var url = '/api/serverconfig/create';
                apiService.post(url, $scope.serverConfig, function (result) {
                    if (result.data === true)
                    {
                        $state.go('dashboard');
                        notificationService.displaySuccess('Bạn đã connect thành công.');
                    }
                       
                    else
                        notificationService.displayError('Connect thất bại');
                }, function (error) {
                    notificationService.displayError('Connect thất bại');
                    console.log('Connect Server thất bại');
                })
            }          
        }

        function validationInput() {
            if (($scope.serverConfig.ServerName != "" && $scope.serverConfig.ServerName != undefined)
                && ($scope.serverConfig.Password != "" && $scope.serverConfig.Password != undefined)
                && ($scope.serverConfig.Database != "" && $scope.serverConfig.Database != undefined)
                && ($scope.serverConfig.Option != "" && $scope.serverConfig.Option != undefined)
                && ($scope.serverConfig.UserName != "" && $scope.serverConfig.UserName != undefined)) {
                return true;
            }
            return false;
        }
    }

})(angular.module('asasoft'));