import BaseAPI from '../base/BaseAPI'
import baseAPIConfig from "../base/BaseAPIConfig"

class Menus extends BaseAPI {
    constructor() {
        super()
        this.controller = 'v1/Menus'
    }


    /**
    * Hàm xóa danh sách 
    * CreatedBy: duylv 01/09/2021
    */
    deleteDataByList(deleteList) {
        return baseAPIConfig.post(`${this.controller}/deleteList`, deleteList)
    }

    /**
    * Hàm kiểm tra trùng mã 
    * CreatedBy: duylv 01/09/2021
    */
    checkDuplicateMenuCode(body) {
        return baseAPIConfig.post(`${this.controller}/CheckDuplicateMenuCode`, body)
    }

    /**
    * Hàm lấy mã mới
    * CreatedBy: duylv 01/09/2021
    */
    getNewMenuCode(body) {
        return baseAPIConfig.get(`${this.controller}/GetNewMenuCode?menuName=${body}`)
    }

    /**
    * Hàm lọc và phân trang
    * CreatedBy: duylv 01/09/2021
    */
    getMenuPaging(pageSize, currentPage, body) {
        return baseAPIConfig.post(`${this.controller}/GetMenuPaging?pageSize=${pageSize}&pageIndex=${currentPage}`, body)
    }

    insertMenu(body) {
        return baseAPIConfig.post(`${this.controller}/InsertMenu`, body)
    }

    updateMenu(id, body) {
        return baseAPIConfig.put(`${this.controller}/UpdateMenu/${id}`, body)
    }

    getMenuById(id) {
        return baseAPIConfig.get(`${this.controller}/GetMenuById/${id}`)
    }

    deleteMenu(id) {
        return baseAPIConfig.delete(`${this.controller}/DeleteMenu/${id}`)
    }
}
export default new Menus()