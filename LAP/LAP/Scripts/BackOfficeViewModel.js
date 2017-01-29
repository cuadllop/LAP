(function () {

    function BackOfficeViewModel() {
        // Data

        var self = this;

        self.submit = function () {
            $.ajax("/BackOffice/RunEngineForARequest", {
                data: ko.toJSON(self.myLoanRequests),
                type: "post",
                contentType: "application/json",
                success: function (result) {
                    alert('Applications were updated.')
                }
            });
        };


        self.submit = function () {
            $.getJSON("/BackOffice/RunEngineForAllPendingApps", function (data) { });
        };

        self.submitDeleteAllLoanTYpes = function () {
            $.getJSON("/BackOffice/RemoveAllLoanTypes", function (data) { });
        };       

    }

    var backOfficeViewModel = BackOfficeViewModel();

    ko.applyBindings(backOfficeViewModel);

})();
