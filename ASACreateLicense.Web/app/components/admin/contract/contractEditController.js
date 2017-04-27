

(function (app) {

    app.controller('contractEditController', contractEditController);
    contractEditController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$stateParams', '$state'];
    function contractEditController($scope, apiService, $ngBootbox, notificationService, $stateParams, $state) {
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '800px'
        }       

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
            }, function () {
                console.log('Load thông tin hợp đồng thất bại!');
            })
        }
        loadContractInfo();   

       

        $scope.UpdateContract = UpdateContract;
        function UpdateContract() {

            $scope.submitted = true;
            var url = 'api/contract/update';
            apiService.put(url, $scope.contractinfo, function (result) {
                if (result.data == false) {
                    notificationService.displayError('Cập nhật hợp đồng thất bại. Vui lòng kiểm tra lại!');
                }
                else {
                    notificationService.displaySuccess('Cập nhật hợp đồng thành công.');
                    $state.go('contractlist');
                }

            }, function (error) {
                notificationService.displayError('Cập nhật hợp đồng thất bại. Vui lòng kiểm tra lại!');
            })
        }

        // change khách hàng
        $scope.customerinfo = {};
        $scope.myChangeCustomer = myChangeCustomer;
        function myChangeCustomer() {
            var consfig = {
                params: {
                    id: $scope.contractinfo.CustomerID
                }
            }

            var url = 'api/customerinfo/getbyid/id=' + $scope.contractinfo.CustomerID;
            apiService.get(url, consfig, function (result) {
                $scope.customerinfo = result.data;
                $scope.contractinfo.CustomerID = $scope.customerinfo.CustomerID;
            }, function () {
                console.log('Không thể load');
            });
        }

        // thông tin khách hàng
        $scope.customerList = [];
        $scope.loadCustomer = loadCustomer;
        function loadCustomer() {
           
            var url = 'api/customerinfo/getallcustomer';
            apiService.get(url, null, function (result) {
                $scope.customerList = result.data;
               // alert('ok');
                myChangeCustomer();
            }, function () {
                console.log('Không thể load');
            });
        }
        $scope.loadCustomer();

        // thông tin đơn vị
        $scope.unitinfo = {};
        $scope.getUnitInfo = getUnitInfo;
        function getUnitInfo() {
            var url = 'api/other/unitinfo';
            apiService.get(url, null, function (result) {
                $scope.unitinfo = result.data;
                $scope.contractinfo.UnitInfoID = $scope.unitinfo.ID;
            }, function () {
                console.log('Load thông tin thất bại!');
            })
        }
        $scope.getUnitInfo();    

        // danh sách loại hợp đồng
        $scope.contracttypeinfo = [];
        function loadContractType() {
            var url = 'api/other/getallcontracttype';
            apiService.get(url, null, function (result) {
                $scope.contracttypeinfo = result.data;
            }, function () {
                console.log('Không thể load');
            });
        }
        loadContractType();
    }
})(angular.module('asasoft.contract'));