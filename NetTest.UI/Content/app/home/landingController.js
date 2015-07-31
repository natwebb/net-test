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
        $scope.stage = {
            background: { Url: "https://test07162015.blob.core.windows.net/img/user/stage/mario3.jpg", width: 570, height: 373 }, //url, width and height currently hardcoded to match sample background
            stepIcon: { Url: "https://test07162015.blob.core.windows.net/img/user/step/offline.png", width: 10, height: 10 }, //url, width and height currently hardcoded to match sample icon
            steps: []
        };
        $scope.selectedStep = null;
        init();

        //Functions
        function init() {
            canvas.addEventListener("click", checkClick, false);
            redrawMap();
        }

        function addStep(x, y) {
            //console.log("*---------------------------------------*");
            //console.log("Client: (" + e.clientX + ", " + e.clientY + ")");
            //console.log("Layer: (" + e.layerX + ", " + e.layerY + ")");
            //console.log("Offset: (" + e.offsetX + ", " + e.offsetY + ")");
            //console.log("Page: (" + e.pageX + ", " + e.pageY + ")");
            //console.log("Screen: (" + e.screenX + ", " + e.screenY + ")");

            var pos = { x: x - ($scope.stage.stepIcon.width / 2), y: y - ($scope.stage.stepIcon.height / 2) };

            var step = { x: pos.x, y: pos.y, reverseY: $scope.stage.background.height - pos.y };

            $scope.stage.steps.push(step);
            $scope.$apply();

            drawStep(step);
        }

        function checkClick(e) {
            var pos = { x: e.layerX, y: e.layerY };

            var chosen = false;

            $scope.stage.steps.forEach(function (step) {
                if (pos.x >= step.x && pos.x <= step.x + 10 && pos.y >= step.y && pos.y <= step.y + 10) {
                    $scope.selectedStep = step;
                    $scope.$apply();
                    chosen = true;
                }
            });

            if (chosen === false) {
                if ($scope.selectedStep === null) {
                    addStep(e.layerX, e.layerY);
                } else {
                    moveStep(e.layerX, e.layerY);
                }
            }
        }

        function drawBackground() {
            var bg = new Image();
            bg.src = $scope.stage.background.Url;
            bg.onload = function () {
                context.drawImage(bg, 0, 0, $scope.stage.background.width, $scope.stage.background.height);
                drawSteps();
            };
        }

        function drawStep(step, img) {
            console.log(img);
            if (img === null || img === undefined) {
                var stepImg = new Image();
                stepImg.src = $scope.stage.stepIcon.Url;

                stepImg.onload = function() {
                    context.drawImage(stepImg, step.x, step.y);
                };
            } else {
                context.drawImage(img, step.x, step.y);
            }
        }

        function drawSteps() {
            var img = new Image();
            img.src = $scope.stage.stepIcon.Url;
            img.onload = function() {
                $scope.stage.steps.forEach(function(step) { drawStep(step, img); });
            }
        }

        function moveStep(newX, newY) {
            $scope.selectedStep.x = newX - ($scope.stage.stepIcon.width / 2);
            $scope.selectedStep.y = newY - ($scope.stage.stepIcon.height / 2);
            $scope.$apply();
            redrawMap();
            $scope.selectedStep = null;
            $scope.$apply();
        }

        function redrawMap() {
            context.clearRect(0, 0, canvas.width, canvas.height);
            drawBackground();
            drawSteps();
        }

        //Upload Handlers
        var errorHandler = function (file, msg, xhrprog) { console.log(file); console.log(msg); console.log(xhrprog); };
        var completeHandler = function (file) { console.log(file); };

        dropzone.new("div#stageDropzone",
            { url: "/Assets?Container=img&Type=stage&Owner=user", acceptedFiles: "image/*", previewTemplate: "<div />" },
            function (file, data, xhrprog) {
                $scope.stage.background.Url = data.Url;
                drawBackground();
            },
            errorHandler, completeHandler
        );

        dropzone.new("div#stepDropzone",
            { url: "/Assets?Container=img&Type=step&Owner=user", acceptedFiles: "image/*", previewTemplate: "<div />" },
            function (file, data, xhrprog) {
                $scope.stage.stepIcon.Url = data.Url;
            },
            errorHandler, completeHandler
        );
    }]);
})(window.angular);