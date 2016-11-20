(function () {
    'use strict';

    angular.module('DynamicCredit', ['common.core', 'common.ui'])
        .config(config)
        .run();

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/app/home/index.html",
                controller: "indexCtrl"
            }).otherwise({ redirectTo: "/" });
    }

})();