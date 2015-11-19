(function () {

    "use strict";

    angular.module('routes')
    .config(['$routeProvider', 'USER_ROLES', function ($routeProvider, USER_ROLES) {

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
            otherwise({
                templateUrl: '/Templates/login.html',
                controller: 'loginCtrl'
            });
        
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