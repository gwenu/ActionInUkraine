define(function (require) {
    var router = require('durandal/plugins/router');
    var vmRepository = require("repositories/vmRepository");

    return {
        ideaToShow: {
            id: ko.observable(0),
            title: ko.observable().extend({ required: true, minLength: 4 }),
            image: ko.observable(""),
            category: ko.observable().extend({ required: true }),
            description: ko.observable().extend({ required: true, minLength: 10 }),
            goalsList: ko.observableArray(),
            startDate: ko.observable().extend({ required: true }),
            endDate: ko.observable().extend({ required: true }),
            othersList: ko.observableArray(),
            otherToAdd: ko.observable(""),
            goalToAdd: ko.observable("")
        },
        ideas: ko.observableArray(),
        idea: ko.observable(),

        activate: function (context) {
            var self = this;
            var idea = vmRepository.getIdea(context.id, function (idea) {
                self.idea(idea);
        
            });
            this.ideaToShow.title(self.idea().title);
            this.ideaToShow.image(self.idea().image);
            this.ideaToShow.category(self.idea().category);
            this.ideaToShow.description(self.idea().description);
            this.ideaToShow.goalsList(self.idea().goalsList);
            this.ideaToShow.startDate(self.idea().startDate);
            this.ideaToShow.endDate(self.idea().endDate);
            this.ideaToShow.othersList(self.idea().othersList);
            this.ideaToShow.otherToAdd(self.idea().otherToAdd);
            this.ideaToShow.goalToAdd(self.idea().goalToAdd);
          //  this.ideaToShow = ko.mapping.fromJS(self.idea(), this.ideaToShow)

            var disqus_shortname = 'diyavukrayini';
            var disqus_developer = 1;

            (function () {
                var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
                dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
                (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
            })();
        }
    };

});