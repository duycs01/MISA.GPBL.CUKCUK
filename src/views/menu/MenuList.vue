<template>
  <div class="menu">
    <div class="menu-title">{{language.Menu}}</div>
    <div class="table-view">
      <div class="toolbar">
        <button @click="btnAdd" class="button">
          <span class="icon-button icon-add"></span>
          <span class="text">{{language.Button.Add}}</span>
        </button>
        <button :disabled="listMenu.length == 0?true:false" @click="btnDuplicate" class="button">
          <span class="icon-button icon-edit"></span>
          <span class="text">{{language.Button.Duplicate}}</span>
        </button>
        <button :disabled="listMenu.length == 0?true:false" @click="btnEdit(menuId)" class="button">
          <span class="icon-button icon-duplicate"></span>
          <span class="text">{{language.Button.Edit}}</span>
        </button>
        <button :disabled="listMenu.length == 0?true:false" @click="btnDelete" class="button">
          <span class="icon-button icon-delete"></span>
          <span class="text">{{language.Button.Delete}}</span>
        </button>
        <button @click="btnRefresh" class="button">
          <span class="icon-button icon-refresh"></span>
          <span class="text">{{language.Button.Refresh}}</span>
        </button>
      </div>
      <menu-table
        :listMenu="listMenu"
        @btnEdit="btnEdit"
        @selectRow="selectRow"
        :menuId="menuId"
        :listFilter="listInputPaging"
        @onChangeFilter="onChangeFilter"
        :isLoading="isLoading"
      />
      <base-paging
        :totalPage="totalPage"
        :totalRecord="totalRecord"
        :current-page="currentPage"
        :pageSize="pageSize"
        @pagechanged="loadData"
        @btnRefresh="btnRefresh"
      ></base-paging>
    </div>
    <menu-detail
      :formMode="formMode"
      v-if="openMenuDetail"
      :formData="formDataMenuDetail"
      @saveFormMenuDetail="saveForm"
      @btnCloseMenuDetail="btnCloseMenuDetail"
      @btnRefresh="btnRefresh"
    ></menu-detail>
    <base-popup v-if="openPopupDelete" :popupDetail="popupDetail">
      <template #buttonRight>
        <button @click="deleteDataById" class="button button-popup" style="margin:2px">
          <span class="text">{{$Language.Button.Yes}}</span>
        </button>
        <button @click="btnClosePopupDelete" class="button button-popup" style="margin:2px">
          <span class="text">{{$Language.Button.No}}</span>
        </button>
      </template>
    </base-popup>
    <transition name="slide-fade">
      <base-toast-mess v-if="openToastMess" :messageDetail="messageDetail" />
    </transition>
  </div>
</template>
<script>
import MenuTable from "../../components/page/menu/MenuTable.vue";
import BasePaging from "../../components/base/BasePaging.vue";
import MenuDetail from "./MenuDetail.vue";
import InputPaging from "../../Model/inputPaging";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseToastMess from "../../components/base/BaseToastMess.vue";

export default {
  components: { MenuTable, BasePaging, MenuDetail, BasePopup, BaseToastMess },
  mounted() {
    this.listInputPaging = JSON.parse(
      JSON.stringify(InputPaging.listInputPaging)
    );
    this.getMenuPaging();
    this.getAllUnit();
    this.getAllMenuGroup();
    this.getAllProcessing();
    this.getAllServiceHobby();
  },
  data() {
    return {
      language: this.$Language,
      totalPage: 10,
      currentPage: 1,
      pageSize: 25,
      totalRecord: 100,
      openMenuDetail: false,
      formMode: "",
      formDataMenuDetail: { ...this.$MenuModel.MenuDetail },
      listInputPaging: JSON.parse(JSON.stringify(InputPaging.listInputPaging)),

      listMenu: [],
      menuId: "",
      popupDetail: { icon: "icon-warning", mess: "Mã trùng" },
      openPopupDelete: false,
      isLoading: false,
      messageDetail: { icon: "icon-success", mess: "Thông báo" },
      openToastMess: false
    };
  },
  methods: {
    /**
     * Lấy danh sách menu và phân trang
     * CreatedBy: duylv - 01/10/2021
     */
    async getMenuPaging() {
      this.isLoading = true;
      await this.$MenuApi
        .getMenuPaging(this.pageSize, this.currentPage, this.listInputPaging)
        .then(res => {
          this.listMenu = res.data.Data.Data;
          this.totalPage = res.data.Data.TotalPage;
          this.totalRecord = res.data.Data.TotalRecord;
          if (this.listMenu.length > 0) {
            this.menuId = this.listMenu[0].MenuId;
            this.formDataMenuDetail = this.listMenu[0];
          }
          this.isLoading = false;
        })
        .catch(error => {
          this.isLoading = false;
          console.log(error);
        });
    },

    /**
     * Lấy danh sách unit
     * CreatedBy: duylv - 01/10/2021
     */
    async getAllUnit() {
      var me = this;
      await this.$UnitApi
        .getAllData()
        .then(res => {
          me.$UnitModel.listUnit = res.data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Lấy danh sách MenuGroup
     * CreatedBy: duylv - 01/10/2021
     */
    async getAllMenuGroup() {
      var me = this;
      await this.$MenuGroupApi
        .getAllData()
        .then(res => {
          me.$MenuGroupModel.listMenuGroup = res.data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Lấy danh sách ServiceHobby
     * CreatedBy: duylv - 01/10/2021
     */
    async getAllServiceHobby() {
      var me = this;
      await this.$ServiceHobbyApi
        .getAllData()
        .then(res => {
          me.$ServiceHobbyModel.listServiceHobby = res.data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Lấy danh sách unit
     * CreatedBy: duylv - 01/10/2021
     */
    async getAllProcessing() {
      var me = this;
      await this.$ProcessingApi
        .getAllData()
        .then(res => {
          me.$ProcessingModel.listProcessing = res.data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Lấy menu theo id
     * CreatedBy: duylv - 01/10/2021
     */
    async getMenuById(id) {
      await this.$MenuApi
        .getDataById(id)
        .then(res => {
          this.formDataMenuDetail = res.data.Data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Gọi api lấy mã mới
     * CreatedBy: duylv - 03/10/2021
     */
    async getNewMenuCode() {
      await this.$MenuApi
        .getNewMenuCode(this.formDataMenuDetail.MenuName)
        .then(res => {
          this.formDataMenuDetail.MenuCode = res.data.Data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Sự kiện thay đổi filter
     * CreatedBy: duylv - 10/10/2021
     */
    onChangeFilter(filter) {
      this.currentPage = 1;
      this.listInputPaging = filter;
      this.getMenuPaging();
    },

    /**
     * Sử lí phân trang
     * CreatedBy: duylv - 30/9/2021
     */
    loadData(page) {
      this.currentPage = page.pageIndex;
      this.pageSize = page.pageSize;
      this.getMenuPaging();
    },

    /**
     * Hàm sử lí nút thêm
     * CreatedBy: duylv - 30/9/2021
     */
    btnAdd() {
      this.formMode = this.$Enum.FormMode.Add;
      this.formDataMenuDetail = { ...this.$MenuModel.MenuDetailDefault };
      this.openMenuDetail = true;
    },

    /**
     * Hàm sử lí nút nhân bản
     * CreatedBy: duylv - 30/9/2021
     */
    async btnDuplicate() {
      try {
        await this.getMenuById(this.menuId);
        this.formMode = this.$Enum.FormMode.Add;
        this.formDataMenuDetail.MenuId = this.$MenuModel.MenuDetailDefault.MenuId;
        await this.getNewMenuCode();
        this.openMenuDetail = true;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí nút sửa
     * CreatedBy: duylv - 30/9/2021
     */
    async btnEdit(id) {
      try {
        await this.getMenuById(id);
        this.formMode = this.$Enum.FormMode.Edit;
        this.openMenuDetail = true;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí nút xóa
     * CreatedBy: duylv - 30/9/2021
     */
    btnDelete() {
      this.popupDetail.icon = this.$Enum.IconPopup.Question;
      this.popupDetail.mess = this.$Language.ValidateMessage.Delete.replace(
        "{0} - {1}",
        `${this.formDataMenuDetail.MenuCode} - ${this.formDataMenuDetail.MenuName}`
      );
      this.openPopupDelete = true;
    },

    /**
     * Hàm sử lí đóng popup xóa
     * CreatedBy: duylv - 30/9/2021
     */
    btnClosePopupDelete() {
      this.openPopupDelete = false;
    },

    /**
     * Hàm sử lí xóa dữ liệu
     * CreatedBy: duylv - 30/9/2021
     */
    async deleteDataById() {
      await this.$MenuApi
        .deleteDataById(this.menuId)
        .then(res => {
          this.messageDetail = this.$ValidateData.checkStatusApi(res.data);
          this.btnToastMess();
          this.btnClosePopupDelete();
          this.btnRefresh();
        })
        .catch(error => {
          console.log(error);
          this.messageDetail = this.$ValidateData.checkStatusApi(
            error.response
          );
          this.btnToastMess();
        });
    },

    /**
     * Mở thông báo
     * CreatedBy: duylv - 12/10/2021
     */
    btnToastMess() {
      this.openToastMess = true;
      setTimeout(() => {
        this.openToastMess = false;
      }, 3000);
    },

    /**
     * Hàm sử lí nút refresh
     * CreatedBy: duylv - 30/9/2021
     */
    btnRefresh() {
      try {
        this.listInputPaging = JSON.parse(
          JSON.stringify(InputPaging.listInputPaging)
        );
        this.currentPage = 1;
        this.pageSize = 25;
        this.getMenuPaging();
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí nút đóng form
     * CreatedBy: duylv - 30/9/2021
     */
    btnCloseMenuDetail() {
      this.openMenuDetail = false;
    },

    /**
     * Hàm sử lí chọn hàng
     * CreatedBy: duylv - 01/10/2021
     */
    selectRow(item) {
      this.formDataMenuDetail = item;
      this.menuId = item.MenuId;
    },

    /**
     * Hàm sử lí cất dữ liệu
     * CreatedBy: duylv - 30/9/2021
     */
    async saveForm(formDetail) {
      if (formDetail.formMode == this.$Enum.FormMode.Add) {
        await this.$MenuApi
          .insertData(formDetail.formData)
          .then(res => {
            this.messageDetail = this.$ValidateData.checkStatusApi(res.data);
            this.btnToastMess();
            this.btnRefresh();
          })
          .catch(error => {
            console.log(error);
            this.messageDetail = this.$ValidateData.checkStatusApi(
              error.response
            );
            this.btnToastMess();
          });
      }
      if (formDetail.formMode == this.$Enum.FormMode.Edit) {
        await this.$MenuApi
          .updateDataById(formDetail.formData.MenuId, formDetail.formData)
          .then(res => {
            this.messageDetail = this.$ValidateData.checkStatusApi(res.data);
            this.btnToastMess();
            this.btnRefresh();
          })
          .catch(error => {
            console.log(error);
            this.messageDetail = this.$ValidateData.checkStatusApi(
              error.response
            );
            this.btnToastMess();
          });
      }
    }
  }
};
</script>
<style scoped>
@import url('../../assets/css/page/menu.css');
</style>