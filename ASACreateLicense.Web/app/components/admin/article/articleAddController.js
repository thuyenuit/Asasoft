(function (app) {

    app.controller('articleAddController', articleAddController);

    articleAddController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$state']; // khởi tạo

    function articleAddController($scope, apiService, $ngBootbox, notificationService, $state) {
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '300px'
        }
        $scope.articleinfo = {};

        $scope.contracttypeinfo = [];
        function loadContract() {
            var url = 'api/other/getallcontracttype';
            apiService.get(url, null, function (result) {
                $scope.contracttypeinfo = result.data;
            }, function () {
                console.log('Không thể load');
            });
        }
        loadContract();

        $scope.changedValue = function (item) {
            $scope.articleinfo.ContractTypeID = item.ContractTypeID;

           // alert($scope.articleinfo.ContractTypeID);
        }

        $scope.CreateArticle = CreateArticle;
        function CreateArticle() {
            var url = 'api/article/create';
            alert($scope.articleinfo.ContractTypeID);
            apiService.post(url, $scope.articleinfo, function (result) {
                if (result.data == false) {
                    notificationService.displayError('Thêm mới điều khoản thất bại. Vui lòng kiểm tra lại!');
                }
                else {
                    notificationService.displaySuccess('Thêm mới điều khoản thành công.');
                    $state.go('articles');
                }

            }, function (error) {
                notificationService.displayError('Thêm mới điều khoản thất bại. Vui lòng kiểm tra lại!');
            })
        }

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        //$scope.getarticleInfos = getarticleInfos;

        //function getarticleInfos(page) {
        //    page = page || 0;
          
        //    var url = 'api/article/getob';
        //    $scope.loading = true;
        //    apiService.get(url, null, function (result) {
        //        $scope.articleinfo = result.data;
        //    }, function () {
        //        console.log('Load danh sách điều khoản thất bại!');
        //    })
        //}
        //$scope.getarticleInfos();

        function validationInput() {
            if (($scope.userinfo.Username != "" && $scope.userinfo.Username != undefined)
                && ($scope.userinfo.FullName != "" && $scope.userinfo.FullName != undefined)
                && ($scope.userinfo.Email != "" && $scope.userinfo.Email != undefined)
                && ($scope.userinfo.CellPhone != "" && $scope.userinfo.CellPhone != undefined)) {
                return true;
            }
            return false;
        }
    }
})(angular.module('asasoft.article'));

