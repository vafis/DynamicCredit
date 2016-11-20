(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope','apiService'];

    function indexCtrl($scope, apiService) {
        $scope.pageClass = 'page-home';
        $scope.loadingCharts = true;
        $scope.loadingWA = true;
        $scope.isReadOnly = true;

        $scope.Chart1Data = [];
        $scope.Chart2Data = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('http://localhost:8080/api/Charts/GetChartsData/', null,
                        chartsLoadCompleted,
                        null);
            apiService.get('http://localhost:8080/api/Charts/GetWeightedAverage/', null,
                         WACompleted,
                         null);
            
        }

        function WACompleted(result) {

            $scope.WAData = result.data;
            $scope.loadingWA = false;
        }

        function chartsLoadCompleted(result) {
            Morris.Bar({
                element: 'Chart1',
                data: result.data.Chart1Data,
                xkey: 'LoanOriginationYear',
                ykeys: ['TotalOriginalPrincipalBalance'],
                stacked: true,
                labels: ['TotalLoans'],
                hoverCallback: function (index, options, content) {
                    var data = options.data[index];
                    $(".morris-hover").html('<div>Total Loans: ' + data.Count + '</div>');
                }
                /*
                hoverCallback: function (index, options, content, row) {
                    var finalContent = $(content);
                    var cpt = 0;

                    $.each(row, function (n, v) {
                        if (v == null) {
                            $(finalContent).eq(cpt).empty();
                        }
                        cpt++;
                    });

                    return finalContent;
                }
                */
            });
            Morris.Bar({
                element: 'Chart2',
                data: result.data.Chart2Data,

                xkey: 'Range',
                ykeys: ['Count'],
                stacked: true,
                labels: ['Count']
            });
            $scope.loadingCharts = false;
        }
        
        loadData();
    }

})(angular.module('DynamicCredit'));