

(function (app) {

    app.controller('contractsDetailController', contractsDetailController);
    contractsDetailController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', '$sce'];
    function contractsDetailController($scope, apiService, notificationService, $stateParams, $sce) {

        $scope.contractinfo = {};
        $scope.loadContractInfo = loadContractInfo;
        function loadContractInfo() {
            var consfig = {
                params: {
                    id: $stateParams.id
                }
            }
            var url = 'api/contract/getbyid';
            apiService.get(url, consfig, function (result) {
                $scope.contractinfo = result.data;
                $scope.contractinfo.ContractContent = $sce.trustAsHtml($scope.contractinfo.ContractContent);
                loadCustomer($scope.contractinfo.CustomerID);         
            }, function () {
                console.log('Load thông tin hợp đồng thất bại!');
            })
        }
        loadContractInfo();    

        $scope.unitinfo = {};
        $scope.getUnitInfo = getUnitInfo;
        function getUnitInfo() {
            var url = 'api/other/unitinfo';
            apiService.get(url, null, function (result) {
                $scope.unitinfo = result.data;
            }, function () {
                console.log('Load thông tin thất bại!');
            })
        }
        $scope.getUnitInfo();

        function loadCustomer(customerId) {
            var consfig = {
                params: {
                    id: customerId
                }
            }
            var url = 'api/customerinfo/getbyid/id=' + customerId;
            apiService.get(url, consfig, function (result) {
                $scope.customerinfo = result.data;             
            }, function () {
                console.log('Không thể load');
            });
        }
      
    }
})(angular.module('asasoft.contract'));