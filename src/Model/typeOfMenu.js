
import Language from "../resources/language/vie";

class TypeOfMenu {
    constructor() {

    }

    listTypeOfMenu = [
        {
            name: Language.TypeOfMenu.Food,
            value: 0
        },
        {
            name: Language.TypeOfMenu.Drink,
            value: 1
        },
        {
            name: Language.TypeOfMenu.Combo,
            value: 2
        },
        {
            name: Language.TypeOfMenu.Different,
            value: 3
        }
    ]
}
export default new TypeOfMenu()
