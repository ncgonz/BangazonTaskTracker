"use strict"

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
