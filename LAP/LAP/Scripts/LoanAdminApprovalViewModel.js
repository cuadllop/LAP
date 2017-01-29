(function () {

    function LoanRequest(data) {
        this.Status = data.Status;
        this.Amount = data.Amount;
        this.SubmitDate = data.SubmitDate;
        this.Id = data.Id;
    }

    function MyLoanTypeViewModel() {
        // Data

        var self = this;
        self.additionalFields = ko.observableArray([]);
        self.amount = ko.observable();
        self.myLoanRequests = ko.observableArray([]);
        self.loanName = ko.observable();
        self.loanTypeId = ko.observable('');
        self.loanSelected = ko.observable();
        self.customerName = ko.observable('customer name');
        self.userId = ko.observable(); 
        self.error = ko.observable();
        self.serverReply = ko.observable();
        self.getLoanType = function () {
            $.getJSON("/LoanAdminApproval/GetPendingApprovalRequests", function (data) {
                self.myLoanRequests.removeAll();
                $.each(data, function (index, value) {
                    self.myLoanRequests.push(new LoanRequest({ SubmitDate: value.SubmitDate, Amount: value.Amount, Status: value.Status,Id:value.Id }));
                });
            });
        };

        self.save = function () {            
            $.ajax("/LoanAdminApproval/UpdateApprovalProcess", {
                data: ko.toJSON(self.myLoanRequests),
                type: "post",
                contentType: "application/json",
                success: function (result) {
                    self.myLoanRequests.removeAll();
                    if (result != undefined && result != "") {
                        self.serverReply("All requests have been updated succesfully.");
                        self.error("");
                        self.getLoanType();
                    }
                    else {
                        self.serverReply("");
                        self.error("An error ocurred updating the requests. Please contact us.");
                    }

                }
            });
        };

        self.getLoanType();

    }

    var loanTypeViewModel = MyLoanTypeViewModel();

    ko.applyBindings(loanTypeViewModel);

})();
