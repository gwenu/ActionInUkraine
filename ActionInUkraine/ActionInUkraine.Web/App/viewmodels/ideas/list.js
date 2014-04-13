define(function (require) {

    var vmRepository = require("repositories/vmRepository");

    return {
        ideas: ko.observableArray(),
        activate: function () {
            var self = this;
            vmRepository.listIdeas(function (result) {
                self.ideas(result);
            });
        }
    }
});