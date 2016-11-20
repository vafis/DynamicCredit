(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope','$location'];
    function rootCtrl($scope, $location) {

        $scope.userData = {};
    }

})(angular.module('DynamicCredit'));