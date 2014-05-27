define(function (require) {
    var router = require('durandal/plugins/router');

    return {
        router: router,
        homeRoute: router.visibleRoutes[0],
        hederMenu: router.visibleRoutes.slice(1, 5),
        ideaMenu: router.visibleRoutes.slice(5, 8),
        actions: router.visibleRoutes.splice(8),
        navigateToHome: function() {
            router.navigateTo('#/home');
        },
        activate: function () {
            return router.activate('home');
        }
    };
});