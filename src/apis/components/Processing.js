import BaseAPI from '../base/BaseAPI'
import baseAPIConfig from "../base/BaseAPIConfig"

class Processing extends BaseAPI {
    constructor() {
        super()
        this.controller = 'v1/Processings'
    }
}

export default new Processing()