import BaseAPI from '../base/BaseAPI'
import baseAPIConfig from "../base/BaseAPIConfig"

class Unit extends BaseAPI {
    constructor() {
        super()
        this.controller = 'v1/Units'
    }
}

export default new Unit()