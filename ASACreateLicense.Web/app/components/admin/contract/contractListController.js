(function (app) {

    app.controller('contractListController', contractListController);

    contractListController.$inject = ['$scope', '$http', 'apiService', '$ngBootbox', 'notificationService', '$state', '$compile', 'Data', '$filter']; // khởi tạo

    function contractListController($scope, $http, apiService, $ngBootbox, notificationService, $state, $compile, Data, $filter) {
        $scope.contractInfos = [];       
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;

        $scope.printPdf = function () {
            $http.get('api/contract/printpdf', null)
           .success(function (data) {
               var file = new blob([data], { type: 'application/pdf' });
               var fileurl = url.createobjecturl(file);
               window.open(fileurl);
           });

            //apiservice.get('api/contract/printpdf', null, function (result) {
            //    var file = new blob([result], { type: 'application/pdf' });
            //    var fileurl = url.createobjecturl(file);
            //    window.open(fileurl);
            //}, function () {
            //    console.log('không thể load');
            //});           
        };

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

        //$scope.changedValue = function (item) {
        //    $scope.contracttypeId = item.ContractTypeID;             
        //}

        $scope.search = function () {
            getListContract();
        }

        $scope.myFunct = function (keyEvent) {
            if (keyEvent.which === 13)
                getListContract();
        }

        $scope.changeIsLock = function (item) {
            $scope.isLock = item;
            getListContract();
            //alert(item);
        }

        $scope.options = [
          { name: 5, value: 5 },
          { name: 15, value: 15 },
          { name: 50, value: 50 },
          { name: 100, value: 100 }];
        $scope.valueShow = $scope.options[0].value;

        $scope.changeShow = function () {
            getListContract();
        }

        $scope.getListContract = getListContract;
        function getListContract(page) {
            page = page || 0;

            var contracttype = $scope.contracttypeinfo.ContractTypeID;
            if (contracttype === '' || contracttype === undefined || contracttype === null)
                contracttype = -1;

            if ($scope.keywords === undefined)
                $scope.keywords = '';

            if ($scope.isLock === undefined)
                $scope.isLock = false;
          
            var consfig = {
                params: {
                    keyword: $scope.keywords,
                    contracttype: contracttype,
                    isLock: $scope.isLock,
                    page: page,
                    pageSize: $scope.valueShow
                }
            }

            var url = 'api/contract/getall';
            $scope.loading = true;
            apiService.get(url, consfig, function (result) {
                $scope.contractInfos = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('Load danh sách hợp đồng thất bại!');
                notificationService.displayError('Load danh sách hợp đồng thất bại!');
                $scope.loading = false;
            })
        }
        $scope.getListContract();


        $scope.selectAll = selectAll;

        $scope.deleteMulti = deleteMulti;
        function deleteMulti() {
            $ngBootbox.confirm('Bạn có muốn chắc xóa những mục đã chọn?').then(function () {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                });

                var consfigs = {
                    params: {
                        jsonlistId: JSON.stringify(listId)
                    }
                }
                apiService.del('api/contract/deletemulti', consfigs, function (result) {
                    if (result.status === 400)
                        notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                    else
                    {
                        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                        getListContract();
                    }
                       
                }, function () {
                    notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                })
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.contractInfos, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.contractInfos, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        // Lắng nghe sự thay đổi của requestLicenses,
        // co 2 tham so: 1 - lang nghe ten bien requestLicenses
        //               2 - function (new, old) va filter nhung gia tri moi la true thi vao danh sach da dc checked
        $scope.$watch("contractInfos", function (ne, old) {
            var checked = $filter("filter")(ne, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMulti').removeAttr('disabled');
            } else {
                $('#btnDeleteMulti').attr('disabled', 'disabled');
            }
        }, true);




        function dataValue() {
            Data.valueGo = $scope.contracttypeId;
            $state.go('contractadd');
        }

        app.factory('Data', function () {
            return { valueGo: '' };
        });

    }
})(angular.module('asasoft.contract'));