(function (app) {
    app.controller('requestLicenseListController', requestLicenseListController);

    requestLicenseListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService', '$filter', 'Data']; // khởi tạo

    function requestLicenseListController($scope, apiService, $ngBootbox, notificationService, $filter, Data) {
        $scope.loading = 'Đang tải dữ liệu...';
        $scope.requestLicenses = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;      
        $scope.dateCurrent1 = '';
        $scope.dateCurrent2 = '';
        $scope.getListRequestLicenses = getListRequestLicenses;

        $scope.options = [
          { name: 5, value: 5 },
          { name: 15, value: 15 },
          { name: 50, value: 50 },
          { name: 100, value: 100 }];
        $scope.valueShow = $scope.options[0].value;

        $scope.changeShow = function () {
            getListRequestLicenses();
        }
      
        $scope.search = search;
        function search() {
            getListRequestLicenses();         
        }

        var today = new Date();
        var strMonth, strDate;
        if ((today.getMonth() + 1).toString().length == 1) {
            strMonth = "0" + (today.getMonth() + 1).toString();
        } else {
            strMonth = (today.getMonth() + 1);
        }

        if (today.getDate().toString().length == 1) {
            strDate = "0" + today.getDate().toString();
        } else {
            strDate = today.getDate();
        }         
        $scope.dateCurrent1 = strMonth + '/' + strDate + '/' + today.getFullYear();
        $scope.dateCurrent2 = strMonth + '/' + strDate + '/' + today.getFullYear();

        //function getCurrentDate() {
        //    var url = 'api/other/getcurrentdate';
        //    apiService.get(url, null, function (result) {
        //        $scope.dateCurrent1 = result.data;
        //        $scope.dateCurrent2 = result.data;
        //    }, function () {
        //        console.log('Không thể load');
        //    });
        //}
        //getCurrentDate();      

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
                apiService.del('api/requestlicenses/deletemulti', consfigs, function (result) {
                    if (result.status === 400)
                        notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                    else
                        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    getListRequestLicenses();
                }, function () {
                    notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                })
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.requestLicenses, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else
            {
                angular.forEach($scope.requestLicenses, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        // Lắng nghe sự thay đổi của requestLicenses,
        // co 2 tham so: 1 - lang nghe ten bien requestLicenses
        //               2 - function (new, old) va filter nhung gia tri moi la true thi vao danh sach da dc checked
        $scope.$watch("requestLicenses", function (ne, old) {
            var checked = $filter("filter")(ne, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMulti').removeAttr('disabled');
            } else {
                $('#btnDeleteMulti').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteRequestLicense = deleteRequestLicense;
        function deleteRequestLicense(id) {
            $ngBootbox.confirm('Bạn có muốn chắc xóa?').then(function () {
                var consfigs = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/requestlicenses/delete', consfigs, function (result) {
                    if (result.status === 400)
                        notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                    else
                        notificationService.displaySuccess('Xóa thành công');
                    getListRequestLicenses();
                }, function () {
                    notificationService.displayError('Xóa không thành công! Vui lòng kiểm tra lại.');
                })
            });
        }

        // sent email
        $scope.sentEmail = sentEmail;
        function sentEmail(id, customerName) {
            var html = '<strong>' + customerName + '</strong>';
            $ngBootbox.confirm('Bạn có muốn gửi email cho khách hàng ' + html + ' ?').then(function () {
                var consfigs = {
                    params: {
                        id: id
                    }
                }
                apiService.get('api/requestlicenses/sentemail', consfigs, function (result) {
                    if (result.status === 400)
                        notificationService.displayError('Gửi email không thành công! Vui lòng kiểm tra lại.');
                    else
                        notificationService.displaySuccess('Gửi email đến khách hàng ' +html +' thành công.');
                    getListRequestLicenses();
                }, function () {
                    notificationService.displayError('Gửi email không thành công! Vui lòng kiểm tra lại.');
                })
            });
        }

        // add customer
        $scope.addCustomer = addCustomer;
        function addCustomer(id, customerName) {
            var html = '<strong>' + customerName + '</strong>';
            $ngBootbox.confirm('Bạn có muốn lưu thông tin khách hàng ' + html + ' ?').then(function () {
                var consfigs = {
                    params: {
                        id: id
                    }
                }

                apiService.get('api/requestlicenses/addcustomer', consfigs, function (result) {
                    if (result.status === 400)
                        notificationService.displayError('Lưu thông tin khách hàng không thành công! Vui lòng kiểm tra lại.');
                    else
                        notificationService.displaySuccess('Lưu thông tin khách hàng ' + html + ' thành công.');
                    getListRequestLicenses();
                }, function () {
                    notificationService.displayError('Lưu thông tin khách hàng không thành công! Vui lòng kiểm tra lại.');
                })
            });
        }

        $scope.cities = [];
        //function loadCity() {
        //    var url = 'api/other/getallcity';
        //    apiService.get(url, null, function (result) {
        //        $scope.cities = result.data;
        //    }, function () {
        //        console.log('Không thể load');
        //    });
        //}
        //loadCity();


        $scope.statusLicenses = [];
        function loadStatusLicense() {
            var url = 'api/other/getallstatuslicense';
            apiService.get(url, null, function (result) {
                $scope.statusLicenses = result.data;
            }, function () {
                console.log('Không thể load');
            });
        }
        loadStatusLicense();

        $scope.updateCity = function (Id, cityId) {
            var consfigs = {
                params: {
                    Id: Id,
                    cityId: cityId
                }
            }                 
            apiService.put('api/requestlist/updatecity', consfigs, function (result) {
                alert('Cập nhật thành công');

            }, function () {
                alert('Cập nhật thất bại');
            });
        }

        $scope.updateStatus = function (Id, statusId) {
            alert(Id);
            alert(statusId);
            var consfigs = {
                params: {
                    id: Id,
                    statusLicenseId: statusId
                }
            }

            apiService.put('api/requestlicenses/updatestatus', consfigs, function (result) {
                if (result.status === 400)
                    notificationService.displayError('Cập nhật không thành công! Vui lòng kiểm tra lại.');
                else
                    notificationService.displaySuccess('Cập nhật thành công');
                getListRequestLicenses();
            }, function () {
                notificationService.displayError('Cập nhật không thành công! Vui lòng kiểm tra lại.');
            })           
        }

        function getListRequestLicenses(page) {
            page = page || 0;
            var statusId = $scope.statusLicenses.StatusLicenseID;
            if (statusId === '' || statusId === undefined || statusId === null)
                statusId = -1;
            // xem tất cả Request List ở page Dashboarh link tới
            var viewAll = 0;
            if (Data.valueView.toString().length === 1)
                viewAll = 1;
        
            $scope.fromD = '';
            $scope.EndD = '';
            var fromCreateD = $scope.dateCurrent1;
            if ($scope.dateCurrent1 === '' || $scope.dateCurrent1 === undefined)
                fromCreateD = '01/01/1900';
            var toCreateD = $scope.dateCurrent2;
            if ($scope.dateCurrent2 === '' || $scope.dateCurrent2 === undefined)
                toCreateD = '01/01/1900';         
            if ((fromCreateD === '01/01/1900' && toCreateD != '01/01/1900')
                || (fromCreateD != '01/01/1900' && toCreateD === '01/01/1900')) {
                $scope.EndD = '01/01/1900';
                $scope.fromD = '01/01/1900';
                notificationService.displayWarning('Chọn ngày chưa hợp lệ');
            }         
                  
            var consfig = {
                params: {
                    fromDate: fromCreateD,
                    endDate: toCreateD,
                    statusLicenseId: statusId,
                    viewAll: viewAll,
                    page: page,
                    pageSize: $scope.valueShow
                }
            }

            var url = 'api/requestlicenses/getall';
            $scope.loading = true;
            apiService.get(url, consfig, function (result) {
                $scope.requestLicenses = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;            
                $scope.loading = false;

            }, function () {
                Console.log('Load danh sách yêu cầu License thất bại!');
                $scope.loading = false;
            })
        }

        $scope.getListRequestLicenses();

    }
})(angular.module('asasoft'));