(function (angular) {
    'use strict';

    angular.module('app.constants').constant('app.constants.regexConstants', {
        guid: '[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}'
});
})(window.angular);