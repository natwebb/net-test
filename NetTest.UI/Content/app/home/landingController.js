(function (angular) {
    'use strict';

    angular.module('app').controller('app.controllers.home.landingController', [
        '$scope',
        'app.services.dataService',
        'app.services.dropzoneService',
    function ($scope, dataService, dropzone) {
        var canvas = document.getElementById("stageCanvas");
        var context = canvas.getContext("2d");
        var icon = { Url: "", width: 10, height: 10 }; //width and height currently hardcoded to match sample icon

        //Scope
        $scope.steps = [];
        init();

        //Functions
        function init() {
            canvas.addEventListener("click", addStep, false);
        }

        function addStep(e) {
            //console.log("*---------------------------------------*");
            //console.log("Client: (" + e.clientX + ", " + e.clientY + ")");
            //console.log("Layer: (" + e.layerX + ", " + e.layerY + ")");
            //console.log("Offset: (" + e.offsetX + ", " + e.offsetY + ")");
            //console.log("Page: (" + e.pageX + ", " + e.pageY + ")");
            //console.log("Screen: (" + e.screenX + ", " + e.screenY + ")");

            var pos = { x: e.layerX - (icon.width/2), y: e.layerY - (icon.height/2) };

            var stepImg = new Image();
            stepImg.src = icon.Url;

            var step = { img: stepImg, x: pos.x, y: pos.y, reverseY: 150 - pos.y }; //NOTE the hardcoded 150, this is the height of the canvas

            $scope.steps.push(step);

            console.log($scope.steps);
            $scope.$apply();

            stepImg.onload = function () {
                drawStep(step);
            }
        }

        function drawStep(step) {
            context.drawImage(step.img, step.x, step.y);
        }

        function drawSteps() {
            $scope.steps.forEach(drawStep);
        }

        function setCanvasBackground(imgSrc) {
            var bg = new Image();
            bg.src = imgSrc;
            bg.onload = function() {
                context.drawImage(bg, 0, 0, 300, 150);
                drawSteps();
            };
        }

        //Upload Handlers
        var errorHandler = function (file, msg, xhrprog) { console.log(file); console.log(msg); console.log(xhrprog); };
        var completeHandler = function (file) { console.log(file); };

        dropzone.new("div#stageDropzone",
            { url: "/Assets?Container=img&Type=stage&Owner=user", acceptedFiles: "image/*", previewTemplate: "<div />" },
            function (file, data, xhrprog) {
                setCanvasBackground(data.Url);
            },
            errorHandler, completeHandler
        );

        dropzone.new("div#stepDropzone",
            { url: "/Assets?Container=img&Type=step&Owner=user", acceptedFiles: "image/*", previewTemplate: "<div />" },
            function (file, data, xhrprog) {
                icon.Url = data.Url;
            },
            errorHandler, completeHandler
        );
    }]);
})(window.angular);