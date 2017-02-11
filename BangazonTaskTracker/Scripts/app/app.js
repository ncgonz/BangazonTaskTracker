var app = angular.module("Tracker", ["ngRoute"]);


app.controller('UserTaskController', ['$scope', '$http', function ($scope, $http) {
    $http({
        url: '/api/UserTaskController/',
        method: "GET"
    })
        .then(function (result) {
            $scope.UserTasks = result.data;
        }, function (error) {
        });
}]);
