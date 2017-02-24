"use strict";

app.controller('TaskController', ['$scope', '$location', '$TaskFactory', '$http', function ($scope, $location, TaskFactory, $http) {
    $scope.getATask;
    $scope.getATask = function () {
        TaskFactory.getList($scope.getATask).then(function (taskReturn) {
            $scope.taskArray = taskReturn.dataset.data[0];
        })
    }
}]);
    


    app.controller('EditTaskController', ['$scope', '$http', function ($scope, $http) {
        $http({
            url: '/api/UserTask',
            method: "PUT"
        })
        .then(function (result) {
            $scope.UserTask = result.data;
        }, function (error) {
        })
    }]);
    app.controller('DeleteTaskController', ['$scope', '$http', function ($scope, $http) {
        $http({
            url: '/api/UserTask',
            method: "DELETE"
        })
        .then(function (result) {
            $scope.UserTask = result.data;
        }, function (error) {
        })
    }]);
    app.controller('AddTaskController', ['$scope', '$http', function ($scope, $http) {
        $http({
            url: '/api/UserTask',
            method: "POST"
        })
        .then(function (result) {
            $scope.UserTask = result.data;
        }, function (error) {
        })
    }]);

