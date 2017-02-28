"use strict";

app.controller('DeleteTaskController', ['$scope', '$http', '$location', 'TaskFactory', function ($scope, $http, $location, TaskFactory) {
    $scope.deleteTask;
    $scope.deleteTask = function () {
        TaskFactory.deleteTask($scope.deleteTask).then(function (taskReturn) {
            $scope.taskToDelete = RemoveUserTask(_id).dataset.data;
        })
    }
}]);

