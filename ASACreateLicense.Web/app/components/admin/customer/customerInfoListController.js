(function (app) {

    app.controller('customerListController', customerListController);

    customerListController.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$timeout', '$ngBootbox', 'myService']; // khởi tạo

    function customerListController($scope, apiService, $stateParams, notificationService, $timeout, $ngBootbox, myService) {
        $scope.customers = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';
        $scope.getListCustomer = getListCustomer;


        $scope.options = [
            { name: 5, value: 5 },
            { name: 15, value: 15 },
            { name: 50, value: 50 },
            { name: 100, value: 100 }];
        $scope.valueShow = $scope.options[0].value;

        $scope.changeShow = function () {
            getListCustomer();
        }

        $scope.myFunct = function (keyEvent) {
            if (keyEvent.which === 13)
                getListCustomer();
        }

        $scope.search = search;
        function search() {
            getListCustomer();
        }

        function getListCustomer(page) {
            page = page || 0;

            var consfig = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.valueShow
                }
            }
            $scope.loading = true;
            var url = '/api/customerinfo/getall';
            apiService.get(url, consfig, function (result) {
                $scope.customers = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                Console.log('Load danh sách khách hàng thất bại!');
            })
        }

        $scope.getListCustomer();      

        $scope.fnClick = function (usr, index) {
           
            $scope.formData = angular.copy($scope.customers[index]);   //usr object will be assigned to $scope.formData...         
            $scope.formData.index = index;
          
            //gan du lieu cho tham so myService
            myService.set($scope.formData);
        }   
       
        //  Delete
        $scope.CustomerID = '';
        $scope.DeleteCustomer = function (CustomerID, customerName) {
            $ngBootbox.confirm('Bạn có muốn chắc xóa khách hàng ' + customerName + '?').then(function () {
                var consfig = {
                    params: {
                        id: CustomerID
                    }
                }
                var urldelete = 'api/customerinfo/delete';
                apiService.del(urldelete, consfig, function (result) {
                    notificationService.displaySuccess('Xóa khách hàng thành công');
                    getListCustomer();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công.');
                })
            })
        }
    }

    app.factory('myService', function() {
        var savedData = {}
        function set(data) {
            savedData = data;
        }
        function get() {
            return savedData;
        }

        return {
            set: set,
            get: get
        }

    });
})(angular.module('asasoft.customerinfo'));
