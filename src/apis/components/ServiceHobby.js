import BaseAPI from '../base/BaseAPI'
import baseAPIConfig from "../base/BaseAPIConfig"

class ServiceHobby extends BaseAPI {
    constructor() {
        super()
        this.controller = 'v1/ServiceHobbys'
    }

    /**
  * Hàm lọc và phân trang
  * CreatedBy: duylv 01/09/2021
  */
    getServiceHobbyPaging(filterName, pageSize, currentPage) {
        return baseAPIConfig.get(`${this.controller}/GetServiceHobbyPaging?filterName=${filterName}&pageSize=${pageSize}&pageIndex=${currentPage}`)
    }
}

export default new ServiceHobby()