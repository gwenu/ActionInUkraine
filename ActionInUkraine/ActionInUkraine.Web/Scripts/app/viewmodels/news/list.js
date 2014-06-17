define(function (require) {

    var vmRepository = require("repositories/vmRepository");

    return {
        news: ko.observableArray(),
        activate: function () {
            var self = this;
            vmRepository.listNews(function (result) {
                self.news(result);
            });
        }
    }
});