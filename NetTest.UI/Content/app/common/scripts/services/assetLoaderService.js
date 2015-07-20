(function (angular) {
    'use strict';

    angular.module('app.services').service('app.services.assetLoader', [
        '$q',
        '$rootScope',
    function ($q, $rootScope) {
        var service = {};

        service.loadedAssets = service.loadedAssets || [];
        service.load = load;

        return service;

        //---------Methods---------//
        function load(url) {
            var head = document.getElementsByTagName('head')[0]; // define starting paths for each file tile
            var body = document.getElementsByTagName('body')[0]; // define starting paths for each file tile
            var imgTypes = ['jpg', 'jpeg', 'png', 'gif'];

            var waitforload = $q.defer();
            var fileType = url.split('.').pop().toLowerCase();

            if (service.loadedAssets.indexOf(url) >= 0) {
                return true;
            };
            service.loadedAssets.push.apply(service.loadedAssets, [url]);

            // CSS
            if (fileType === 'css') {
                var cssFile = document.createElement('link');
                cssFile.setAttribute('rel', 'stylesheet');
                cssFile.setAttribute('type', 'text/css');
                cssFile.setAttribute('href', url);
                head.appendChild(cssFile);
                return true;
            };

            // JS
            if (fileType === 'js') {
                var jsFile = document.createElement('script');
                jsFile.src = url;
                body.appendChild(jsFile);

                jsFile.onload = function () {
                    $rootScope.$apply(function () {
                        waitforload.resolve(jsFile);
                    });
                };
                jsFile.onerror = function (e) {
                    waitforload.reject(e);
                    console.log('Could not load ' + jsFile.src);
                };

                return waitforload.promise;
            };

            // IMG
            if (imgTypes.indexOf(fileType) >= 0) {
                var image = new Image();
                image.src = url;

                image.onload = function () {
                    waitforload.resolve(image);
                };

                image.onerror = function (e) {
                    waitforload.reject(e);
                    console.log('Could not load ' + image.src);
                };

                return waitforload.promise;
            };
        };
    }]);
})(window.angular);