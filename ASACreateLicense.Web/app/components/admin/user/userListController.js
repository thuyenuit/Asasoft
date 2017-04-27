
(function (app) {
    app.controller('userListController', userListController);

    userListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService']; // khởi tạo

    function userListController($scope, apiService, $ngBootbox, notificationService) {      
        $scope.listUser = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';
        $scope.getListUser = getListUser;

        $scope.search = search;
        function search() {
            getListUser();
        }

        function getListUser(page) {
            page = page || 0;
          
            var consfig = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5
                }
            }
           
            var url = 'api/user/getall';
            $scope.loading = true;
            apiService.get(url, consfig, function (result) {
                $scope.listUser = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;

            }, function () {
                Console.log('Load danh sách người dùng thất bại!');
                $scope.loading = false;
            })
        }
        $scope.getListUser();
    }
})(angular.module('asasoft'));