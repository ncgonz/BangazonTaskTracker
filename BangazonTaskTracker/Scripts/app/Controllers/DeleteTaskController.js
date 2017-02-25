"use strict";

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

