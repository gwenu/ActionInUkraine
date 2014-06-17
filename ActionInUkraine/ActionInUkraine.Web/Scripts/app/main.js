require.config({
    paths: {
        'text': 'durandal/amd/text'
    }
});

define(function (require) {
    var app = require('durandal/app'),
        viewLocator = require('durandal/viewLocator'),
        system = require('durandal/system'),
        router = require('durandal/plugins/router'),
        viewEngine = require('durandal/viewEngine');

    //>>excludeStart("build", true);
    system.debug(true);
    viewEngine.viewExtension = " ";
    viewLocator.useConvention('viewmodels', '../../../durandal');
    //>>excludeEnd("build");

    app.start().then(function () {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        //viewLocator.useConvention();
        //viewEngine.viewPlugin = 'durandal/amd/text';

        //configure routing
        router.map([{ url: 'home', moduleId: 'viewmodels/home', name: 'Home', visible: true },
                    { url: 'possibilities', moduleId: 'viewmodels/menu/possibilities', name: 'Можливості', visible: true},
                    { url: 'community', moduleId: 'viewmodels/menu/community', name: 'Спільнота', visible: true},
                    { url: 'news', moduleId: 'viewmodels/news/list', name: 'Новини', visible: true },
                    { url: 'forum', moduleId: 'viewmodels/menu/forum', name: 'Форум', visible: true},
                    { url: 'ideas/all', moduleId: 'viewmodels/ideas/list', name: 'Всі ідеї', visible: true },
                    { url: 'ideas/new', moduleId: 'viewmodels/ideas/new', name: 'Нові ідеї', visible: true },
                    { url: 'ideas/best', moduleId: 'viewmodels/ideas/best', name: 'Найкращі ідеї місяця', visible: true }]);
                    //{ url: 'registration', moduleId: 'viewmodels/profile/registration', name: 'Зареєструватися', visible: true }]);
        app.adaptToDevice();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});

