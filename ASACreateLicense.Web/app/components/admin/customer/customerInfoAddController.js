/// <reference path="C:\Users\PC\Desktop\New version\ASACreateLicense\ASACreateLicense.Web\Assets/admin/libs/angular/angular.min.js" />
(function (app) {

    app.controller('customerAddController', customerAddController);
    customerAddController.$inject = ['$scope','$state' ,'apiService', 'notificationService','$window']; // khởi tạo

    function customerAddController($scope, $state, apiService, notificationService, $window) {
        //  $scope.listCityName = [];        
        //Load city name
        var url = '/api/other/getallcity';
            apiService.get(url, null, function (result){
                $scope.listCityName = result.data;
            }, function () {
            })
        //load Customer type
            var url2 = '/api/other/getallcustomertype';
            apiService.get(url2, null, function (result) {
                $scope.listCustomerType = result.data;
            }, function () {
            })
        //Addcustomer
            $scope.Customer = {};
            $scope.AddCustomer = AddCustomer;

            function AddCustomer() {
                var url3 = '/api/customerinfo/addcustomer';
                apiService.post(url3, $scope.Customer, function (result) {
                    notificationService.displaySuccess('Đã thêm khách hàng thành công');
                    $state.go('customer');
                }, function (error) {
                    notificationService.displayError('Không thể thêm khách hàng');
                   
                })
               
            }
      
    }
})(angular.module('asasoft.customerinfo'));
