define(function (require) {

    return {
        listIdeas: function (callback) {
            $.ajax({
                url: '/api/ideas/',
                dataType: 'json',
                async: false, // it does not work sometimes when TRUE
                success: function (ideas) {
                    callback(ideas);
                },
                error: function () {
                    alert("something went wrong");
                }
            });
            //$.getJSON('/api/ideas', function (ideas) {
            //    callback(ideas);
            //})
            //.fail(function () {
            //    alert("error");
            //});
        },
        addIdea: function (ideaToAdd) {
            $.post('api/ideas', ideaToAdd, function () {
                alert("sent!");

                })
                .fail(function () {
                    alert("error");
                });
              },
        getIdea: function (id, callback) {
            $.ajax({
                url: '/api/ideas/' + id,
                dataType: 'json',
                async: false,
                success: function (idea) {
                    callback(idea);
                },
                error: function () {
                    alert("something went wrong");
                }
            });
        },
        listNews: function (callback) {
            $.ajax({
                url: '/api/news/',
                dataType: 'json',
                async: false, // it does not work sometimes when TRUE
                success: function (ideas) {
                    callback(ideas);
                },
                error: function () {
                    alert("something went wrong");
                }
            });
        }
    };
});