(function () {

    "use strict";

    angular.module('userControllers')
    .controller('projectListCtrl', ['$http', 'alertService', '$scope', function ($http, alertService, $scope) {
        $http.get('/Projects/ListProjects').then(function (resp) {
            if (resp.data.succeeded) {
                $scope.projects = resp.data.data;
            }
        });
    }])
    .controller('projectDetailsCtrl', ['$http', 'alertService', '$scope', function ($http, alertService, $scope) {
        
    }]);

})();