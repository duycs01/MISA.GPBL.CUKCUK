import Language from "../resources/language/vie";

class FormatData {
    constructor() { }

    /**
     * Định dạng loại thực đơn
     * CreatedBy: duylv - 30/9/2021
     */
    formatTypeOfMenu(value) {
        switch (value) {
            case 0:
                return Language.TypeOfMenu.Food
            case 1:
                return Language.TypeOfMenu.Drink
            case 2:
                return Language.TypeOfMenu.Combo
            default:
                return Language.TypeOfMenu.Different
        }
    }

    /**
      * Định dạng định lượng
      * CreatedBy: duylv - 02/10/2021
      */
    formatQuantitativeNVL(value) {
        switch (value) {
            case true:
                return Language.Filter.Setup
            default:
                return Language.Filter.NoSetup
        }
    }

    /**
       * Định dạng loại thực đơn
       * CreatedBy: duylv - 02/10/2021
       */
    formatOrderOfDishes(value) {
        switch (value) {
            case 0:
                return Language.OrderOfDishes.Appetizer
            case 1:
                return Language.OrderOfDishes.MainDishes
            default:
                return Language.OrderOfDishes.Desserts
        }
    }


    /**
     * Định dạng tiền thành dấu chấm
     * CreatedBy: duylv - 30/9/2021
     */
    formatMoney(value) {
        return `${value}`.replace(/\./, ',').replace(/\B(?=(\d{3})+(?!\d))/g, '.')
    }

    /**
     * Định dạng tiền thành số
     * CreatedBy: duylv - 30/9/2021
     */
    parseMoney(value) {
        return `${value}`.replace(/,/, '#').replace(/\./g, '').replace(/#/, '.')
    }
}
export default new FormatData()