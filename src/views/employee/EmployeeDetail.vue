<template>
  <div class="modal" @keyup.prevent="onClickKeyUp">
    <div class="modal-box">
      <div class="modal-header">
        <div class="modal-title">{{formMode}} {{$Language.Food}}</div>
        <button @click="btnExitMenuDetail" class="btn-close-form">
          <span class="icon-tool icon-button-close"></span>
        </button>
      </div>
      <div class="modal-toolbar">
        <div style="display:flex;">
          <div class="label-toolbar">{{$Language.Type}}</div>
          <a-select
            tabindex="14"
            :size="`small`"
            class="select-menu-group"
            style="width: 120px;"
            :defaultValue="0"
            v-model:value="menuDetail.TypeOfMenu"
            dropdownClassName="select-menu-group"
          >
            <a-select-option
              v-for="(item,index) in listTypeOfMenu"
              :key="index"
              :value="item.value"
              :label="item.value"
            >{{item.name}}</a-select-option>
          </a-select>
        </div>
      </div>
      <div class="modal-content">
        <div class="tabs">
          <div
            @click="tab=1"
            :class="{'active': tab ==1}"
            class="tab-bar"
          >{{$Language.MenuDetail.GeneralInformation}}</div>
          <div
            @click="tab=2"
            :class="{'active': tab ==2}"
            class="tab-bar"
          >{{$Language.MenuDetail.ServiceHobby}}</div>
        </div>

        <div class="tab-content" ref="formMenuDetail">
          <div v-if="tab==1" class="tab-infor">
            <div class="infor">
              <div class="input-form" ref="MenuNameParent">
                <div class="label">
                  {{$Language.MenuDetail.MenuName}}
                  <span class="required">(*)</span>
                </div>
                <div class="input">
                  <div class="validate">
                    <a-input
                      tabindex="1"
                      :maxLength="255"
                      :required="true"
                      id="txtMenuName"
                      @blur="validateRequired($event.target,menuDetail.MenuName)"
                      size="small"
                      class="textbox"
                      ref="MenuName"
                      v-model:value="menuDetail.MenuName"
                    />
                    <span class="icon-error"></span>
                  </div>
                  <div class="error-mess">{{$Language.ValidateMessage.MenuName}}</div>
                </div>
              </div>
              <div class="input-form" ref="MenuCodeParent">
                <div class="label">
                  {{$Language.MenuDetail.MenuCode}}
                  <span class="required">(*)</span>
                </div>
                <div class="input">
                  <div class="validate">
                    <a-input
                      tabindex="2"
                      :maxLength="25"
                      :required="true"
                      id="txtMenuCode"
                      @blur="validateRequired($event.target,menuDetail.MenuCode)"
                      class="textbox"
                      size="small"
                      ref="MenuCode"
                      v-model:value="menuDetail.MenuCode"
                    />
                    <span class="icon-error"></span>
                  </div>
                  <div class="error-mess">{{$Language.ValidateMessage.MenuCode}}</div>
                </div>
              </div>
              <div class="input-form">
                <div class="label">{{$Language.MenuDetail.OrderOfDishes}}</div>
                <div class="input" style="width:150px;">
                  <a-select
                    tabindex="3"
                    :size="`small`"
                    show-search
                    :filter-option="filterOption"
                    :dropdownMatchSelectWidth="false"
                    v-model:value="menuDetail.OrderOfDishes"
                    style="width: 200px; !important;"
                  >
                    <a-select-option
                      v-for="(item,index) in listOrderOfDishes"
                      :key="index"
                      :value="item.value"
                      :label="item.value"
                    >{{item.name}}</a-select-option>
                  </a-select>
                </div>
              </div>
              <div class="input-form">
                <div class="label">{{$Language.MenuDetail.MenuGroupName}}</div>
                <div class="input">
                  <div class="validate">
                    <a-select
                      tabindex="4"
                      :size="`small`"
                      show-search
                      :filter-option="filterOption"
                      :dropdownMatchSelectWidth="false"
                      v-model:value="menuDetail.MenuGroupId"
                      style="width: 100% !important"
                    >
                      <a-select-option
                        v-for="(item,index) in listMenuGroup"
                        :key="index"
                        :value="item.MenuGroupId"
                        :label="item.MenuGroupId"
                      >{{item.MenuGroupName}}</a-select-option>
                    </a-select>
                  </div>
                </div>
              </div>
              <div class="input-form" ref="UnitParent">
                <div class="label">
                  {{$Language.MenuDetail.Unit}}
                  <span class="required">(*)</span>
                </div>
                <div class="input">
                  <div class="validate">
                    <a-select
                      tabindex="5"
                      :required="true"
                      id="txtUnit"
                      @blur="validateRequired($event.target,menuDetail.UnitId)"
                      :size="`small`"
                      show-search
                      :filter-option="filterOption"
                      :dropdownMatchSelectWidth="false"
                      v-model:value="menuDetail.UnitId"
                      class="textbox"
                    >
                      <a-select-option
                        v-for="(item,index) in listUnit"
                        :key="index"
                        :value="item.UnitId"
                        :label="item.UnitId"
                      >{{item.UnitName}}</a-select-option>
                    </a-select>
                    <span class="icon-error"></span>
                  </div>
                  <div class="error-mess">{{$Language.ValidateMessage.Unit}}</div>
                </div>
              </div>
              <div class="input-form" ref="PriceParent">
                <div class="label">
                  {{$Language.MenuDetail.Price}}
                  <span class="required">(*)</span>
                </div>
                <div class="input">
                  <div class="validate">
                    <a-input-number
                      tabindex="6"
                      :required="true"
                      id="txtPrice"
                      @blur="validateRequired($event.target,menuDetail.Price)"
                      v-model:value="menuDetail.Price"
                      defaultValue="0"
                      style="width: 150px"
                      class="price textbox"
                      size="small"
                      :formatter="value => $FormatData.formatMoney(value)"
                      :parser="x => $FormatData.parseMoney(x)"
                      :controls="false"
                    />
                    <span class="icon-error"></span>
                    <div class="check-box" style="margin-left:10px;">
                      <input type="checkbox" v-model="menuDetail.ChangeWithTime" />
                      <span class="checkmark"></span>
                    </div>
                    <span style="margin-left:10px;">{{$Language.MenuDetail.ChangeWithTime}}</span>
                  </div>

                  <div class="error-mess">{{$Language.ValidateMessage.Price}}</div>
                </div>
              </div>
              <div class="input-form">
                <div class="label">{{$Language.MenuDetail.CostOfCapital}}</div>
                <div class="input">
                  <div class="validate">
                    <a-input-number
                      tabindex="7"
                      v-model:value="menuDetail.CostOfCapital"
                      defaultValue="0"
                      style="width: 150px"
                      class="price"
                      size="small"
                      :formatter="value => $FormatData.formatMoney(value)"
                      :parser="x => $FormatData.parseMoney(x)"
                      :controls="false"
                    />
                    <div class="check-box" style="margin-left:10px;">
                      <input type="checkbox" v-model="menuDetail.FreePriceAdjustment" />
                      <span class="checkmark"></span>
                    </div>
                    <span style="margin-left:10px;">{{$Language.MenuDetail.FreePriceAdjustment}}</span>
                  </div>
                </div>
              </div>
              <div class="input-form">
                <div class="label">{{$Language.MenuDetail.Description}}</div>
                <div class="input">
                  <a-textarea
                    tabindex="8"
                    v-model:value="menuDetail.Description"
                    :auto-size="{ minRows: 2, maxRows: 2 }"
                  />
                </div>
              </div>
              <div class="input-form">
                <div class="label">{{$Language.MenuDetail.Processing}}</div>
                <div class="input">
                  <a-select
                    tabindex="9"
                    mode="multiple"
                    size="small"
                    :filter-option="filterOption"
                    v-model:value="menuDetail.ListProcessing"
                    style="width: 100%"
                  >
                    <a-select-option
                      v-for="(item,index) in listProcessing"
                      :key="index"
                      :value="item.ProcessingId"
                      :label="item.ProcessingId"
                    >{{item.ProcessingName}}</a-select-option>
                  </a-select>
                </div>
              </div>
              <div class="input-form">
                <div class="label"></div>
                <div class="check-box">
                  <input type="checkbox" v-model="menuDetail.NotDisplayed" />
                  <span class="checkmark"></span>
                </div>
                <span style="margin-left:10px;">{{$Language.MenuDetail.NotDisplayed}}</span>
              </div>
            </div>
            <div class="avartar">
              <div class="title">{{$Language.MenuDetail.Avatar}}</div>
              <div class="avartar-box">
                <div class="image">
                  <img v-if="!menuDetail.Avatar" src="../../assets/images/ImageHandler.png" alt />
                  <img v-else ref="imgAvatar" :src="menuDetail.Avatar" alt />
                  <input
                    type="file"
                    ref="inputAvatar"
                    @change="imageUploaded()"
                    style="display:none"
                  />
                  <button @click="btnUploadImage" class="button button-select-menu">
                    <span class="icon-tool icon-select-menu"></span>
                    <span class="text">{{$Language.Button.IconAvatar}}</span>
                  </button>
                  <div class="text">
                    {{$Language.UploadImageType}}
                    <br />
                    <b>(.jpg, .jpeg, .png, .gif)</b>
                  </div>
                </div>
                <div class="action">
                  <button @click="btnUploadImage" class="button">
                    <span class="text">...</span>
                  </button>
                  <button @click="btnCancelImage" class="button cancel">
                    <span class="text">î¡‚</span>
                  </button>
                </div>
              </div>
            </div>
          </div>

          <div v-if="tab==2" class="tab-interests">
            <div>{{$Language.Menu}}:</div>
            <div class="addition">
              <span class="icon-infor-large"></span>
              <span class="text">
                {{$Language.ServiceHobby}}
                <br />
                {{$Language.ServiceHobbyExample}}
              </span>
            </div>
            <div class="table-scroll">
              <div class="table">
                <div class="thead">
                  <div class="tr">
                    <div class="th" style="width:480px;">
                      <div class="text">{{$Language.MenuDetail.ServiceHobby}}</div>
                    </div>
                    <div class="th" style="width:245px;">
                      <div class="text">{{$Language.MenuDetail.CollectMore}}</div>
                    </div>
                  </div>
                </div>
                <div class="tbody">
                  <div
                    class="tr"
                    v-for="(itemSV,index) in menuDetail.ListServiceHobby"
                    :key="index"
                    @click="selectRowServiceHobby(index)"
                  >
                    <td class="td" style="width:480px;">
                      <div class="input" style="width: 100%; display:flex;">
                        <a-select
                          :size="`small`"
                          v-model:value="itemSV.ServiceHobbyId"
                          show-search
                          :filter-option="filterOption"
                          :dropdownMatchSelectWidth="false"
                          @change="onChangeServiceHobby(itemSV.ServiceHobbyId,index)"
                          class="textbox"
                        >
                          <template #dropdownRender="{ menuNode: menu }">
                            <div class="dropdown-header">
                              <div
                                class="item-header"
                                style="width:205px"
                              >{{$Language.MenuDetail.ServiceHobby}}</div>
                              <div
                                class="item-header"
                                style="width:205px"
                              >{{$Language.MenuDetail.CollectMore}}</div>
                            </div>
                            <v-nodes :vnodes="menu" />
                          </template>
                          <a-select-option
                            v-for="(item,index) in listServiceHobby"
                            :key="index"
                            :value="item.ServiceHobbyId"
                            :label="item.ServiceHobbyId"
                            class="dropdown-option"
                          >
                            <div class="col" style="width:200px">{{item.ServiceHobbyName}}</div>
                            <div
                              class="col"
                              style="width:200px"
                            >{{$FormatData.formatMoney(item.CollectMore)}}</div>
                          </a-select-option>
                        </a-select>
                        <button @click="btnSearchServiceHobbyModal" class="button">
                          <span class="icon-tool icon-search"></span>
                        </button>
                        <button @click="btnAddServiceHobbyDetail" class="button">
                          <span class="icon-tool icon-add-blue"></span>
                        </button>
                      </div>
                    </td>
                    <div class="td" style="text-align:right; width:245px;">
                      <a-input-number
                        v-model:value="itemSV.CollectMore"
                        style="width: 100%; border:none;"
                        class="price"
                        size="small"
                        :formatter="value => $FormatData.formatMoney(value)"
                        :parser="x => $FormatData.parseMoney(x)"
                        :controls="false"
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="action-table">
              <button @click="addItemServiceHobby" class="button button-select-menu">
                <span class="icon-button icon-add"></span>
                <span class="text">{{$Language.Button.AddLine}}</span>
              </button>
              <button
                :disabled="menuDetail.ListServiceHobby.length == 0 "
                @click="removeItemServiceHobby"
                class="button button-select-menu"
              >
                <span class="icon-button icon-delete"></span>
                <span class="text">{{$Language.Button.DeleteLine}}</span>
              </button>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <div class="help">
          <button tabindex="13" class="button button-select-menu">
            <span class="icon-button icon-help"></span>
            <span class="text">{{$Language.Button.Help}}</span>
          </button>
        </div>
        <div class="action">
          <button
            @keyup.enter="btnSave"
            tabindex="10"
            @click="btnSave"
            class="button button-select-menu"
          >
            <span class="icon-tool icon-save"></span>
            <span class="text">{{$Language.Button.Save}}</span>
          </button>
          <button
            @keyup.enter="btnSaveAndAdd"
            tabindex="11"
            @click="btnSaveAndAdd"
            class="button button-select-menu"
          >
            <span class="icon-tool icon-save-add"></span>
            <span class="text">{{$Language.Button.SaveAndAdd}}</span>
          </button>
          <button
            @keyup.enter="btnCloseMenuDetail"
            tabindex="12"
            @click="btnCloseMenuDetail"
            class="button button-select-menu"
          >
            <span class="icon-tool icon-disable"></span>
            <span class="text">{{$Language.Button.Cancel}}</span>
          </button>
        </div>
      </div>
    </div>
    <service-hobby-modal
      :listServiceHobbyModal="this.menuDetail.ListServiceHobby"
      v-if="openServiceHobbyModal"
      @btnCloseServiceHobbyModal="btnCloseServiceHobbyModal"
      @btnChooseServiceHobbyModal="btnChooseServiceHobbyModal"
      @btnAddServiceHobbyDetail="btnAddServiceHobbyDetail"
    />
    <service-hobby-detail
      v-if="openServiceHobbyDetail"
      @btnCloseServiceHobbyDetail="btnCloseServiceHobbyDetail"
      @saveFormServiceHobbyDetail="saveFormServiceHobbyDetail"
    />

    <base-popup v-if="openPopupWarning" :popupDetail="popupDetail">
      <template #buttonRight>
        <button @click="btnClosePopup" class="button button-popup">
          <span class="text">{{$Language.Button.Agree}}</span>
        </button>
      </template>
    </base-popup>

    <base-popup v-if="openPopupQuestion" :popupDetail="popupDetail">
      <template #buttonRight>
        <button @click="btnSave" class="button button-popup" style="margin:2px">
          <span class="text">{{$Language.Button.Yes}}</span>
        </button>
        <button @click="btnCloseMenuDetail" class="button button-popup" style="margin:2px">
          <span class="text">{{$Language.Button.No}}</span>
        </button>
        <button @click="btnClosePopup" class="button button-popup" style="margin:2px">
          <span class="text">{{$Language.Button.Cancel}}</span>
        </button>
      </template>
    </base-popup>
  </div>
</template>
<script>
import BaseCheckbox from "../../components/base/BaseCheckbox.vue";
import BasePopup from "../../components/base/BasePopup.vue";
import ServiceHobbyDetail from "../../components/page/menu/menuDetail/ServiceHobbyDetail.vue";
import ServiceHobbyModal from "../../components/page/menu/menuDetail/ServiceHobbyModal.vue";

export default {
  props: {
    formData: {
      type: Object,
      default: {}
    },
    formMode: {
      type: String,
      default: ""
    }
  },

  components: {
    VNodes: (_, { attrs }) => {
      return attrs.vnodes;
    },
    ServiceHobbyModal,
    ServiceHobbyDetail,
    BasePopup,
    BaseCheckbox
  },
  mounted() {
    this.$refs.MenuName.focus();
    this.menuDetail = { ...this.formData };

    this.listServiceHobby = this.$ServiceHobbyModel.listServiceHobby;
    this.listMenuGroup = this.$MenuGroupModel.listMenuGroup;
    this.listUnit = this.$UnitModel.listUnit;
    this.listProcessing = this.$ProcessingModel.listProcessing;
    this.listTypeOfMenu = this.$TypeOfMenuModel.listTypeOfMenu;
    this.listOrderOfDishes = this.$OrderOfDishesModel.listOrderOfDishes;

    this.formModeMenuDetail = this.formMode;

    if (this.menuDetail.ListServiceHobby.length == 0) {
      this.addItemServiceHobby();
    }
  },
  computed: {
    listServiceHobbyTable() {
      return this.menuDetail.ListServiceHobby;
    }
  },
  data() {
    return {
      tab: 1,
      openServiceHobbyModal: false,
      openServiceHobbyDetail: false,
      menuDetail: { ...this.formData },

      listTypeOfMenu: [],

      listOrderOfDishes: [],

      listServiceHobby: [],

      listMenuGroup: [],

      listUnit: [],

      listProcessing: [],

      formModeMenuDetail: "",

      popupDetail: { icon: "icon-warning", mess: "Mã trùng" },
      openPopupWarning: false,
      openPopupQuestion: false,

      collectMore: "",

      serviceHobbyId: ""
    };
  },
  methods: {
    /**
     * Hàm tìm kiếm dropdown
     * CreatedBy: duylv - 30/9/2021
     */
    filterOption(input, option) {
      return (
        option.children[0].children
          .toLowerCase()
          .indexOf(input.toLowerCase()) >= 0
      );
    },

    /**
     * Hàm sử lí mở Modal sở thích phục vụ
     * CreatedBy: duylv - 30/9/2021
     */
    btnSearchServiceHobbyModal() {
      this.openServiceHobbyModal = true;
    },

    /**
     * Hàm sử lí đóng Modal sở thích phục vụ
     * CreatedBy: duylv - 30/9/2021
     */
    btnCloseServiceHobbyModal() {
      this.openServiceHobbyModal = false;
    },

    /**
     * Sự kiện khi chọn sở thích phục vụ
     * CreatedBy: duylv - 08/10/2021
     */
    btnChooseServiceHobbyModal(list) {
      this.menuDetail.ListServiceHobby = JSON.parse(JSON.stringify(list));
    },
    /**
     * Hàm sử lí mở Detail sở thích phục vụ
     * CreatedBy: duylv - 30/9/2021
     */
    btnAddServiceHobbyDetail() {
      this.openServiceHobbyDetail = true;
    },
    /**
     * Hàm sử lí đóng Detail sở thích phục vụ
     * CreatedBy: duylv - 30/9/2021
     */
    btnCloseServiceHobbyDetail() {
      this.openServiceHobbyDetail = false;
    },

    /**
     * Hàm sử lí đóng form MenuDetail
     * CreatedBy: duylv - 10/10/2021
     */
    btnExitMenuDetail() {
      try {
        var checkObj = this.$ValidateData.checkObjEqual(
          this.formData,
          this.menuDetail
        );
        if (checkObj == false) {
          this.popupDetail.mess = this.$Language.ValidateMessage.CloseForm;
          this.popupDetail.icon = this.$Enum.IconPopup.Question;
          this.openPopupQuestion = true;
        } else {
          this.$emit("btnCloseMenuDetail");
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí đóng form MenuDetail
     * CreatedBy: duylv - 30/9/2021
     */
    btnCloseMenuDetail() {
      this.$emit("btnCloseMenuDetail");
    },

    /**
     * Hàm sử lí nút cất
     * CreatedBy: duylv - 30/9/2021
     */
    async btnSave() {
      try {
        var isValid = await this.saveFormDetail();
        if (isValid) {
          this.btnCloseMenuDetail();
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí nút cất và thêm
     * CreatedBy: duylv - 30/9/2021
     */
    async btnSaveAndAdd() {
      try {
        var isValid = await this.saveFormDetail();
        if (isValid) {
          this.formModeMenuDetail = this.$Enum.FormMode.Add;
          this.menuDetail = { ...this.$MenuModel.MenuDetailDefault };
          this.$refs.MenuName.focus();
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Hàm sử lí cất dữ liệu
     * CreatedBy: duylv - 30/9/2021
     */
    async saveFormDetail() {
      try {
        var isValid = this.validateAll();
        if (isValid) {
          isValid = await this.checkDuplicateMenuCode();
          if (!isValid) {
            this.popupDetail.icon = this.$Enum.IconPopup.Warning;
            this.popupDetail.mess = this.$Language.ValidateMessage.Duplicate.replace(
              "{0}",
              this.menuDetail.MenuCode
            );

            this.openPopupWarning = true;
            return isValid;
          } else {
            this.$emit("saveFormMenuDetail", {
              formMode: this.formModeMenuDetail,
              formData: this.menuDetail
            });
            this.btnClosePopup();
            return isValid;
          }
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Kiểm tra trùng mã
     * CreatedBy: duylv - 03/10/2021
     */
    async checkDuplicateMenuCode() {
      try {
        var res = await this.$MenuApi.checkDuplicateMenuCode(this.menuDetail);
        var isValid = res.data.IsValid;
        return isValid;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Gọi api lấy mã mới
     * CreatedBy: duylv - 03/10/2021
     */
    async getNewMenuCode() {
      await this.$MenuApi
        .getNewMenuCode(this.menuDetail.MenuName)
        .then(res => {
          this.menuDetail.MenuCode = res.data.Data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Kiểm tra các trường bắt buộc
     * CreatedBy: duylv - 06/10/2021
     */
    validateRequired(event, value) {
      try {
        var me = this;
        if (value == "" || value == 0 || value == null) {
          switch (event.id) {
            case "txtMenuName":
              me.$refs.MenuNameParent.classList.add("input-error");
              return false;
            case "txtMenuCode":
              me.$refs.MenuCodeParent.classList.add("input-error");
              return false;
            case "txtUnit":
              me.$refs.UnitParent.classList.add("input-error");
              return false;
            case "txtPrice":
              me.$refs.PriceParent.classList.add("input-error");
              return false;
            default:
              break;
          }
        } else {
          if (event.id == "txtMenuName" && this.menuDetail.MenuCode == "") {
            this.getNewMenuCode();
            me.$refs.MenuCodeParent.classList.remove("input-error");
          }
          this.removeRequired(event);
          return true;
        }
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Kiểm tra các trường bắt buộc trước khi cất
     * CreatedBy: duylv - 06/10/2021
     */
    validateAll() {
      try {
        let inputError = [];
        let checkRequired = true;
        let check;
        var formDetail = this.$refs.formMenuDetail;
        var inputRequired = formDetail.querySelectorAll(`div > [required]`);
        inputRequired.forEach(input => {
          var value = input.value;
          if (input.id == "") {
            input = input.querySelector("input");
            value = this.menuDetail.UnitId;
          }
          check = this.validateRequired(input, value);

          if (!check) {
            inputError.push(input.closest(".input"));
            checkRequired = check;
          }
        });
        this.tab = 1;
        if (inputError.length > 0) {
          inputError[0].querySelector("input").focus();
        }
        return checkRequired;
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Sự kiện bỏ cảnh báo khi focus
     * CreatedBy: duylv - 06/10/2021
     */
    removeRequired(event) {
      var me = this;
      switch (event.id) {
        case "txtMenuName":
          me.$refs.MenuNameParent.classList.remove("input-error");
          break;
        case "txtMenuCode":
          me.$refs.MenuCodeParent.classList.remove("input-error");
          break;
        case "txtUnit":
          me.$refs.UnitParent.classList.remove("input-error");
          break;
        case "txtPrice":
          me.$refs.PriceParent.classList.remove("input-error");
          break;
        default:
          break;
      }
    },

    /**
     * Sự kiện nút đóng popup
     * CreatedBy: duylv - 08/10/2021
     */
    btnClosePopup() {
      this.openPopupWarning = false;
      this.openPopupQuestion = false;
    },

    /**
     * Sự kiện nút thêm ảnh
     * CreatedBy: duylv - 01/10/2021
     */
    btnUploadImage() {
      this.$refs.inputAvatar.click();
    },

    /**
     * Thực hiện xóa ảnh
     * CreatedBy: duylv - 12/10/2021
     */
    btnCancelImage() {
      this.menuDetail.Avatar = "";
    },

    /**
     * Thực hiện upload ảnh
     * CreatedBy: duylv - 12/10/2021
     */
    imageUploaded() {
      var file = this.$refs.inputAvatar.files[0];
      console.log("file", file);
      const reader = new FileReader();

      reader.onload = () => {
        this.menuDetail.Avatar = reader.result;
      };
      reader.readAsDataURL(file);
      console.log(file);
      this.menuDetail.ImageType = file.type;
    },

    /**
     * Hiển thị thu thêm trên table khi chọn dịch vụ
     * CreatedBy: duylv - 10/10/2021
     */
    onChangeServiceHobby(id, index) {
      try {
        var list = this.listServiceHobby;
        list.forEach(item => {
          if (item.ServiceHobbyId == id) {
            this.menuDetail.ListServiceHobby[index].CollectMore =
              item.CollectMore;
          }
        });
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Lưu form dịch vụ yêu thích
     * CreatedBy: duylv - 10/10/2021
     */
    async saveFormServiceHobbyDetail(formData) {
      await this.$ServiceHobbyApi
        .insertData(formData)
        .then(res => {
          this.btnCloseServiceHobbyDetail();
          this.getAllServiceHobby();
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
          console.log(res.data);
          me.listServiceHobby = res.data;
        })
        .catch(error => {
          console.log(error);
        });
    },

    /**
     * Thêm dòng dịch vụ yêu thích
     * CreatedBy: duylv - 10/10/2021
     */
    addItemServiceHobby() {
      var serviceHobbyDetail = {
        ...this.$ServiceHobbyModel.ServiceHobbyDetail
      };
      this.menuDetail.ListServiceHobby.push(serviceHobbyDetail);
    },

    /**
     * Xóa dòng dịch vụ yêu thích
     * CreatedBy: duylv - 10/10/2021
     */
    removeItemServiceHobby() {
      this.menuDetail.ListServiceHobby.splice(this.serviceHobbyId, 1);
      this.serviceHobbyId = this.menuDetail.ListServiceHobby.length - 1;
    },

    /**
     * Sử lí dưk kiện bấm nút từ bàn phím
     */
    onClickKeyUp(event) {
      event.preventDefault();
      if (event.keyCode === 83 && event.ctrlKey) {
        console.log(event);
        this.btnSave();
      }
    },

    /**
     * Chọn vị trí dịch vụ yêu thích
     */
    selectRowServiceHobby(index) {
      this.serviceHobbyId = index;
    }
  },
  computed: {},
  watch: {
    menuDetail: {
      deep: true,
      handler() {
        // console.log(this.menuDetail);
      }
    }
  }
};
</script>
<style scoped>
@import url("../../assets/css/page/menuDetail.css");
@import url("../../assets/css/base/modal.css");

@import url("../../assets/css/base/table.css");
</style>