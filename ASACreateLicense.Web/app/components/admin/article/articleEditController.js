(function (app) {

    app.controller('articleEditController', articleEditController);

    articleEditController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', '$state']; // khởi tạo

    function articleEditController($scope, apiService, notificationService, $stateParams, $state) {
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


        $scope.UpdateArticle = UpdateArticle;
        function UpdateArticle() {
            $scope.submitted = true;
            var url = 'api/article/update';
            apiService.put(url, $scope.articleinfo, function (result) {
                if (result.data == false) {
                    notificationService.displayError('Cập nhật điều khoản thất bại. Vui lòng kiểm tra lại!');
                }
                else {
                    notificationService.displaySuccess('Cập nhật điều khoản thành công.');
                    $state.go('articles');
                }

            }, function (error) {
                notificationService.displayError('Cập nhật điều khoản thất bại. Vui lòng kiểm tra lại!');
            })
        }

        $scope.getarticleInfos = getarticleInfos;
        function getarticleInfos() {
            var consfig = {
                params: {
                    id: $stateParams.id
                }
            }
            var url = 'api/article/getob';
            apiService.get(url, consfig, function (result) {
                $scope.articleinfo = result.data;
            }, function () {
                notificationService.displayError('Load thông tin điều khoản thất bại!');
            })
        }
        $scope.getarticleInfos();      
    }
})(angular.module('asasoft.article'));

