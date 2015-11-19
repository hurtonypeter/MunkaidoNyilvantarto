(function () {

    "use strict";

    angular.module('munkaidoNyilvantarto', ['controllers', 'routes', 'services']);
    angular.module('routes', ['ngRoute', 'services']);
    angular.module('services', []);
    angular.module('controllers', ['userControllers']);
    angular.module('userControllers', ['services']);

})();