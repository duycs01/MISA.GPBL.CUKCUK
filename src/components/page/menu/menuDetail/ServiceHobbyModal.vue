<template>
  <div class="modal modal-choose-service">
    <div class="modal-box">
      <div class="modal-header">
        <div class="modal-title">{{$Language.TitleModal.ChooseServicePreferences}}</div>
        <button @click="btnCloseServiceHobbyModal" class="btn-close-form">
          <span class="icon-tool icon-button-close"></span>
        </button>
      </div>
      <div class="modal-toolbar">
        <a-input
          v-model:value="filterName"
          size="small"
          class="textbox"
          style="width:84%;"
          placeholder="Nhập sở thích cần tìm"
          @blur="btnSearch"
          @keyup.enter="btnSearch"
        />
        <button @click="btnSearch" class="button button-select-menu">
          <span class="icon-tool icon-search"></span>
          <span class="text">{{$Language.Button.Search}}</span>
        </button>
      </div>
      <div class="modal-content">
        <div class="table-view">
          <service-hobby-table
            :listServiceHobbyPaging="listServiceHobbyPaging"
            :listServiceHobbyTable="listChooseServiceHobby"
            @btnChooseServiceHobby="btnChooseServiceHobby"
          />
          <base-paging
            :totalPage="totalPage"
            :totalRecord="totalRecord"
            :current-page="currentPage"
            :pageSize="pageSize"
            @pagechanged="loadData"
            @btnRefresh="btnRefresh"
          />
        </div>
      </div>
      <div class="modal-footer">
        <div></div>
        <div class="action">
          <button @click="btnAddServiceHobbyDetail" class="button button-select-menu">
            <span class="icon-tool icon-add-blue"></span>
            <span class="text">{{$Language.Button.Add}}...</span>
          </button>
          <button @click="btnChooseServiceHobbyModal" class="button button-select-menu">
            <span class="icon-tool icon-choose"></span>
            <span class="text">{{$Language.Button.Choose}}</span>
          </button>
          <button @click="btnCloseServiceHobbyModal" class="button button-select-menu">
            <span class="icon-tool icon-disable"></span>
            <span class="text">{{$Language.Button.Cancel}}</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import BasePaging from "../../../base/BasePaging.vue";
import ServiceHobbyTable from "./ServiceHobbyTable.vue";
import InputPaging from "../../../../Model/inputPaging";
import ServiceHobbyDetail from "./ServiceHobbyDetail.vue";

export default {
  props: {
    listServiceHobbyModal: {
      type: Array,
      default: () => []
    }
  },
  components: {
    VNodes: {
      functional: true,
      render: (h, ctx) => ctx.props.vnodes
    },
    ServiceHobbyTable,
    BasePaging,
    ServiceHobbyDetail
  },
  mounted() {
    this.getServiceHobbyPaging();
    this.listChooseServiceHobby = JSON.parse(
      JSON.stringify(this.listServiceHobbyModal)
    );
  },
  data() {
    return {
      tab: 1,
      totalPage: 10,
      currentPage: 1,
      pageSize: 25,
      totalRecord: 100,
      inputPaging: { ...InputPaging },
      filterName: "",
      listServiceHobbyPaging: [],
      listChooseServiceHobby: []
    };
  },
  methods: {
    /**
     * Tìm kiếm compobox
     * CreatedBy: duylv - 01/10/2021
     */
    filterOption(input, option) {
      return (
        option.children[0].children
          .toLowerCase()
          .indexOf(input.toLowerCase()) >= 0
      );
    },

    /**
     * Lấy danh sách data
     * CreatedBy: duylv - 01/10/2021
     */
    async getServiceHobbyPaging() {
      await this.$ServiceHobbyApi
        .getServiceHobbyPaging(this.filterName, this.pageSize, this.currentPage)
        .then(res => {
          this.listServiceHobbyPaging = res.data.Data.Data;
          this.totalPage = res.data.Data.TotalPage;
          this.totalRecord = res.data.Data.TotalRecord;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Lấy danh sách data khi phân trang thay đổi
     * CreatedBy: duylv - 01/10/2021
     */
    loadData(page) {
      this.currentPage = page.pageIndex;
      this.pageSize = page.pageSize;
      this.getServiceHobbyPaging();
    },

    /**
     * Hàm sử lí nút tìmm kiếm
     * CreatedBy: duylv - 01/10/2021
     */
    btnSearch() {
      this.currentPage = 1;
      this.getServiceHobbyPaging();
    },

    /**
     * Hàm sử lí nút refresh
     * CreatedBy: duylv - 30/9/2021
     */
    btnRefresh() {
      this.filterName = "";
      this.currentPage = 1;
      this.pageSize = 25;
      this.getServiceHobbyPaging();
    },

    /**
     * Hàm sử lí đóng Modal sở thích phục vụ
     * CreatedBy: duylv - 27/9/2021
     */
    btnCloseServiceHobbyModal() {
      this.$emit("btnCloseServiceHobbyModal");
    },

    /**
     * Sự kiện nút chọn
     * CreatedBy: duylv - 10/10/2021
     */
    btnChooseServiceHobbyModal() {
      this.$emit("btnChooseServiceHobbyModal", this.listChooseServiceHobby);
      this.$emit("btnCloseServiceHobbyModal");
    },

    /**
     * SƯ kiện nhận emit từ table
     * CreatedBy: duylv - 10/10/2021
     */
    btnChooseServiceHobby(value) {
      this.listChooseServiceHobby = value;
    },

    /**
     * Thêm dịch vụ yêu thích
     * CreatedBy: duylv - 10/10/2021
     */
    btnAddServiceHobbyDetail() {
      this.$emit("btnAddServiceHobbyDetail");
    }
  }
};
</script>
<style scoped>
@import url("../../../../assets/css/base/modal.css");

@import url("../../../../assets/css/page/menuDetail.css");
@import url("../../../../assets/css/base/table.css");
</style>