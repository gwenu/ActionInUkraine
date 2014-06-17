define(function (require) {
    var router = require('durandal/plugins/router');
    var vmRepository = require("repositories/vmRepository");
    var globalId;
    return {
        ideaToShow: ko.observable({
            id: ko.observable(0),
            title: ko.observable(),
            image: ko.observable(""),
            category: ko.observable(),
            description: ko.observable(),
            goalsList: ko.observableArray(),
            startDate: ko.observable(),
            endDate: ko.observable(),
            smthElse: ko.observable(""),
            //budgetList: ko.observableArray(),
            alreadyIs: ko.observable("")
        }),
        ideas: ko.observableArray(),
        idea: ko.observable(),


        activate: function (context) {
            var self = this;
            var idea = vmRepository.getIdea(context.id, function (idea) {
                self.ideaToShow(idea);
            });
            globalId = context.id;
            //var id = context.id;


        },
        viewAttached: function () {
            var id = globalId;
            disqus_shortname = 'diyavukrayini9',
            disqus_identifier = id,
            disqus_title = id,
            disqus_url = "http://myportal.com/#!" + id;
            if ($('head script[src="http://' + disqus_shortname + '.disqus.com/embed.js"]').length == 0) {
                (function () {
                    var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
                    dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
                    (document.getElementsByTagName('head')[0]).appendChild(dsq);
                })();
            }
            if (typeof DISQUS != "undefined") {
                DISQUS.reset({
                    reload: true,
                    config: function () {
                        this.page.identifier = id;
                        this.page.url = "http://myportal.com/#!" + id;
                    }
                });
            }
        }
    };

});