angular.module('acronym.services').factory('acronymService', ['$resource', 'models', function($resource, models) {

    var resource = $resource('/api/acronym');

    return {
        post: function(acronym) {
            resource.save(acronym);
        },

        all: function() {
            var query = resource.query().$promise;

            query.then(function (acronyms) {
                var result = [];
                for (var i = 0; i < acronyms.length; i++) {
                    var acronym = new models.acronym();
                    acronym.acronym = acronyms[i].acronymText;
                    result.push(acronym);
                }
                return result;
            });

            return query;
        }
    }
}]);