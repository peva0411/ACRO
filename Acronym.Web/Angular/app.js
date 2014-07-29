angular.module('acronym.controllers', []);
angular.module('acronym.directives', []);
angular.module('acronym.models', []);
angular.module('acronym.services', []);

angular.module('acronym', [
    'ngRoute',
    'ngResource',
    'acronym.controllers',
    'acronym.directives',
    'acronym.models',
    'acronym.services'
]).config(function ($routeProvider) {

    $routeProvider
        .when('/', { templateUrl: 'Angular/Views/Acronym.html', controller: 'AcronymController' })
        .otherwise({ redirectTo: '404.html' });
});

