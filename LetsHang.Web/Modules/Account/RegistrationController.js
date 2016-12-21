define(['app-config','accountService'], function (app) {
    app.register.controller('RegistrationController', ['$scope', '$rootScope', '$location', '$uibModal', 'accountService',
        function ($scope, $rootScope, $location, $uibModal, accountService) {
            $rootScope.applicationModule = "Registration";

            // Validation
            $scope.passwordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";

            $scope.registerUserSuccess = function (response, status) {
                $location.path("/RegistrationSuccess");
            }

            $scope.registerUserFailure = function (response, status) {
                $scope.ErrorList = response.ValidationErrors;
            }

            $scope.onSubmitClick = function (isValid) {
                if (isValid) {
                    accountService.registerUser($scope.regModel, $scope.registerUserSuccess, $scope.registerUserFailure);
                }
            }

            $scope.onCancelClick = function () {
                $location.path("/Login");
            }
        }
    ]);
});
