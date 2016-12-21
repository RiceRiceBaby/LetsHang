function loadDirectives(app) {
    app.directive("required", function () {
        return {
            restrict: 'A', //only want it triggered for attributes
            compile: function (element) {
                //could add a check to make sure it's an input element if need be
                element.parent('').children('label.fieldlabel')[0].innerHTML =
                    element.parent('').children('label.fieldlabel')[0].innerHTML +
                    "<span style='color:red'>*<span>"
            }

        }
    });

    app.directive("compareTo", function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    });

    app.directive('servervalidation', function () {

        return {
            restrict: 'E',
            replace: true,
            template: '<div class="form-group has-error"></div>',
            scope: {
                validationErrors: '=valErrors'
            },
            link: function (scope, element, attributes) {
 
                var list = '';
                scope.$watch("validationErrors", function (valErrors) {
                    if (valErrors) {
                        list = '<ul>';
                        angular.forEach(valErrors, function (error) {
                            list = list + '<li>' + error + '</li>';
                        });

                        list = list + '</ul>';
                    }

                    element[0].innerHTML = list;
                });
            }
        };
    });

    app.directive('loadmask', function ($uibModal, $timeout) {
        return {
            restrict: 'E',
            replace: true,
            template: [
                '<div style="display:none;" class="modal-dialog">',
                '<div class="modal-header ng-scope" style="text-align: center;">',
                '   {{loadMaskMessage}}',
                '</div>',
                '<div class="modal-body ng-scope">',
                '   <img class="loadmask-image" ng-src="../../Content/img/loadmask.gif" />',
                '</div>',
                '</div>'
            ].join(''),
            link: function (scope, element) {
                scope.$watch(function () {
                    return scope.$root.loadMask
                }, function () {
                    if (scope.$root.loadMask == true) {
                        scope.loadMaskModal = $uibModal.open({
                            template: element[0].innerHTML,
                            size: 'sm',
                            backdrop: 'static',
                            keyboard: 'false'
                        });
                    }
                    else {
                        if (scope.loadMaskModal) {
    
                            $timeout(function () {
                                scope.loadMaskModal.close();
                            }, 1000);
                        }
                    }
                }, true);
            }
        };
    });
}