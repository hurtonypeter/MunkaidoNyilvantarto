(function () {

    "use strict";

    angular.module('munkaidoNyilvantarto', ['controllers', 'routes', 'services']);
    angular.module('routes', ['ngRoute', 'services']);
    angular.module('services', []);
    angular.module('controllers', ['services', 'userControllers', 'projectControllers', 'issueControllers', 'analyticsControllers']);
    angular.module('userControllers', []);
    angular.module('projectControllers', []);
    angular.module('issueControllers', []);
    angular.module('analyticsControllers', []);

    angular.module('munkaidoNyilvantarto')
    .config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('httpLoadingAnimationInterceptor');
    }])
    .factory('httpLoadingAnimationInterceptor', [function () {
        return {
            request: function (config) {
                $('.page-spinner-bar').show();
                return config;
            },
            requestError: function () {
                $('.page-spinner-bar').hide();
            },
            response: function (response) {
                $('.page-spinner-bar').hide();
                return response;
            },
            responseError: function () {
                $('.page-spinner-bar').hide();
            }
        }
    }]);

})();