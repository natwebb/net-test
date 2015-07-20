(function(angular) {
    'use strict';

    angular.module('app').config([
        '$stateProvider',
        //'app.constants.regexConstants',
        function ($stateProvider) {
            $stateProvider
            .state(
                'home',
                {
                    url: '/',
                    templateUrl: 'templates/fetch/home-landing',
                    controller: 'app.controllers.home.landingController'
                }
            );
        }
    ]);
})(window.angular);