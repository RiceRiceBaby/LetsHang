define(['app-config', 'accountService'], function (app) {
    app.register.controller('LoginController', ['$scope', '$rootScope', 'accountService',
        function ($scope, $rootScope, accountService) {
            //$rootScope.applicationModule = "Login";

            $scope.LoginSuccess = function (response) {
                alert("Logged in Successfully");
            };

            $scope.LoginFailure = function (response) {
                alert("Invalid User or Password. Pleace Try agin");
            };
            // Login user
            $scope.submitForm = function (isValid) {
                
                if (isValid) {
                    accountService.LoginUser($scope.LoginModel, $scope.LoginSuccess, $scope.LoginFailure);
                }
            }
        }
     ])
});