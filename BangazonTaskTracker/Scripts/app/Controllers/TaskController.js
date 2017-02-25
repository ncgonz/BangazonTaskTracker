"use strict";

app.controller('TaskController', ['$scope', '$location', '$TaskFactory', '$http', function ($scope, $location, TaskFactory, $http) {
    $scope.getAList;
    $scope.getAList = function () {
        TaskFactory.getList($scope.getAList).then(function (taskReturn) {
            $scope.taskArray = taskReturn.dataset.data[0];
        })
    }
}]);
    


   
   