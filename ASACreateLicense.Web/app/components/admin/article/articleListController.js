(function (app) {

    app.controller('articleListController', articleListController);

    articleListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$filter', '$sce']; // khởi tạo

    function articleListController($scope, apiService, $ngBootbox, notificationService, $filter, $sce) {
        $scope.loading = 'Đang tải dữ liệu...';
        $scope.articleInfos = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;      
        $scope.getarticleInfos = getarticleInfos;

        $scope.Contents = [];

        function getarticleInfos(page) {
            page = page || 0;
           
            var consfig = {
                params: {                   
                    page: page,
                    pageSize: 5
                }
            }
            var url = 'api/article/getall';
            $scope.loading = true;
            apiService.get(url, consfig, function (result) {
                $scope.articleInfos = result.data.Items;

                //$.each($scope.articleInfos, function (i, item) {
                //    var str = $sce.trustAsHtml(item.Content);                
                //    $scope.Contents.push({ name: str });
                //});

                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('Load danh sách điều khoản thất bại!');
                $scope.loading = false;
            })
        }

        $scope.getarticleInfos();

    }
})(angular.module('asasoft.article'));



//(function (app) {

//    app.controller('licenseInfoListController', licenseInfoListController);

//    licenseInfoListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$filter', 'Data']; // khởi tạo

//    function licenseInfoListController($scope, apiService, $ngBootbox, notificationService, $filter, Data) {
//        $scope.loading = 'Đang tải dữ liệu...';
//        $scope.licenseInfos = [];
//        $scope.statusLicenses = [];
//        $scope.contractTypes = [];
//        $scope.page = 0;
//        $scope.pagesCount = 0;
//        $scope.totalCount = 0;
//        $scope.fromCreateDate = '';
//        $scope.toCreateDate = '';
//        $scope.fromEndDate = '';
//        $scope.toEndDate = '';
//        $scope.keyword = '';
//        $scope.getListLicenseInfo = getListLicenseInfo;

//        $scope.selectAll = selectAll;
//        $scope.isAll = false;
//        function selectAll() {
//            if ($scope.isAll == false) {
//                angular.forEach($scope.licenseInfos, function (item) {
//                    item.checked = true;
//                });
//                $scope.isAll = true;
//            }
//            else {
//                angular.forEach($scope.licenseInfos, function (item) {
//                    item.checked = false;
//                });
//                $scope.isAll = false;
//            }
//        }

//        // Lắng nghe sự thay đổi của requestLicenses,
//        // co 2 tham so: 1 - lang nghe ten bien requestLicenses
//        //               2 - function (new, old) va filter nhung gia tri moi la true thi vao danh sach da dc checked
//        $scope.$watch("licenseInfos", function (ne, old) {
//            var checked = $filter("filter")(ne, { checked: true });
//            if (checked.length) {
//                $scope.selected = checked;
//                $('#btnDeleteMulti').removeAttr('disabled');
//            } else {
//                $('#btnDeleteMulti').attr('disabled', 'disabled');
//            }
//        }, true);

//        $scope.deleteMulti = deleteMulti;

//        function deleteMulti() {
//            $ngBootbox.confirm('Bạn có muốn chắc xóa những mục đã chọn?').then(function () {

//                var listId = [];
//                $.each($scope.selected, function (i, item) {
//                    listId.push(item.LicenseID);
//                });

//                var consfigs = {
//                    params: {
//                        jsonlistId: JSON.stringify(listId)
//                    }
//                }
//                apiService.del('api/licenseinfo/deletemulti', consfigs, function (result) {
//                    if (result.status === 400)
//                        notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
//                    else
//                        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
//                    getListLicenseInfo();
//                }, function () {
//                    notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
//                })
//            });
//        }


//        $scope.search = search;
//        function search() {
//            getListLicenseInfo();
//        }

//        // load danh sách status license
//        function loadStatusLicense() {
//            var url = 'api/other/getallstatuslicense';
//            apiService.get(url, null, function (result) {
//                $scope.statusLicenses = result.data;
//            }, function () {
//                console.log('Không thể load');
//            });
//        }
//        loadStatusLicense();

//        // load danh sách contract type
//        function loadContractType() {
//            var url = 'api/other/getallcontracttype';
//            apiService.get(url, null, function (result) {
//                $scope.contractTypes = result.data;
//            }, function () {
//                console.log('Không thể load');
//            });
//        }
//        loadContractType();

//        $scope.myFunct = function (keyEvent) {
//            if (keyEvent.which === 13)
//                getListLicenseInfo();
//        }

//        function getListLicenseInfo(page) {
//            var fromCreateD = $scope.fromCreateDate;
//            if ($scope.fromCreateDate === '' || $scope.fromCreateDate === undefined)
//                fromCreateD = '01/01/1900';

//            var toCreateD = $scope.toCreateDate;
//            if ($scope.toCreateDate === '' || $scope.toCreateDate === undefined)
//                toCreateD = '01/01/1900';

//            var fromEndD = $scope.fromEndDate;
//            if ($scope.fromEndDate === '' || $scope.fromEndDate === undefined)
//                fromEndD = '01/01/1900';

//            var toEndD = $scope.toEndDate;
//            if ($scope.toEndDate === '' || $scope.toEndDate === undefined)
//                toEndD = '01/01/1900';

//            if ((fromCreateD === '01/01/1900' && toCreateD != '01/01/1900')
//                || (fromCreateD != '01/01/1900' && toCreateD === '01/01/1900')) {
//                fromCreateD = '01/01/1900';
//                toCreateD = '01/01/1900';
//                notificationService.displayWarning('Chọn ngày khởi tạo chưa hợp lệ');
//            }

//            if ((fromEndD === '01/01/1900' && toEndD != '01/01/1900')
//               || (fromEndD != '01/01/1900' && toEndD === '01/01/1900')) {
//                fromEndD = '01/01/1900';
//                toEndD = '01/01/1900';
//                notificationService.displayWarning('Chọn ngày kết thúc chưa hợp lệ');
//            }

//            page = page || 0;
//            var statusId = $scope.statusLicenses.StatusLicenseID;
//            if (statusId === '' || statusId === undefined || statusId === null)
//                statusId = -1;

//            var contractId = $scope.contractTypes.ContractTypeID;
//            if (contractId === '' || contractId === undefined || contractId === null)
//                contractId = 0;

//            // xem tất cả Request List ở page Dashboarh link tới
//            var viewAll = 0;
//            if (Data.valueView.toString().length === 1)
//                viewAll = 1;

//            var consfig = {
//                params: {
//                    fromCreateDate: fromCreateD,
//                    toCreateDate: toCreateD,
//                    fromEndDate: fromEndD,
//                    toEndDate: toEndD,
//                    statusId: statusId,
//                    keyword: $scope.keyword,
//                    contractId: contractId,
//                    viewAll: viewAll,
//                    page: page,
//                    pageSize: 3
//                }
//            }
//            var url = 'api/licenseinfo/getall';
//            $scope.loading = true;
//            apiService.get(url, consfig, function (result) {
//                $scope.licenseInfos = result.data.Items;
//                $scope.page = result.data.Page;
//                $scope.pagesCount = result.data.TotalPages;
//                $scope.totalCount = result.data.TotalCount;
//                //loadCity();
//                // loadStatusLicense();
//                $scope.loading = false;
//            }, function () {
//                Console.log('Load danh sách yêu cầu License thất bại!');
//                $scope.loading = false;
//            })
//        }

//        $scope.getListLicenseInfo();
//    }
//})(angular.module('asasoft'));

