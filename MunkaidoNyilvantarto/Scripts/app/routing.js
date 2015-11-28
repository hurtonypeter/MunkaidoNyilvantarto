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
                controller: 'projectListCtrl'
            }).
            when('/projects/create', {
                templateUrl: '/Templates/project-edit.html',
                controller: 'projectCreateCtrl'
            }).
            when('/projects/details/:projectId', {
                templateUrl: '/Templates/project-details.html',
                controller: 'projectDetailsCtrl'
            }).
            when('/issues/details/:issueId', {
                templateUrl: '/Templates/issue-details.html',
                controller: 'issueDetailsCtrl'
            }).
            when('/issues/create/:projectId', {
                templateUrl: '/Templates/issue-edit.html',
                controller: 'issueCreateCtrl'
            }).
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
            })/*.
            otherwise({
                redirectTo: '/error/404'
            })*/;
        
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

            if (next != undefined && next.data != undefined && next.data.roles != undefined) {
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