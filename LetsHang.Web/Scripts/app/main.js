/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
require.config({

    baseUrl: "",

    // alias libraries paths
    paths: {
        'app-config' : 'scripts/app/app-config',
        'angular': 'scripts/angular',
        'angular-route': 'scripts/angular-route',
        'angular-animate': 'scripts/angular-animate',
        'angular-touch': 'scripts/angular-touch',
        'angularAMD': 'scripts/angularAMD',
        'bootstrap' : 'scripts/bootstrap',
        'jquery' : 'scripts/jquery-1.9.1',
        'ui-bootstrap': 'scripts/angular-ui/ui-bootstrap-tpls',
        'ui-grid' : 'scripts/ui-grid',
        'ngload': 'scripts/ngload',
        'directive': 'scripts/app/directive',
        'accountService': 'services/accountService'
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        'bootstrap': ['jquery'],
        'angularAMD': ['angular'],
        'ui-bootstrap': ['angular', 'bootstrap'],
        'ui-grid': ['angular-touch', 'angular-animate'],
        'app-config': ['angular', 'directive']
    },

    // kick start application
    deps: ['app-config']
});
