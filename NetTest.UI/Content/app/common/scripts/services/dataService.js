(function (angular) {
    'use strict';

    angular.module('app.services').service('app.services.dataService', [
        '$http',
        'app.constants.baseUrl',
    function ($http, baseUrl) {
        return {
            getMessage: function(id) { return $http({ method: 'GET', url: baseUrl + '/Messages?id=' + id }); }
        };
    }]);
})(window.angular);