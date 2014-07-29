angular.module('acronym.controllers').controller('AcronymController', ['$scope', 'acronymService', 'models', function ($scope, acronymService, models) {

    // public functions
    $scope.addAcronym = function () {
        acronymService.post($scope.addAcronymModel);
        $scope.addAcronymModel = new models.acronym();
        bindAcronyms();
    }

    // private functions
    function bindAcronyms() {
        acronymService.all().then(function (acronyms) {
            $scope.acronyms = acronyms;
        });
    }

    // initialize
    $scope.addAcronymModel = new models.acronym();
    bindAcronyms();
}]);