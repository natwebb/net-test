(function (angular) {
    'use strict';

    angular.module('app').controller('app.controllers.home.landingController', [
        '$scope',
        'app.services.dataService',
        'app.services.dropzoneService',
    function ($scope, dataService, dropzone) {
        var canvas = document.getElementById("stageCanvas");
        var context = canvas.getContext("2d");

        //Scope

        init();

        //Functions
        function init() {
            canvas.addEventListener("click", addStep, false);
        }

        function addStep(e) {
            console.log("*---------------------------------------*");
            console.log("Client: (" + e.clientX + ", " + e.clientY + ")");
            console.log("Layer: (" + e.layerX + ", " + e.layerY + ")");
            console.log("Offset: (" + e.offsetX + ", " + e.offsetY + ")");
            console.log("Page: (" + e.pageX + ", " + e.pageY + ")");
            console.log("Screen: (" + e.screenX + ", " + e.screenY + ")");

            var coords = [e.layerX, e.layerY];
            var bottomUpCoords = [coords[0], 150 - coords[1]];

            console.log(coords);
            console.log(bottomUpCoords);
        }

        function setCanvasBackground(imgSrc) {
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