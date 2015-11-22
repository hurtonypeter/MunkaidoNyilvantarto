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
    }])
    .factory('alertService', ['$window', '$rootScope', function ($window, $rootScope) {
        $rootScope.$on('$locationChangeStart', function (event) {
            $('#message-container').html('');
        });

        return {
            clearAlerts: function () {
                $('#message-container').html('');
            },
            pushAlert: function (text, type, timing, dismissable) {
                var classes = 'alert';
                switch (type) {
                    case 'success':
                        classes += ' alert-success';
                        break;
                    case 'info':
                        classes += ' alert-info';
                        break;
                    case 'warning':
                        classes += ' alert-warning';
                        break;
                    case 'error':
                        classes += ' alert-danger';
                        break;
                    default:
                        classes += ' alert-info';
                }
                if (dismissable) {
                    classes += ' alert-dismissable';
                }

                var message = '<div class="' + classes + '">';

                if (dismissable) {
                    message += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>';
                }

                message += text + '</div>';

                if (timing == 0) {
                    $('#message-container').prepend($(message).fadeIn('slow'));
                }
                else {
                    $(message).fadeIn('slow').prependTo('#message-container').delay(timing).queue(function (next) {
                        $(this).fadeOut('slow', function () { $(this).remove(); });
                        next();
                    })
                }
            }
        };
    }]);

})();