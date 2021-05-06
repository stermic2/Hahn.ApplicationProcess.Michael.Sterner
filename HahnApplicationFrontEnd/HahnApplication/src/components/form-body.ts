import {nameWrapper} from "../resources/elements/nameWrapper";
export class FormBody {
  private form: any;
  constructor() {
    const Http = new XMLHttpRequest();
    const url='https://restcountries.eu/rest/v2/all?fields=name';
    Http.open("GET", url);
    Http.send();
    Http.onreadystatechange = (e) => {
      this.form = {
        countries: Http.responseText,
        "components": [
          {
            label: "Name Of Asset",
            type: "textfield",
            input: true,
            key: "AssetName",
            validate: {
              minLength: 4,
              maxLength: null,
              required: true
            }
          },
          {
            label: "Department",
            type: "select",
            input: true,
            key: "Department",
            validate: {
              required: true,
            },
            data: {
              values: {
                0: {
                  label: "HQ",
                  value: 0 as number
                },
                1: {
                  label: "Store 1",
                  value: 1 as number
                },
                2: {
                  label: "Store 2",
                  value: 2 as number
                },
                3: {
                  label: "Store 3",
                  value: 3 as number
                },
                4: {
                  label: "Maintenance Station",
                  value: 4 as number
                }
              }
            },
            valueProperty: "value",
          },
          {
            label: "Country Of Department",
            type: "textfield",
            input: true,
            key: "CountryOfDepartment",
            validate: {
              custom: "valid = (form.countries.includes(input)) ? true : 'Invalid Country';",
            },
          },
          {
            label: "Purchase Date",
            type: "datetime",
            input: true,
            key: "PurchaseDate",
            suffix: true,
            format: "yyyy-MM-ddTHH:mm a",
            datePicker: {
              yearRows: "4",
              yearColumns: "5",
              minDate: "moment().subtract(1, 'years')",
              maxDate: ""
            }
          },
          {
            label: "Email Address of Department",
            type: "email",
            input: true,
            key: "EMailAddressOfDepartment"
          },
          {
            label: "Broken",
            type: "checkbox",
            input: true,
            key: "Broken"
          },
          {
            label: "Submit",
            action: "url",
            theme: "primary",
            disableOnInvalid: true,
            type: "button",
            key: "submit",
            input: true,
            url: "https://localhost:5001/api/v1/assets",
            headers: [
              {
                "header": "Content-Type",
                "value": "application/json"
              }
            ]
          },
          {
            label: "Reset",
            action: "reset",
            type: "button",
            input: true,
            key: "reset",
          }
        ],
        display: "form"
      };
    }
  }

}
