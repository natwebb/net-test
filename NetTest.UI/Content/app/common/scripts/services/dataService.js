(function (angular) {
    'use strict';

    angular.module('app.services').service('app.services.dataService', [
        '$http',
        'app.constants.baseUrl',
    function ($http, baseUrl) {
        return {
            associateTeamMember: function(data) { return $http({ method: 'POST', url: baseUrl + '/Advertisers/AssociateTeamMember/', data: data }); }
        };
    }]);
})(window.angular);