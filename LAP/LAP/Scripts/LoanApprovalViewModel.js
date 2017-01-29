(function () {
    function Task(data) {
        this.title = ko.observable(data.title);
        this.isDone = ko.observable(data.isDone);
        this.searchByType = ko.observable(data.searchByType);
        this.searchValue = ko.observable(data.searchValue);
        this.controlType = ko.observable(data.controlType);

    }

    function TaskListViewModel() {
        // Data
        var self = this;
        self.tasks = ko.observableArray([]);
        self.newTaskText = ko.observable();
        self.newSearchType = ko.observable();
        self.newSearchValue = ko.observable();
        self.newControlType = ko.observable();
        self.error = ko.observable();
        self.serverReply = ko.observable();
        self.incompleteTasks = ko.computed(function () {
            return ko.utils.arrayFilter(self.tasks(), function (task) { return !task.isDone() && !task._destroy });
        });

        // Operations
        self.addTask = function () {
            self.tasks.push(new Task({ title: this.newTaskText(), searchByType: this.newSearchType(), searchValue: this.newSearchValue(), controlType: this.newControlType() }));
            self.newTaskText("");
            self.newSearchType("");
        };

        self.removeTask = function (task) { self.tasks.destroy(task) };

        $.getJSON("/tasks", function (allData) {
            var mappedTasks = $.map(allData, function (item) { return new Task(item) });
            self.tasks(mappedTasks);
        });

        self.save = function () {
            $.ajax("/tasks", {
                data: ko.toJSON(self.tasks),
                type: "post",
                contentType: "application/json",
                success: function (result) { alert(result) }
            });
        };

        self.saveForLater = function () {
            $.ajax("/tasksSaveForLater", {
                data: ko.toJSON(self.tasks),
                type: "post",
                contentType: "application/json",
                success: function (result) {
                    if (result != undefined && result != "") {
                        self.serverReply("All requests have been updated succesfully.");
                        self.error("");
                    }
                    else {
                        self.serverReply("");
                        self.error("An error ocurred updating the requests. Please contact us.");
                    }
                }
            });

        };


        $.getJSON("/tasksSaveForLater", function (allData) {
            var mappedTasks = $.map(allData, function (item) { return new Task(item) });
            self.tasksList(mappedTasks);
        });

    }

    ko.applyBindings(new TaskListViewModel());

})();
