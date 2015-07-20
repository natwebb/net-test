(function(angular) {
    'use strict';

    angular.module('app.controllers').controller('app.controllers.navigationController', [
        '$scope',
        '$location',
    function ($scope, $location) {
        $scope.IsActive = function (route) {
            var path = $location.path();
            if (path.length === 1 && path === '/') { path = '/advertiser'; }
            return path.substring(0, 4) === route.substring(0, 4);
        };
    }]);
})(window.angular);