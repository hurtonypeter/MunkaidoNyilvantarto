(function () {

    "use strict";

    angular.module('issueControllers')
    .controller('issueDetailsCtrl', ['$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {
        $http.get('/Issues/GetIssueDetails/' + $routeParams.issueId).then(function (resp) {
            if (resp.data.Succeeded) {
                $scope.issue = resp.data.Data;
            }
        });

        $scope.spentTimeModel = {
            IssueId: $routeParams.issueId
        };
        $scope.saveSpentTime = function () {
            $http.post('/SpentTime/Save', $scope.spentTimeModel).then(function (resp) {
                if (resp.data.Succeeded) {
                    $http.get('/SpentTime/GetSpentTimesByIssue/' + $routeParams.issueId).then(function (resp2) {
                        if (resp2.data.Succeeded) {
                            $scope.issue.SpentTimes = resp2.data.Data;
                        }
                    })
                }
            });
        };
        $scope.editSpentTime = function (id) {
            $http.get('/SpentTime/GetSpentTimeEditViewModel/' + id).then(function (resp) {
                if (resp.data.Succeeded) {
                    $scope.spentTimeModel = resp.data.Data;
                }
            })
        };
        $scope.cancelSpentTimeEdit = function () {
            $scope.spentTimeModel = {
                IssueId: $routeParams.issueId
            };
        };

        $scope.commentModel = {
            IssueId: $routeParams.issueId
        };
        $scope.saveComment = function () {
            console.log($scope.commentModel);
            $http.post('/Comments/Create', $scope.commentModel).then(function (resp) {
                if (resp.data.Succeeded) {
                    $scope.issue.Comments.push(resp.data.Data);
                }
            });
        };
        
    }])
    .controller('issueCreateCtrl', ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
        $scope.model = {
            ProjectId: $routeParams.projectId
        };

        $scope.submit = function () {
            console.log($scope.model);
            $http.post('/Issues/CreateIssue', $scope.model).then(function (resp) {
                if (resp.data.Succeeded) {
                    $location.path('/projects/details/' + $scope.model.ProjectId);
                }
            });
        };

    }]);

})();