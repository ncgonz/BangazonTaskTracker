var app = angular.module("Tracker", ["ngRoute"]);

//put my app.config angular stuff here

app.controller('UserTaskController', ['$scope', '$http', function ($scope, $http) {
        $http({
            url: '/api/UserTask',
            method: "GET"
        })
        .then(function (result) {
            $scope.UserTasks = result.data;
        }, function (error) {
        })
}]);

