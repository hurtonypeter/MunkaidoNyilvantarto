﻿(function () {

    "use strict";

    angular.module('munkaidoNyilvantarto', ['controllers', 'routes', 'services']);
    angular.module('routes', ['ngRoute', 'services']);
    angular.module('services', []);
    angular.module('controllers', ['services', 'userControllers', 'projectControllers', 'issueControllers']);
    angular.module('userControllers', []);
    angular.module('projectControllers', []);
    angular.module('issueControllers', []);

})();