var app = angular.module("messageBoard", []);
app.controller("homeIndexController", function ($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true")
    .then(function (result) {
        angular.copy(result.data, $scope.data);
    },
    function () {
        alert("could not load topics");
    })
    .then(function () {
        $scope.isBusy = false;
    });
});
