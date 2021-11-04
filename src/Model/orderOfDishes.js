import Language from "../resources/language/vie";

class OrderOfDishes {
    constructor() {

    }

    listOrderOfDishes = [
        {
            name: Language.OrderOfDishes.Appetizer,
            value: 0
        },
        {
            name: Language.OrderOfDishes.MainDishes,
            value: 1
        },
        {
            name: Language.OrderOfDishes.Desserts,
            value: 2
        }
    ]
}
export default new OrderOfDishes()
