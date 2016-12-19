/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
require.config({

    baseUrl: "",

    // alias libraries paths
    paths: {
        'application-configuration' : 'scripts/app/app-config',
        'angular': 'scripts/angular',
        'angular-route': 'scripts/angular-route',
        'angular-animate': 'scripts/angular-animate',
        'angular-touch': 'scripts/angular-touch',
        'angularAMD': 'scripts/angularAMD',
        'bootstrap' : 'scripts/bootstrap',
        'ui-bootstrap': 'scripts/angular-ui/ui-bootstrap-tpls',
        'ui-grid' : 'scripts/ui-grid',
        'ngload': 'scripts/ngload',
        'angular-directive': 'scripts/angular-configuration/angular-directive',
        'administrationService': 'services/administrationService',
        'accountService': 'services/accountService',
        'lookupService': 'services/lookupService'
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        'angularAMD': ['angular'],
        'ui-bootstrap': ['angular', 'bootstrap'],
        'ui-grid': ['angular-touch', 'angular-animate']
    },

    // kick start application
    deps: ['application-configuration']
});
