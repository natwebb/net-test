(function(angular) {
    'use strict';

    angular.module('app').service('app.services.dateService', [
    function() {
        var service = {};

        service.getTimezoneAbbr = getTimezoneAbbr;
        service.unstringifyDate = unstringifyDate;
        service.zeroFromSeconds = zeroFromSeconds;

        return service;

        function getTimezoneAbbr(date) {
            return date.toString().match(/\(([^\)]+)\)/)[1];
        }

        function unstringifyDate(date) {
            return new Date(date);
        }

        function zeroFromSeconds(date) {
            date.setMilliseconds(0);
            date.setSeconds(0);

            return new Date(date);
        }
    }]);
})(window.angular);