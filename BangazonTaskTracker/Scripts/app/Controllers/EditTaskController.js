﻿"use strict";

app.controller('EditTaskController', ['$scope', '$location', '$TaskFactory', '$http', function ($scope, $location, TaskFactory, $http) {
    $scope.getATask;
    $scope.getATask = function () {
        TaskFactory.getTask($scope.getATask).then(function (taskReturn) {
            $scope.taskArray = taskReturn.dataset.data[0];
        })
    }
}]);
