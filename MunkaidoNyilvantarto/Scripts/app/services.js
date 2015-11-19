(function () {

    "use strict";

    angular.module('services')
    .constant('USER_ROLES', {
        manager: 'manager_role',
        worker: 'worker_role',
        guest: 'guest_role'
    })
    .factory('AuthService', ['$http', 'Session', function ($http, Session) {
        return {

            login: function (credentials) {

            },

            isAuthenticated: function () {
                return !!Session.userId;
            },

            isAuthorized: function (authorizedRoles) {
                if (!angular.isArray(authorizedRoles)) {
                    authorizedRoles = [authorizedRoles];
                }
                return (this.isAuthenticated() && authorizedRoles.indexOf(Session.userRole) !== -1);
            }

        }
    }])
    .factory('Session', [function () {
        var session = {};

        return {
            create: function (sessionId, userId, userRoles) {
                session = {
                    id: sessionId,
                    userId: userId,
                    userRoles: userRoles
                };
            },

            destroy: function () {
                session = {};
            }
        }
    }]);

})();