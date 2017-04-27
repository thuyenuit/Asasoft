(function (app) {

        app.controller('requestLicenseController', requestLicenseController);

        requestLicenseController.$inject = ['$scope', '$state', 'apiServiceHome', 'notificationServiceHome'];

        function requestLicenseController($scope, $state, apiServiceHome, notificationServiceHome) {
           
            $scope.customerTypes = [];
            $scope.cities = [];
            $scope.contractTypes = [];

            function loadCustomerType() {

                var url = 'api/other/getallcustomertype';
                apiServiceHome.get(url, null, function (result) {
                    $scope.customerTypes = result.data;
                }, function () {
                    console.log('Không thể load');
                });
            }
            function loadCity() {
                var url = 'api/other/getallcity';
                apiServiceHome.get(url, null, function (result) {
                    $scope.cities = result.data;
                }, function () {
                    console.log('Không thể load');
                });
            }
            function loadContractType() {
                var url = 'api/other/getallcontracttype';
                apiServiceHome.get(url, null, function (result) {
                    $scope.contractTypes = result.data;
                }, function () {
                    console.log('Không thể load');
                });
            }

            loadCustomerType();
            loadCity();
            loadContractType();

            $scope.requestLicenses = {};
            $scope.CusRequestLicense = CusRequestLicense;
            function CusRequestLicense() {
                $scope.submitted = true;
                var checkValueInput = validationInput();
                if (checkValueInput === true) {
                    var url = 'api/requestlicenses/create';
                    apiServiceHome.post(url, $scope.requestLicenses, function (result) {
                        if (result.status == '400') {
                            notificationServiceHome.displayError('Gửi yêu cầu thất bại. Vui lòng kiểm tra lại!');
                        }
                        else
                            notificationServiceHome.displaySuccess('Yêu cầu của bạn đã được gửi thành công.');
                        ClearField();
                        Add_Remove_Message(true);
                        $state.go('home');
                    }, function (error) {
                        notificationServiceHome.displayError('Gửi yêu cầu thất bại. Vui lòng kiểm tra lại!');
                    })
                }           
            }

            function validationInput() {

                Add_Remove_Message(false);

                if (($scope.requestLicenses.CustomerName != "" && $scope.requestLicenses.CustomerName !== undefined)
                    && ($scope.requestLicenses.CustomerTypeID != "" && $scope.requestLicenses.CustomerTypeID !== undefined)
                    && ($scope.requestLicenses.ServerName != "" && $scope.requestLicenses.ServerName !== undefined)
                    && ($scope.requestLicenses.Email != "" && $scope.requestLicenses.Email !== undefined)
                    && ($scope.requestLicenses.Keys != "" && $scope.requestLicenses.Keys !== undefined)
                    && ($scope.requestLicenses.Address != "" && $scope.requestLicenses.Address !== undefined)
                    && ($scope.requestLicenses.Phone != "" && $scope.requestLicenses.Phone !== undefined)
                    && ($scope.requestLicenses.CityID != "" && $scope.requestLicenses.CityID !== undefined)
                    && ($scope.requestLicenses.ContractTypeID != "" && $scope.requestLicenses.ContractTypeID !== undefined)) {
                    if ($scope.requestLicenses.CustomerTypeID === 1) {
                        if (($scope.requestLicenses.CompanyCode != "" && $scope.requestLicenses.CompanyCode !== undefined)
                            && ($scope.requestLicenses.CompanyCode != "" && $scope.requestLicenses.Company !== undefined)) {
                            return true;
                        }
                        else
                            return false;
                    }

                    return true;
                }
                return false;
            }
            function Add_Remove_Message(value) {
                if (value == true) // Add
                {
                    angular.element('.customerName').addClass('hidden');
                    angular.element('.customerTypeID').addClass('hidden');
                    angular.element('.serverName').addClass('hidden');
                    angular.element('.email').addClass('hidden');
                    angular.element('.keys').addClass('hidden');
                    angular.element('.address').addClass('hidden');
                    angular.element('.phone').addClass('hidden');
                    angular.element('.cityID').addClass('hidden');
                    angular.element('.contractTypeID').addClass('hidden');
                    angular.element('.companyCode').addClass('hidden');
                    angular.element('.company').addClass('hidden');              
                }
                else { //hide
                    angular.element('.customerName').removeClass('hidden');
                    angular.element('.customerTypeID').removeClass('hidden');
                    angular.element('.serverName').removeClass('hidden');
                    angular.element('.email').removeClass('hidden');
                    angular.element('.keys').removeClass('hidden');
                    angular.element('.address').removeClass('hidden');
                    angular.element('.phone').removeClass('hidden');
                    angular.element('.cityID').removeClass('hidden');
                    angular.element('.contractTypeID').removeClass('hidden');
                    angular.element('.companyCode').removeClass('hidden');
                    angular.element('.company').removeClass('hidden');
                }
            }
            function ClearField() {
                $scope.requestLicenses.CustomerName = '';
                $scope.requestLicenses.CustomerTypeID = '';
                $scope.requestLicenses.CompanyCode = '';
                $scope.requestLicenses.Company = '';
                $scope.requestLicenses.ServerName = '';
                $scope.requestLicenses.Email = '';
                $scope.requestLicenses.Keys = '';
                $scope.requestLicenses.Address = '';
                $scope.requestLicenses.Phone = '';
                $scope.requestLicenses.CityID = '';
                $scope.requestLicenses.Fax = '';
                $scope.requestLicenses.ContractTypeID = '';
            }
        }


})(angular.module('asasoft.home'));