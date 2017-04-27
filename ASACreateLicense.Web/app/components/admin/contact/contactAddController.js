
(function (app) {

    app.controller('contactAddController', contactAddController);
    contactAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', '$window']; // khởi tạo

    function contactAddController($scope, $state, apiService, notificationService, $window) {
        //contact-add
        $scope.Customer = {};
        $scope.AddContact = AddContact;
        function AddContact() {
            console.log($scope.Customer);
            var url = '/api/contact/addcontact';
            apiService.post(url, $scope.Customer, function (result) {
                notificationService.displaySuccess('Đã gửi liên hệ thành công');
            }, function (error) {
                notificationService.displayError('Không thể gửi thông tin');

            })

        }

    }
})(angular.module('asasoft.contact'));
