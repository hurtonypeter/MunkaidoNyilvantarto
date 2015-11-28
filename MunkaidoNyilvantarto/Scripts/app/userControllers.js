(function () {

    "use strict";

    angular.module('userControllers')
    .controller('loginCtrl', ['$scope', 'AuthService', '$location', 'alertService', function ($scope, AuthService, $location, alertService) {
        $scope.model = {
            Email: "hurtonypeter@gmail.com",
            Password: "Asdf123.",
            RememberMe: true
        }
        $scope.login = function () {
            AuthService.login($scope.model).then(function (resp) {
                console.log(resp);
                if (resp.data.Succeeded) {
                    $location.path('/');
                }
                else {
                    alertService.pushErrors(resp.data.Errors);
                }
            });
        };
    }])
    .controller('userBarCtrl', ['$scope', 'AuthService', '$rootScope', function ($scope, AuthService, $rootScope) {
        $scope.currentUser = AuthService.currentUser();
        
        $rootScope.$on('loginSuccess', function (event, next) {
            console.log('bejelentkezés volt');
            $scope.currentUser = AuthService.currentUser();
            console.log($scope.currentUser);
        });
    }]);

})();