(function (angular) {
    'use strict';

    angular.module('app.services').service('app.services.httpInterceptorService', [
        '$q',
        '$rootScope',
    function ($q, $rootScope) {

        return {
            response: success,
            responseError: failure
        };

        //-----------Methods-----------//

        function failure(resp) {
            processResponse(resp);
            return $q.reject(resp);
        }

        function success(resp) {
            processResponse(resp);
            return resp || $q.when(resp);
        }

        function processResponse(resp) {
            // Process Standard Http Status Codes:  http://www.iana.org/assignments/http-status-codes/http-status-codes.xml
            // 401: Unauthorized
            if (resp.status === 401) {
                $rootScope.DialogService.CloseActiveDialogs();
                $rootScope.DialogService.Authentication.NotAuthorized(false);
            }

            // 422: Unprocessable Entity
            else if (resp.status === 422) {
                $rootScope.DialogService.CloseActiveDialogs();
                //$rootScope.DialogService.Dialogs.OpenErrorDialog(true);
                $rootScope.$broadcast('openErrorBar', { message: resp.data.Messages });
            }

            // 500: Internal Server Error
            else if (resp.status === 500) {
                $rootScope.DialogService.CloseActiveDialogs();
                //$rootScope.DialogService.Dialogs.OpenErrorDialog(true);
                var ex = angular.fromJson(resp.data.Messages.message);
                console.log(ex);
                ex.Exception.forEach(function(exceptionMessage) {
                    $rootScope.$broadcast('openErrorBar', { message: exceptionMessage });
                });
            }
        }
    }]);
})(window.angular);