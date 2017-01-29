(function () {
    function AdditionalField(data) {
        this.fieldName = ko.observable(data.fieldName);
        this.fieldType = ko.observable(data.fieldType);
    }

    function LoanType(data) {
        this.Name = ko.observable(data.fieldName);
        this.AdditionalFields = ko.observable(data.additionalFields);
    }

    function LoanTypeViewModel() {
        // Data
        var self = this;
        self.additionalFields = ko.observableArray([]);
        self.fieldType = ko.observable();
        self.newFieldName = ko.observable();
        self.newFieldType = ko.observable();
        self.loanName = ko.observable();
        self.loanName = ko.observable();
        self.error = ko.observable();
        self.serverReply = ko.observable();
        self.LoanType = ko.observable();

        // Operations
        self.addAdditionalField = function () {
            self.additionalFields.push(new AdditionalField({ fieldName: this.newFieldName(), fieldType: this.newFieldType()}));
            self.newFieldName("");
            self.newFieldType("");
        };

        self.removeAdditionalField = function (AdditionalField) { self.additionalFields.destroy(AdditionalField) };

        $.getJSON("/LoanTypeAdmin/Create", function (allData) {
            var mappedAdditionalFields = $.map(allData, function (item) { return new AdditionalField(item) });
            self.additionalFields(mappedAdditionalFields);
        });

        self.save = function () {

            var serializedAdditionalFIelds = JSON.stringify(ko.toJSON(this.additionalFields()))
            var lt = new LoanType({ fieldName: this.loanName(), additionalFields: serializedAdditionalFIelds });
            debugger;
            $.ajax("/LoanTypeAdmin/Create", {
                data: ko.toJSON(lt),
                type: "post",
                contentType: "application/json",
                success: function (result) {
                    debugger;
                    if (result != undefined && result != "")
                    {
                        self.loanName("");
                        self.serverReply("The loan type was saved correctly");
                        self.error("");
                    }
                    else
                    {
                        self.serverReply("");
                        self.error("An error ocurred saving the element");
                    }
                }                
            });
        };
    }

    ko.applyBindings(new LoanTypeViewModel());

})();
