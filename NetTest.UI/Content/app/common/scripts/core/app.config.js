(function (angular) {
    'use strict';

    angular.module('app').config([
        '$urlRouterProvider',
        '$httpProvider',
    function ($urlRouterProvider, $httpProvider) {
        //$httpProvider.interceptors.push('app.services.httpInterceptorService');

        $urlRouterProvider.otherwise('/');
    }]);
})(window.angular);