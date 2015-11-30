(function () {

    "use strict";

    angular.module('analyticsControllers')
    .controller('allSpentTimeCtrl', ['$scope', '$http', '$routeParams', '$location', 'alertService',
        function ($scope, $http, $routeParams, $location, alertService) {
           $http.get('/Analytics/GetAllSpentTimeByProject').then(function (resp) {
                if (resp.data.Succeeded) {
                    $scope.spentTimes = resp.data.Data;
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        }])
    .controller('projectSpentTimeCtrl', ['$scope', '$http', '$routeParams', '$location', 'alertService',
        function ($scope, $http, $routeParams, $location, alertService) {
            $scope.selectedProject = 0;
            $http.get('/Projects/ListProjects').then(function (resp) {
                if (resp.data.Succeeded) {
                    $scope.projects = resp.data.Data;
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });

            $scope.loadAnalytics = function() {
                $http.get('/Analytics/GetProjectSpentTimeByIssue?projectId=' + $scope.selectedProject.toString()).then(function (resp) {
                    if (resp.data.Succeeded) {
                        $scope.spentTimes = resp.data.Data.SpentTimes
                    }
                    else {
                        alertService.pushErrors(resp.data.Errors);
                    }
                });
            };
        }]);
})();