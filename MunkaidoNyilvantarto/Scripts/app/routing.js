(function () {

    "use strict";

    angular.module('routes')
    .config(['$routeProvider', '$httpProvider', 'USER_ROLES', function ($routeProvider, $httpProvider, USER_ROLES) {

        $httpProvider.interceptors.push('httpErrorsInterceptor');

        $routeProvider.
            when('/vedett', {
                templateUrl: '/Templates/vedett.html',
                controller: 'loginCtrl',
                data: {
                    roles: [USER_ROLES.manager]
                }
            }).
            when('/login', {
                templateUrl: '/Templates/login.html',
                controller: 'loginCtrl'
            }).
            when('/error/404', {
                templateUrl: '/Templates/notfound.html'
            }).
            otherwise({
                templateUrl: '/Templates/login.html',
                controller: 'loginCtrl'
            });
        
    }])
    .factory('httpErrorsInterceptor', ['$location', function ($location) {
        return {
            responseError: function (rejection) {
                if (rejection.status == 404) {
                    $location.path('/error/404');
                }
            }
        };
    }])
    .run(['AuthService', '$rootScope', function (AuthService, $rootScope) {
        $rootScope.$on('$routeChangeStart', function (event, next) {

            if (next.data != undefined && next.data.roles != undefined) {
                var authorizedRoles = next.data.roles;
                console.log(authorizedRoles);

                if (!AuthService.isAuthorized(authorizedRoles)) {
                    event.preventDefault();
                    console.log('nem mehetsz tovább');
                    //TODO: mi legyen itt, kell hibaüzi
                }
            }

        });
    }]);

})();