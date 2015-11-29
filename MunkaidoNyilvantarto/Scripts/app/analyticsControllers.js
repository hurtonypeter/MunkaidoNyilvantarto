(function () {

    "use strict";

    angular.module('analyticsControllers')
    .controller('allSpentTimeCtrl', ['$scope', '$http', '$routeParams', '$location', 'alertService',
        function ($scope, $http, $routeParams, $location, alertService) {
            $scope.getAllSpentTimes = function () {
                $http.get('/Analytics/GeGetAllSpentTimeByProject').then(function (resp) {
                    if (resp.data.Succeeded) {
                        $scope.spentTimes = resp.data.Data;
                    }
                    else {
                        alertService.pushErrors(resp.data.Errors);
                    }
                });
            };

        }]);
})();