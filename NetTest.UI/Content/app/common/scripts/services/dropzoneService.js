// Based on Dropzone upload library: http://www.dropzonejs.com/
(function (angular) {
    'use strict';

    angular.module('app.services').service('app.services.dropzoneService', [

        function () {
            var service = {};

            service.dropZone = null;
            service.exists = exists;
            service.getElement = getElement;
            service.new = init;

            return service;

            //----------Methods----------//
            function exists(id) {
                return (Dropzone.getElement(id) ? true : false);
            }

            function getElement(id) {
                console.log(id);
                return Dropzone.getElement(id);
            }

            function init(id, options, sevt, eevt, cevt) {
                var dz = new Dropzone(id, options);
                dz.on('success', sevt);
                dz.on('error', eevt);
                dz.on('complete', cevt);
                return dz;
            }
        }
    ]);
})(window.angular);