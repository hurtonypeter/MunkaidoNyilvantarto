(function () {

    "use strict";

    function guid() {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    }

    angular.module('services')
    .constant('USER_ROLES', {
        manager: 'Manager',
        worker: 'Worker'
    })
    .factory('AuthService', ['$http', 'Session', '$rootScope', function ($http, Session, $rootScope) {
        return {

            login: function (credentials) {
                return $http.post('/Account/LoginToAngular', credentials).then(function (resp) {
                    console.log(resp);
                    if (resp.data.Succeeded) {
                        Session.create(guid(), resp.data.Data.UserId, resp.data.Data.UserName, resp.data.Data.UserRoles);
                        $rootScope.$broadcast('loginSuccess');
                    }
                    return resp;
                });
            },

            currentUser: function() {
                if (this.isAuthenticated()) {
                    return Session;
                }
                else {
                    return null;
                }
            },

            isAuthenticated: function () {
                return !!Session.userId;
            },

            isAuthorized: function (authorizedRoles) {
                if (!angular.isArray(authorizedRoles)) {
                    authorizedRoles = [authorizedRoles];
                }
                console.log("session user role-ok:");
                console.log(Session.userRole);
                var intersection = authorizedRoles.filter(function (n) {
                    return Session.userRole.indexOf(n) != -1;
                });
                return intersection.length != 0;
                //return (authorizedRoles.indexOf(Session.userRole) !== -1);
            }

        }
    }])
    .service('Session', [function () {

        this.create = function (sessionId, userId, userName, userRole) {
            this.id = sessionId;
            this.userId = userId;
            this.userName = userName;
            this.userRole = userRole;
        };
        this.destroy = function () {
            this.id = null;
            this.userId = null;
            this.userName = null;
            this.userRole = null;
        };

    }])
    .factory('alertService', ['$window', '$rootScope', function ($window, $rootScope) {
        $rootScope.$on('$locationChangeStart', function (event) {
            $('#message-container').html('');
        });

        return {
            clearAlerts: function () {
                $('#message-container').html('');
            },
            pushErrors: function (errors) {
                for (var i = 0; i < errors.length; i++) {
                    this.pushAlert(errors[i].Value, "error", 0, true);
                }
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
                    message += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true"><span aria-hidden="true">&times;</span></button>';
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