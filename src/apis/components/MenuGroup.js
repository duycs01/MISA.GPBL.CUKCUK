import BaseAPI from '../base/BaseAPI'
import baseAPIConfig from "../base/BaseAPIConfig"

class MenuGroup extends BaseAPI {
    constructor() {
        super()
        this.controller = 'v1/MenuGroups'
    }
}

export default new MenuGroup()