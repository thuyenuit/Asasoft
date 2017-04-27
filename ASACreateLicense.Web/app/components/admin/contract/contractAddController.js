(function (app) {

    app.controller('contractAddController', contractAddController);
    contractAddController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', 'Data', '$state'];
    function contractAddController($scope, apiService, $ngBootbox, notificationService, Data, $state) {
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '800px'
        }
        $scope.contractinfo = {};

        $scope.customerList = {};
        function loadCustomerInfo() {         
            var url = 'api/customerinfo/getallcustomer';
            apiService.get(url, null, function (result) {
                $scope.customerList = result.data;
            }, function () {
                console.log('Không thể load');
            });
        }
        loadCustomerInfo();

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

        $scope.changedValue = function () {         
            if ($scope.contracttypeinfo.ContractTypeID === undefined) {
                $scope.contractinfo.ContractContent = '';
            }
            else {
                $scope.contracttypeId = $scope.contracttypeinfo.ContractTypeID;
                getarticleInfos();
            }
           
        }

        $scope.customerinfo = {};
        $scope.myChangeCustomer = function () {
            var consfig = {
                params: {
                    id: $scope.contractinfo.CustomerID
                }
            }

            if ($scope.contractinfo.CustomerID === undefined || $scope.contractinfo.CustomerID === '') {
                $scope.contractinfo.Phone = '';
                $scope.contractinfo.Fax = '';
                $scope.contractinfo.Address = '';
                $scope.contractinfo.Company = '';
                $scope.contractinfo.TaxCode = '';
                $scope.contractinfo.AccountBank = '';
                $scope.contractinfo.Bank = '';
            }
            else {
                var url = 'api/customerinfo/getbyid/id=' + $scope.contractinfo.CustomerID;
                apiService.get(url, consfig, function (result) {
                    $scope.customerinfo = result.data;
                    $scope.contractinfo.Phone = $scope.customerinfo.Phone;
                    $scope.contractinfo.Fax = $scope.customerinfo.Fax;
                    $scope.contractinfo.Company = $scope.customerinfo.Company;
                    $scope.contractinfo.Address = $scope.customerinfo.Address;
                    $scope.contractinfo.TaxCode = $scope.customerinfo.TaxCode;
                    $scope.contractinfo.AccountBank = $scope.customerinfo.BankAccount;
                    $scope.contractinfo.Bank = $scope.customerinfo.Bank;
                }, function () {
                    console.log('Không thể load');
                });
            }
        }

        //$scope.getarticleInfos = getarticleInfos;
        function getarticleInfos() {         
            var consfig = {
                params: {
                    id: $scope.contracttypeId
                }
            }        
            var url = 'api/article/getbycontracttype';
            apiService.get(url, consfig, function (result) {
                if (result.data === null)
                    notificationService.displayError('Loại hợp đồng này chưa thêm điều khoản hoặc đã bị khóa. Vui lòng kiểm tra lại!');
                else
                {
                    $scope.articleinfo = result.data;
                    $scope.contractinfo.ContractContent = result.data.Content;
                }
                
            }, function () {
                notificationService.displayError('Loại hợp đồng này chưa thêm điều khoản hoặc đã bị khóa. Vui lòng kiểm tra lại!');
            })
        }
       // $scope.getarticleInfos();

        $scope.unitinfo = {};
        $scope.getUnitInfo = getUnitInfo;
        function getUnitInfo() {
            var url = 'api/other/unitinfo';
            apiService.get(url, null, function (result) {
                $scope.unitinfo = result.data;
                $scope.contractinfo.UnitInfoID = $scope.unitinfo.ID;
            }, function () {
                notificationService.displayError('Load thông tin đơn vị thất bại. vui lòng kiểm tra lại!');
                console.log('Load thông tin thất bại!');
            })
        }
        $scope.getUnitInfo();

        $scope.AddContract = AddContract;
        function AddContract() {

            $scope.submitted = true;

            $scope.contractinfo.ContractTypeID = $scope.contracttypeId;
            //alert($scope.contractinfo.ContractTypeID);

            var url = 'api/contract/create';
            apiService.post(url, $scope.contractinfo, function (result) {
                if (result.data == false) {
                    notificationService.displayError('Thêm hợp đồng thất bại. Vui lòng kiểm tra lại!');
                }
                else {
                    notificationService.displaySuccess('Thêm hợp đồng thành công.');
                    $state.go('contractlist');
                }

            }, function (error) {
                notificationService.displayError('Thêm hợp đồng thất bại. Vui lòng kiểm tra lại!');
            })
        }


        $scope.CategoriesSelected = [];
        $scope.Categories = [];
        $scope.dropdownSetting = {
            scrollable: true,
            scrollableHeight: '200px'
        }
        //fetch data from database for show in multiselect dropdown
        function loadArticle() {
            var url = 'api/article/getallnopaging';
            apiService.get(url, null, function (result) {
                $.each(result.data, function (i, item) {
                    $scope.Categories.push({ id: item.ID, label: item.ArticleName });
                });
            }, function () {
                console.log('Không thể load');
            });
        }
        loadArticle();

        //post or submit selected items from multiselect dropdown to server
        $scope.SubmittedCategories = [];
        $scope.SubmitData = function () {
            var categoryIds = [];
            $.each($scope.CategoriesSelected, function (i, item) {
                categoryIds.push(item.id);
            });            

            if (categoryIds.length === 0) {
                notificationService.displayError('Vui lòng chọn các điều khoản!');
            }
            else {
                var consfigs = {
                    params: {
                        jsonlistId: JSON.stringify(categoryIds)
                    }
                }
                apiService.get('api/article/getbymultiid', consfigs, function (result) {
                    $scope.SubmittedCategories = result.data;

                    $scope.contractinfo.ContractContent = '';
                    $.each(result.data, function (i, item) {
                        $scope.contractinfo.ContractContent += item.Content;
                    });

                }, function () {
                    notificationService.displayError('Thêm không thành công! Vui lòng kiểm tra lại.');
                })
            }
            
        }

    }
})(angular.module('asasoft.contract'));