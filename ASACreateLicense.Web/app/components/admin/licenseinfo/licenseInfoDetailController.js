(function (app) {

    app.controller('licenseInfoDetailController', licenseInfoDetailController);

    licenseInfoDetailController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams']; // khởi tạo

    function licenseInfoDetailController($scope, apiService, notificationService, $stateParams) {
        $scope.licenseInfo = {}
       
        function loadLicenseInfoDetail() {
            var url = 'api/licenseinfo/getbyid/' + $stateParams.id;
            apiService.get(url, null, function (result) {
                $scope.licenseInfo = result.data;
                //$.each($scope.licenseInfo, function (i, item) {
                //    $scope.customerName = item.CustomerName;
                //    $scope.serverName = item.ServerName;
                //    $scope.contractNumber = item.ContractNumber;
                //    $scope.contractTypeName = item.ContractTypeName;
                //    $scope.createDate = item.CreateDate;
                //    $scope.updateDate = item.UpdateDate;
                //    $scope.endDate = item.EndDate;
                //    $scope.status = item.StatusLicenseName;
                //    $scope.keys = item.Keys;
                //    $scope.license = item.License;
                //});
            }, function () {
                notificationService.displayError('Không có dữ liệu! Vui lòng kiểm tra lại.');
            })
        }

        loadLicenseInfoDetail();
       
    }
})(angular.module('asasoft'));