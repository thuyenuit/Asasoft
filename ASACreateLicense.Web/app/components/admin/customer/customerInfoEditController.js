/// <reference path="C:\Users\PC\Desktop\New version\ASACreateLicense\ASACreateLicense.Web\Assets/admin/libs/angular/angular.min.js" />
(function (app) {

    app.controller('customerEditController', customerEditController);
    customerEditController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', 'myService', '$state']; // khởi tạo

    function customerEditController($scope, apiService, notificationService, $stateParams, myService, $state) {
        //Load city name
        var url = '/api/other/getallcity';
        apiService.get(url, null, function (result) {
            $scope.listCityName = result.data;
        }, function () {
        })
        //load Customer type
        var url2 = '/api/other/getallcustomertype';
        apiService.get(url2, null, function (result) {
            $scope.listCustomerType = result.data;
        }, function () {
        })
        
        $scope.formData = myService.get();
      
        $scope.UpdateCustomer = function () {
            //var consfig = {
            //    params: {
            //        cus: $scope.formData
            //    }
            //}
            apiService.put('api/customerinfo/updatecustomer', $scope.formData, function (result) {
                if (result.data === true) {
                    notificationService.displaySuccess('Đã cập nhật thông tin khách hàng');
                    $state.go('customer');
                }
                else {
                    notificationService.displayError('Cập nhật thất bại. Vui lòng kiểm tra lại!');
                }
              
            }, function (error) {
                notificationService.displayError('Cập nhật thất bại. Vui lòng kiểm tra lại!');
            });

        }
    }

   

})(angular.module('asasoft.customerinfo'));
