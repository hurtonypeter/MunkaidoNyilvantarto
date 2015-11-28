(function () {

    "use strict";

    angular.module('routes')
    .config(['$routeProvider', '$httpProvider', 'USER_ROLES', function ($routeProvider, $httpProvider, USER_ROLES) {

        $httpProvider.interceptors.push('httpErrorsInterceptor');

        $routeProvider.
            when('/', {
                redirectTo: '/projects'
            }).
            when('', {
                redirectTo: '/projects'
            }).
            when('/projects', {
                templateUrl: '/Templates/projects.html',
                controller: 'projectListCtrl',
                data: {
                    roles: [USER_ROLES.manager, USER_ROLES.worker]
                }
            }).
            when('/projects/create', {
                templateUrl: '/Templates/project-edit.html',
                controller: 'projectCreateCtrl',
                data: {
                    roles: [USER_ROLES.manager]
                }
            }).
            when('/projects/details/:projectId', {
                templateUrl: '/Templates/project-details.html',
                controller: 'projectDetailsCtrl',
                data: {
                    roles: [USER_ROLES.manager, USER_ROLES.worker]
                }
            }).
            when('/issues/details/:issueId', {
                templateUrl: '/Templates/issue-details.html',
                controller: 'issueDetailsCtrl',
                data: {
                    roles: [USER_ROLES.manager, USER_ROLES.worker]
                }
            }).
            when('/issues/create/:projectId', {
                templateUrl: '/Templates/issue-edit.html',
                controller: 'issueCreateCtrl',
                data: {
                    roles: [USER_ROLES.manager, USER_ROLES.worker]
                }
            }).
            when('/login', {
                templateUrl: '/Templates/login.html',
                controller: 'loginCtrl'
            }).
            when('/error/403', {
                templateUrl: '/Templates/permissiondenied.html'
            }).
            when('/error/404', {
                templateUrl: '/Templates/notfound.html'
            })/*.
            otherwise({
                redirectTo: '/error/404'
            })*/;
        
    }])
    .factory('httpErrorsInterceptor', ['$location', 'alertService', function ($location, alertService) {
        return {
            responseError: function (rejection) {
                if (rejection.status == 404) {
                    $location.path('/error/404');
                }
                if (rejection.status == 403) {
                    alertService.pushAlert('Nem engedélyezett művelet', 'error', 0, true);
                }
            }
        };
    }])
    .run(['AuthService', '$rootScope', '$location', function (AuthService, $rootScope, $location) {
        $rootScope.$on('$routeChangeStart', function (event, next) {

            if (next != undefined && next.data != undefined && next.data.roles != undefined) {
                var authorizedRoles = next.data.roles;

                console.log("a route-ra ezek a felhasználók mehetnek be:");
                console.log(authorizedRoles);
                console.log(AuthService.isAuthenticated());

                if (!AuthService.isAuthenticated()) {
                    console.log("nincs bejelentkezve, login-re irányítok");
                    event.preventDefault();
                    $location.path('/login');
                    return;
                }

                if (!AuthService.isAuthorized(authorizedRoles)) {
                    console.log("nincs jog hozzá, 403-ra irányítok");
                    event.preventDefault();
                    $location.path('/error/403');
                    return;
                }

                console.log("ha idáig eljutottunk, nincs semmi para, továbbmehet a felhasználó a kövi route-ra");
            }

        });
    }]);

})();