(function () {
    function AdditionalField(data) {
        this.fieldName = ko.observable(data.fieldName);
        this.fieldType = ko.observable(data.fieldType);
    }
   

    function LoanRequest(data) {
        this.AdditionalFields = ko.observable(data.additionalFields);
        this.Status = 0;
        this.Amount = ko.observable(data.amount);
        if (data.SubmitDate != undefined)
            this.SubmitDate = data.SubmitDate;
        else this.SubmitDate = '';
        this.LoanTypeId = self.loanTypeId;
        this.User = new User();
    }

    function User() {        
        this.Name = self.customerName;
        this.Email = self.email;
        if (self.userId != undefined)
            this.Id = self.userId;
    }

    function MyLoanTypeViewModel() {
        // Data
        var self = this;
        self.additionalFields = ko.observableArray([]);
        self.myLoanRequests = ko.observableArray([]);
        self.amount = ko.observable();
        self.loanTypesList = ko.observable([]);
        self.loanName = ko.observable();
        self.error = ko.observable();
        self.serverReply = ko.observable();
        self.loanTypeId = ko.observable('');
        self.loanSelected = ko.observable('1');
        self.email = ko.observable('fake'+ Math.floor((Math.random() * 100000) + 1) +'@yopmail.com');
        self.customerName = ko.observable('customer name');
        self.userId = ko.observable();

        self.getLoanType = function () {
            $.getJSON("/LoanTypeAdmin/GetLoanType?loanTypeSelected=" + self.loanSelected(), function (data) {
                self.loanName(data.Name);
                self.loanTypeId(data.Id);
            });
        };

        self.getLoanTypesList = function () {
            $.getJSON("/LoanTypeAdmin/GetLoanTypes", function (data) {
                self.loanTypesList(data);
            });
        };

        self.getLoanTypesList();

        self.getLoanType();

        self.UpdateListRequests = function () {
            $.getJSON("/LoanRequests/ReturnCustomerRequests?email=" + self.email(), function (data) {
                
                self.myLoanRequests.removeAll();                
                $.each(data, function (index,value) {
                    self.myLoanRequests.push(new LoanRequest({ SubmitDate: value.SubmitDate, Amount: value.Amount, Status: value.Status }));
                });
            });
        };

        self.setBriefing = ko.computed(function () {
            return "Application to the Loan \"" + self.loanName()+"\"";
        });

        self.validAmount = ko.computed(function ()
        {
            return this.amount() == undefined || this.amount() == '' || this.amount() == '0';
        });

        self.removeAdditionalField = function (AdditionalField) { self.additionalFields.destroy(AdditionalField) };

        self.save = function () {
            if (this.amount() != undefined && this.amount() != '' && this.amount() != "")
            { 
                var serializedAdditionalFIelds = JSON.stringify(ko.toJSON(this.additionalFields()))
                var lr = new LoanRequest({ additionalFields: serializedAdditionalFIelds, amount:this.amount() });
                debugger;
                $.ajax("/LoanRequests/Create", {
                    data: ko.toJSON(lr),
                    type: "post",
                    contentType: "application/json",
                    success: function (result) {
                        if (result != undefined && result != "") {
                            self.serverReply("Your request has been submitted correctly.");
                            self.error("");
                        }
                        else {
                            self.serverReply("");
                            self.error("An error ocurred submitting the request. Please contact us.");
                        }

                        self.UpdateListRequests();
                    }
                });
            }
        };
    }

    var loanTypeViewModel = MyLoanTypeViewModel();
   
    ko.applyBindings(loanTypeViewModel);

})();
