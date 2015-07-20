(function(angular) {
    'use strict';

    angular.module('app', [
        'ui.router',
        'app.directives',
        'app.constants',
        'app.services',
        'app.filters',
        'app.providers',
        'app.controllers',
        'app.factories'
    ]);

    angular.module('app.providers', []);
    angular.module('app.constants', []);
    angular.module('app.directives', []);
    angular.module('app.filters', []);
    angular.module('app.services', []);
    angular.module('app.controllers', []);
    angular.module('app.factories', []);
})(window.angular);