define(function (require) {

    var moviesRepository = require("repositories/vmRepository");

    return {
       // movies: ko.observable(),

        activate: function () {
            //this.movies(moviesRepository.listMovies());
        }
    };
});