var Acronym = function() {
    this.acronym = null;
}

angular.module('acronym.models').value('models', {
    acronym: Acronym
});