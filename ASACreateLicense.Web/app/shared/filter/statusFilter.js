﻿(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == false)
                return 'unlocked';
            else
                return 'locked';
        }     
    })
})(angular.module('asasoft.common'));