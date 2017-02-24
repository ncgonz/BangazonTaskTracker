"use strict"
app.factory("TaskFactory", function ($q, $http) {

    var getList = function () {
        return $q(function (resolve, reject) {
            $http.get('~/api/UserTask')
        }).success(function (taskListing) {
            resolve(taskListing)
        }, function (error) {
            reject(error);
        });
    };
});
