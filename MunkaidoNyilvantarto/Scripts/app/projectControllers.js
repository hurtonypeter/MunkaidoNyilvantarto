(function () {

    "use strict";

    angular.module('userControllers')
    .controller('projectListCtrl', ['$http', 'alertService', '$scope', function ($http, alertService, $scope) {
        $http.get('/Projects/ListProjects').then(function (resp) {
            if (resp.data.Succeeded) {
                $scope.projects = resp.data.Data;
            }
            else {
                alertService.pushErrors(resp.data.Errors);
            }
        });
    }])
    .controller('projectCreateCtrl', ['$http', 'alertService', '$scope', '$location', function ($http, alertService, $scope, $location) {
        $scope.submit = function () {
            $http.post('/Projects/Create', $scope.model).then(function (resp) {
                if (resp.data.Succeeded) {
                    $location.path('/projects');
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        };
    }])
    .controller('projectDetailsCtrl', ['$http', 'alertService', '$scope', '$routeParams', function ($http, alertService, $scope, $routeParams) {
        $http.get('/Projects/GetProjectDetails/' + $routeParams.projectId).then(function (resp) {
            if (resp.data.Succeeded) {
                $scope.project = resp.data.Data;
            }
            else {
                alertService.pushErrors(resp.data.Errors);
            }
        })

        $http.get('/Issues/GetIssuesByProject/' + $routeParams.projectId).then(function (resp) {
            if (resp.data.Succeeded) {
                $scope.issues = resp.data.Data;
            }
            else {
                alertService.pushErrors(resp.data.Errors);
            }
        });

        $scope.setColor = function (state) {
            switch (state) {
                case 0: return 'list-group-item-info';
                case 1: case 3: return 'list-group-item-warning';
                case 2: return 'list-group-item-danger';
                case 4: return 'list-group-item-success';
            }
        }
    }]);

})();