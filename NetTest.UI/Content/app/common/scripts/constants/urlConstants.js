(function (angular) {
    'use strict';

    var mode = {
        ///////////////////////
        // LOCAL:
        // Use when the published version ain't working
        loc: '', //this space intentionally left blank
        locapi: '',

        ///////////////////////
        // DEVELOPMENT:
        // Use for development - no database concerns
        dev: '',

        ///////////////////////
        // STAGING:
        // Use for viewing against stable internal data - database managed but internal facing
        stg: '',

        ///////////////////////
        // USER ACCEPTANCE TESTING:
        // Use for viewing against stable external data - database managed for demo purposes
        uat: ''
    };

    angular.module('app.constants').constant('app.constants.baseUrl', mode.loc);
})(window.angular);