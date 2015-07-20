(function (angular) {
    'use strict';

    angular.module('app').controller('app.controllers.home.landingController', [
        '$scope',
        'app.services.dataService',
    function ($scope, dataService) {
        dataService.getMessage('20748448-B7FE-40C5-99CD-D9FEF331BA42')
            .then(function(response) { console.log(response.data); });
    }]);
})(window.angular);