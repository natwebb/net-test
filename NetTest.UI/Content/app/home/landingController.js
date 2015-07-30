(function (angular) {
    'use strict';

    angular.module('app').controller('app.controllers.home.landingController', [
        '$scope',
        'app.services.dataService',
        'app.services.dropzoneService',
    function ($scope, dataService, dropzone) {
        //Scope

        //Functions
        function setCanvasBackground(imgSrc) {
            var canvas = document.getElementById("stageCanvas");
            var context = canvas.getContext("2d");
            var bg = new Image();
            bg.src = imgSrc;
            bg.onload = function() {
                context.drawImage(bg, 0, 0, 300, 150);
            };
        }


        //Upload Handler
        var errorHandler = function (file, msg, xhrprog) { console.log(file); console.log(msg); console.log(xhrprog); };
        var completeHandler = function (file) { console.log(file); };

        dropzone.new("div#stageDropzone",
            { url: "/Assets?Container=img&Type=stage&Owner=user", acceptedFiles: "image/*", previewTemplate: "<div />" },
            function (file, data, xhrprog) { console.log(data);
                setCanvasBackground(data.Url);
            },
            errorHandler, completeHandler
        );
    }]);
})(window.angular);