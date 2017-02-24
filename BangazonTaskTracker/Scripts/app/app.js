var app = angular.module("Tracker", ["ngRoute"]);

//Angular Routing
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/TaskController/:userTaskId', {
            templateUrl: '/Partials/listOfUserTasks.html',
            controller: 'TaskController'
        })
        .when('/', {
            templateUrl: '/Partials/listOfUserTasks.html',
            controller: 'TaskController'
        })
        .when('/AddTaskController/:userTask', {
            templateUrl: '/Partials/inputTask.html',
            controller: 'AddTaskController'
        })
        .when('/EditTaskController/:id, value', {
            templateUrl: '/Partials/editTask.html',
            controller: 'EditTaskController'
        })
        .when('/DeleteTaskController/:_id', {
            templateURL: '/Partials/listOfUserTasks.html',
            controller: 'DeleteTaskController'
        })
}]);

