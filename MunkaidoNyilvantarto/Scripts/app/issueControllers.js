(function () {

    "use strict";

    angular.module('issueControllers')
    .controller('issueDetailsCtrl', ['$scope', '$routeParams', '$http', '$window', 'AuthService', 'alertService',
        function ($scope, $routeParams, $http, $window, AuthService, alertService) {

        $scope.issueStates = $window.issueStates;
        
        $scope.currentUser = AuthService.currentUser();
        $scope.showEdit = function (userId) {
            if ($scope.currentUser.userId == userId) {
                return true;
            }
            else if ($scope.currentUser.userRole.indexOf('Manager') != -1) {
                return true;
            }
            else {
                return false;
            }
        };

        $http.get('/Issues/GetIssueDetails/' + $routeParams.issueId).then(function (resp) {
            if (resp.data.Succeeded) {
                $scope.issue = resp.data.Data;
                $scope.$watch(function () { return $scope.issue.State; }, function (newValue, oldValue) {
                    if (newValue !== oldValue) {
                        $http.post('/Issues/ChangeState', { issueId: $scope.issue.Id, newState: newValue });
                    }
                });
            }
            else {
                alertService.pushErrors(resp.data.Errors);
            }
        });

        $scope.spentTimeModel = {
            IssueId: $routeParams.issueId,
            Date: new Date()
        };
        $scope.saveSpentTime = function () {
            $http.post('/SpentTime/Save', $scope.spentTimeModel).then(function (resp) {
                if (resp.data.Succeeded) {
                    $http.get('/SpentTime/GetSpentTimesByIssue/' + $routeParams.issueId).then(function (resp2) {
                        if (resp2.data.Succeeded) {
                            $scope.issue.SpentTimes = resp2.data.Data;
                            $scope.spentTimeModel = {
                                IssueId: $routeParams.issueId
                            };
                        }
                    })
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        };
        $scope.editSpentTime = function (id) {
            $http.get('/SpentTime/GetSpentTimeEditViewModel/' + id).then(function (resp) {
                if (resp.data.Succeeded) {
                    resp.data.Data.Date = new Date(resp.data.Data.Date);
                    $scope.spentTimeModel = resp.data.Data;
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            })
        };
        $scope.cancelSpentTimeEdit = function () {
            $scope.spentTimeModel = {
                IssueId: $routeParams.issueId,
                Date: new Date()
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
                    $scope.commentModel = {
                        IssueId: $routeParams.issueId
                    };
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        };
        
    }])
    .controller('issueCreateCtrl', ['$scope', '$http', '$routeParams', '$location', 'alertService',
        function ($scope, $http, $routeParams, $location, alertService) {

        $scope.model = {
            ProjectId: $routeParams.projectId
        };

        $scope.submit = function () {
            console.log($scope.model);
            $http.post('/Issues/CreateIssue', $scope.model).then(function (resp) {
                if (resp.data.Succeeded) {
                    $location.path('/projects/details/' + $routeParams.projectId);
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        };

    }]);

})();