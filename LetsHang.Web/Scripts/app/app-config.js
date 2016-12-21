define(['angularAMD', 'angular-route', 'ui-bootstrap', 'ui-grid'], function (angularAMD) {
    var app = angular.module("LetsHang", ['ngRoute', 'ui.bootstrap', 'ui.grid']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider
        .when("/", angularAMD.route({
            templateUrl: function (rp) { return 'Modules/Account/login.html'; },
            controllerUrl: 'Modules/Account/LoginController'
        }))
        .when("/Registration", angularAMD.route({
            templateUrl: function (rp) { return 'Modules/Account/Registration.html'; },
            controllerUrl: 'Modules/Account/RegistrationController'
        }))
        .when("/:module/:page", angularAMD.route({
            templateUrl: function (rp) { return 'Modules/' + rp.module + '/' + rp.page + '.html'; },
            resolve: {
                load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {
                    var path = $location.path();
                    var parsePath = path.split('/');
                    var parentPath = parsePath[1];
                    var controllerName = parsePath[2];

                    var loadController = "Modules/" + parentPath + "/" + controllerName + "Controller";

                    var deferred = $q.defer();

                    require([loadController], function () {
                        $rootScope.$apply(function () {
                            deferred.resolve();
                        });
                    });

                    return deferred.promise;
                }]
            }
        }))
        .otherwise({ redirectTo: '/' });
    }]);

    loadDirectives(app);
    angularAMD.bootstrap(app);

    return app;
});