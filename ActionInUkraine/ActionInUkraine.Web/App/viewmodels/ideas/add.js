define(['repositories/vmRepository', 'durandal/app', 'durandal/plugins/router'], function (vmRepository, app, router) {

    var vm = {
        ideaToAdd: ko.validatedObservable({
            id: ko.observable(0),
            title: ko.observable().extend({ required: true, minLength: 4 }),
            image: ko.observable(""),
            category: ko.observable().extend({ required: true }),
            description: ko.observable(),
            socialNetworks: ko.observableArray(),
            team: ko.observableArray(),
            goals: ko.observable(),
            needPeople: ko.observable(false),
            people: ko.observable(""),
            needMoney: ko.observable(false),
            money: ko.observable(""),
            needFeedback: ko.observable(false),
            needAdvert: ko.observable(false),
            needSmthElse: ko.observable(false),
            smthElse: ko.observable(""),

            // budget: ko.observableArray([{ name: "", price: 0 }]),
            alreadyIs: ko.observable(),
            //  events: ko.observableArray([{ event: "", date: "" }]),
            // service property
            socialNetworkItem: ko.observable(""),
            user: ko.observable(""),
        }),

        //budget: function(name, price){
        //    this.name = ko.observable(name);
        //    this.price = ko.observable(price);
        //},

        categories: ko.observable(),

        activate: function () {
            vm.loadCategories();
        },
        loadCategories: function () {
            //top.flow('list');
            $.getJSON('/api/categories', function (data) {
                vm.categories(data);
            })
            .fail(function () {
                alert("error");
            });
        },

        removeBudgetItem: function (data) {
            this.budget.remove(data);
        },
        removeEventItem: function (data) {
            this.events.remove(data);
        },
        addSocialNetwork: function () {
            if (this.socialNetworks.indexOf(this.socialNetworkItem()) < 0) {
                var item = this.socialNetworkItem();
                this.socialNetworks.push(item);
                this.socialNetworkItem("");
            }
            else
                $('#addSocialNetwork').prop("disabled", true);
        },
        addUser: function () {
            var userIndex = this.team.indexOf(this.user());

            if (userIndex < 0) {
                var item = this.user();
                this.team.push(item);
                this.user("");
                $('#addUser').prop("disabled", true);
            }
            else
                $('#addUser').prop("disabled", true);
        },
        removeSocialNetwork: function (data) {
            this.socialNetworks.remove(data);
        },
        removeUser: function (data) {
            this.team.remove(data);
        },
        addBudgetItem: function () {
            this.budget.push({
                name: "",
                price: 0
            });
        },
        addEventItem: function () {
            this.events.push({
                event: "",
                date: ""
            });
        },
        onUpload: function () {
            var files = $("#file1").get(0).files;
            if (files.length > 0) {
                if (window.FormData !== undefined) {
                    var data = new FormData();
                    for (i = 0; i < files.length; i++) {
                        data.append("file" + i, files[i]);
                    }
                    $.ajax({
                        type: "POST",
                        url: "/api/fileupload",
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (results) {
                            var str = results[0];
                            vm.ideaToAdd().image(str);
                            $('#blah').attr('src', "/uploads/" + str).css({ width: 100, height: 100 })
  .show();;

                            //$('#uploadImageBtn').prop("disabled", true);
                            //uploadImageBtn
                        }
                    });
                } else {
                    alert("This browser doesn't support HTML5 multiple file uploads!");
                }
            }
        },
        addIdea: function () {
            if (vm.ideaToAdd().isValid()) {
                var idea = ko.toJS(vm.ideaToAdd());
                $.post('api/ideas', idea, function () {
                })
                .fail(function () {
                    alert("error");
                });
                router.navigateTo("#/ideas/list");
            }
            else { alert("Fill in the form!!!"); }
        },
        viewAttached: function () {
            $("#file1").change(function () {
                vm.onUpload();
            });
            $('#addUser').prop("disabled", true);
            $('#search').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: 'api/users',
                        data: { query: request.term },
                        dataType: 'json',
                        type: 'GET',
                        success: function (data) {
                            // No matching result
                            if (data.length == 0) {
                                //alert('No entries found!');
                                $("#search").autocomplete("close");
                                $('#addUser').prop("disabled", true);
                            }
                            else {

                                response($.map(data, function (item) {
                                    return {
                                        label: item.firstName + " " + item.secondName,
                                        //value: item.id
                                    }
                                }));
                            }
                        }
                    })
                },
                select: function (event, ui) {
                    //eventuallydosomething(ui.item.value);
                    //$("#search").autocomplete("close");

                    $('#search').val(ui.item.label);
                    $('#addUser').prop("disabled", false);
                    //$('#Id').val(ui.item.value);
                    return false;
                },
                minLength: 2
            });


            $(".datepicker").datepicker({
                changeMonth: false,
                changeYear: false,
                showAnim: "fadeIn",
                gotoCurrent: true,
                minDate: 0,
                dateFormat: "m/d/yy"
            });
            //submit on enter for list
            //$("#socialNetworkItem").keypress(function (e) {
            //    if (e.which == 13) {
            //        $("#addSocialNetwork").click();
            //    }
            //});
            //$("#search").keypress(function (e) {
            //    if (e.which == 13) {
            //        $("#addUser").click();
            //    }
            //});
        }
    }
    return vm;
});

