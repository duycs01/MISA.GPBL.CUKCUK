class InputPaging {
  constructor() {

  }

  listInputPaging = [
    {
      Column: "TypeOfMenu",
      Operator: "=",
      FilterName: ""
    },
    {
      Column: "MenuCode",
      Operator: "LIKE",
      FilterName: ""
    },
    {
      Column: "MenuName",
      Operator: "LIKE",
      FilterName: ""
    },
    {
      Column: "MenuGroupName",
      Operator: "LIKE",
      FilterName: ""
    },
    {

      Column: "UnitName",
      Operator: "LIKE",
      FilterName: ""
    },
    {
      Column: "Price",
      Operator: "<=",
      FilterName: ""
    },
    {
      Column: "ChangeWithTime",
      Operator: "NOT LIKE",
      FilterName: "false"
    },
    {
      Column: "FreePriceAdjustment",
      Operator: "NOT LIKE",
      FilterName: "false"
    },
    {
      Column: "QuantitativeNVL",
      Operator: "NOT LIKE",
      FilterName: "false"
    },
    {
      Column: "NotDisplayed",
      Operator: "NOT LIKE",
      FilterName: "false"
    },
    {
      Column: "StopSale",
      Operator: "NOT LIKE",
      FilterName: "false"
    }
  ]
}

export default new InputPaging()