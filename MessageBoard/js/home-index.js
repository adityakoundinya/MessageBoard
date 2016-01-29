
var app = angular.module('homeIndex', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/templates/topicsView.html"
    });
    $routeProvider.otherwise({ redirectTo: "/" });
}]);

app.controller('topicsController', function ($scope, $http) {
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

