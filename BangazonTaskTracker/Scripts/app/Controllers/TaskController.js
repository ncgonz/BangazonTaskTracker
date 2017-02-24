"use strict";

app.controller('TaskController', ['$scope', '$location', '$TaskFactory', '$http', function ($scope, $location, TaskFactory, $http) {
    $scope.getAList;
    $scope.getAList = function () {
        TaskFactory.getList($scope.getAList).then(function (taskReturn) {
            $scope.taskArray = taskReturn.dataset.data[0];
        })
    }
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

