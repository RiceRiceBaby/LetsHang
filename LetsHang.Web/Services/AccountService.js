define(['app-config'], function (app) {
    app.register.service('accountService', ['$http', '$rootScope', '$timeout', function ($http, $rootScope, $timeout) {
        this.registerUser = function (user, successFunction, errorFunction) {
            // Initialization
            $rootScope.loadMaskMessage = "Saving...";
            $rootScope.loadMask = true;

            $http.post('/WebApi/Account/RegisterUser', user)
            .success(function (response, status, headers, config) {
                $rootScope.loadMask = false;
                $timeout(function () {
                    successFunction(response, status)
                }, 1500);
            })
            .error(function (response, status) {
                $rootScope.loadMask = false;
                $timeout(function () {
                    errorFunction(response, status)
                }, 1500);
            });
        }
    }]);
});