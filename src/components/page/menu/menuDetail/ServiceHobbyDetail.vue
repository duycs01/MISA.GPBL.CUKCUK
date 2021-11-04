<template>
  <div class="modal modal-service-hobby">
    <div class="modal-box">
      <div class="modal-header">
        <div class="modal-title">{{$Language.TitleModal.AddServicePreferences}}</div>
        <button @click="btnCloseServiceHobbyDetail" class="btn-close-form">
          <span class="icon-tool icon-button-close"></span>
        </button>
      </div>

      <div class="modal-content">
        <div class="input-form" ref="serviceHobbyNameParent">
          <div class="label">
            {{$Language.MenuDetail.ServiceHobby}}
            <span class="required">(*)</span>
          </div>
          <div class="input">
            <div class="validate">
              <a-textarea
                @focus="removeMessError"
                @blur="validate(serviceHobbyDetail.ServiceHobbyName)"
                class="textbox"
                v-model:value="serviceHobbyDetail.ServiceHobbyName"
                :auto-size="{ minRows: 2, maxRows: 2 }"
              />
              <span class="icon-error"></span>
            </div>
            <div class="error-mess">Trường này không được để trống</div>
          </div>
        </div>
        <div class="input-form">
          <div class="label">{{$Language.MenuDetail.CollectMore}}</div>
          <div class="input">
            <a-input-number
              v-model:value="serviceHobbyDetail.CollectMore"
              defaultValue="0"
              class="price"
              size="small"
              :formatter="value => $FormatData.formatMoney(value)"
              :parser="x => $FormatData.parseMoney(x)"
              :controls="false"
            />
          </div>
        </div>
        <div class="input-form">
          <div class="label">{{$Language.MenuDetail.ServiceHobbyGroup}}</div>

          <div class="input" style="display:flex;">
            <a-select
              v-model:value="serviceHobbyDetail.ParentId"
              :size="`small`"
              show-search
              :filter-option="filterOption"
              :dropdownMatchSelectWidth="false"
              class="textbox"
            >
              <a-select-option
                v-for="(item,index) in listServiceHobby"
                :key="index"
                :value="item.ServiceHobbyId"
                :label="item.ServiceHobbyId"
              >{{item.ServiceHobbyName}}</a-select-option>
            </a-select>
            <button class="button">
              <span class="icon-tool icon-add-blue"></span>
            </button>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <div class="help">
          <button class="button button-select-menu">
            <span class="icon-button icon-help"></span>
            <span class="text">{{$Language.Button.Help}}</span>
          </button>
        </div>
        <div class="action">
          <button @click="btnSave" class="button button-select-menu">
            <span class="icon-tool icon-save"></span>
            <span class="text">{{$Language.Button.Save}}</span>
          </button>
          <button @click="btnCloseServiceHobbyDetail" class="button button-select-menu">
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
export default {
  components: {
    ServiceHobbyTable,
    BasePaging
  },
  mounted() {
    this.listServiceHobby = this.$ServiceHobbyModel.listServiceHobby;
    this.serviceHobbyDetail = { ...this.$ServiceHobbyModel.ServiceHobbyDetail };
  },
  data() {
    return {
      listServiceHobby: [],
      serviceHobbyDetail: {}
    };
  },
  methods: {
    filterOption(input, option) {
      return (
        option.children[0].children
          .toLowerCase()
          .indexOf(input.toLowerCase()) >= 0
      );
    },

    /**
     * Hàm sử lí đóng Modal sở thích phục vụ
     * CreatedBy: duylv - 27/9/2021
     */
    btnCloseServiceHobbyDetail() {
      this.$emit("btnCloseServiceHobbyDetail");
    },

    /**
     * Hàm sử lí nút lưu form
     * CreatedBy: duylv - 05/10/2021
     */
    btnSave() {
      var isValid = this.validate(this.serviceHobbyDetail.ServiceHobbyName);
      if (isValid) {
        this.$emit("saveFormServiceHobbyDetail", this.serviceHobbyDetail);
      }
    },

    /**
     * Kiểm tra bắt buộc nhập
     * CreatedBy: duylv - 10/10/2021
     */
    validate(value) {
      var isValid = true;
      if (!value) {
        this.$refs.serviceHobbyNameParent.classList.add("input-error");
        return (isValid = false);
      }
      return isValid;
    },

    /**
     * Bỏ thông báo lỗi
     * CreatedBy: duylv - 10/10/2021
     */
    removeMessError() {
      this.$refs.serviceHobbyNameParent.classList.remove("input-error");
    }
  },
};
</script>
<style scoped>
@import url("../../../../assets/css/base/modal.css");

@import url("../../../../assets/css/page/menuDetail.css");
@import url("../../../../assets/css/base/table.css");
</style>