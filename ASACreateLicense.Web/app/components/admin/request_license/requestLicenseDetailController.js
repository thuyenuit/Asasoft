(function (app) {

    app.controller('requestLicenseDetailController', requestLicenseDetailController);

    requestLicenseDetailController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams']; // khởi tạo

    function requestLicenseDetailController($scope, apiService, notificationService, $stateParams) {
        $scope.requestLicense = {}

        function loadRequestLicenseDetail() {
            var url = 'api/requestlicenses/getbyid/' + $stateParams.id;
            apiService.get(url, null, function (result) {
                $scope.requestLicense = result.data;
                $.each($scope.requestLicense, function (i, item) {
                    $scope.customerName = item.CustomerName;
                    $scope.companyCode = item.CompanyCode;
                    $scope.company = item.Company;
                    $scope.serverName = item.ServerName;
                    $scope.keys = item.Keys;
                    $scope.phone = item.Phone;
                    $scope.fax = item.Fax;
                    $scope.email = item.Email;
                    $scope.address = item.Address;
                    $scope.cityName = item.CityName;
                    $scope.contracType = item.ContractTypeName;
                    $scope.status = item.StatusLicenseName;
                    $scope.createDate = item.CreateDate;
                    $scope.customerType = item.CustomerTypeName;
                });
            }, function () {
                notificationService.displayError('Không có dữ liệu! Vui lòng kiểm tra lại.');
            })
        }

        loadRequestLicenseDetail();

    }
})(angular.module('asasoft.requestlicense'));