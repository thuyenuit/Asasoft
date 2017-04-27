(function (app) {

    app.controller('contactListController', contactListController);

    contactListController.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$timeout', '$ngBootbox', 'myService']; // khởi tạo

    function contactListController($scope, apiService, $stateParams, notificationService, $timeout, $ngBootbox, myService) {
        $scope.customers = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = 1;
        $scope.getListContact = getListContact;

        $scope.toggleFilter = function (id, status) {
            this.toggle = !this.toggle;

            if (this.toggle === true)
            {
                if(status === false)
                    getListContact();
            }
               
            if (status === false)
            {
                var consfig = {
                    params: {
                        id: id
                    }
                }
                var url = 'api/contact/updatestatus';
                apiService.get(url, consfig, function (result) {                  
                }, function (error) {                 
                })
            }
        }

        $scope.changeStatus = function (item) {
            $scope.isLock = item;
            getListContact();
        }

        $scope.search = search;
        function search() {
            getListContact();
        }

        function getListContact(page) {
            page = page || 0;

            if ($scope.status === undefined)
                $scope.status = false;

            var consfig = {
                params: {
                    status: $scope.status,
                    page: page,
                    pageSize: 5
                }
            }
            $scope.loading = true;
            var url = '/api/contact/getall';
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

        $scope.getListContact();

        //  Delete
        $scope.CustomerID = '';
        $scope.DeleteCustomer = function (ID) {
            $ngBootbox.confirm('Bạn có muốn chắc xóa ?').then(function () {
                var consfig = {
                    params: {
                        id: ID
                    }
                }
                var url = 'api/contact/delete';
                apiService.del(url, consfig, function (result) {
                    notificationService.displaySuccess('Xóa khách hàng thành công');
                    getListContact();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công.');
                })
            })
        }

        //
        $scope.options = [
        {
            name: 'Chưa đọc',
            value: 1
        },
        {
            name: 'Đã đọc',
            value: 2
        }
        ];

        $scope.keyword = $scope.options[0].value;
    }

})(angular.module('asasoft.contact'));
