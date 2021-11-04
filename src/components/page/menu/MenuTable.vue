<template>
  <div class="table-scroll">
    <div class="table">
      <div class="thead">
        <div class="tr">
          <div class="th" style="width:150px;">
            <div class="text">{{language.MenuDetail.TypeOfMenu}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                dropdownClassName="select-menu-group"
                v-model:value="listFilterTable[0].FilterName"
                @change="filterName($event,0)"
              >
                <a-select-option
                  v-for="(item,index) in typeOfMenu"
                  :key="index"
                  :value="item.value"
                  :label="item.name"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.MenuCode}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                :dropdownMatchSelectWidth="false"
                style="width: 24px; !importain;"
                :showArrow="false"
                v-model:value="listFilterTable[1].Operator"
                @change="filterOperator($event,1)"
              >
                <a-select-option
                  v-for="(item,index) in filterTextColumn"
                  :key="index"
                  :value="item.value"
                  :label="item.caculate"
                >{{item.caculate + " : "+item.name}}</a-select-option>
              </a-select>
              <a-input
                v-model:value="listFilterTable[1].FilterName"
                @blur="filterName($event.target.value,1)"
                @pressEnter="filterName($event.target.value,1)"
                size="small"
                style="height:24px;"
              />
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.MenuName}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                :dropdownMatchSelectWidth="false"
                :defaultValue="filterTextColumn[0].value"
                style="width: 24px; !importain;"
                :showArrow="false"
                v-model:value="listFilterTable[2].Operator"
                @change="filterOperator($event,2)"
              >
                <a-select-option
                  v-for="(item,index) in filterTextColumn"
                  :key="index"
                  :value="item.value"
                  :label="item.caculate"
                >{{item.caculate + " : "+item.name}}</a-select-option>
              </a-select>
              <a-input
                v-model:value="listFilterTable[2].FilterName"
                @blur="filterName($event.target.value,2)"
                @pressEnter="filterName($event.target.value,2)"
                size="small"
                style="height:24px;"
              />
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.MenuGroupName}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                :dropdownMatchSelectWidth="false"
                :defaultValue="filterTextColumn[0].value"
                style="width: 24px; !importain;"
                :showArrow="false"
                @change="filterOperator($event,3)"
                v-model:value="listFilterTable[3].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterTextColumn"
                  :key="index"
                  :value="item.value"
                  :label="item.caculate"
                >{{item.caculate + " : "+item.name}}</a-select-option>
              </a-select>
              <a-input
                @blur="filterName($event.target.value,3)"
                @pressEnter="filterName($event.target.value,3)"
                v-model:value="listFilterTable[3].FilterName"
                size="small"
                style="height:24px;"
              />
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.Unit}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                :dropdownMatchSelectWidth="false"
                :defaultValue="filterTextColumn[0].value"
                style="width: 24px; !importain;"
                :showArrow="false"
                @change="filterOperator($event,4)"
                v-model:value="listFilterTable[4].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterTextColumn"
                  :key="index"
                  :value="item.value"
                  :label="item.caculate"
                >{{item.caculate + " : "+item.name}}</a-select-option>
              </a-select>
              <a-input
                @blur="filterName($event.target.value,4)"
                @pressEnter="filterName($event.target.value,4)"
                v-model:value="listFilterTable[4].FilterName"
                size="small"
                style="height:24px;"
              />
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.Price}}</div>
            <div class="filter">
              <a-select
                ref="Price"
                :size="`small`"
                :dropdownMatchSelectWidth="false"
                :defaultValue="filterNumberColumn[2].value"
                style="width: 24px; !importain;"
                :showArrow="false"
                @change="filterOperator($event,5)"
                v-model:value="listFilterTable[5].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterNumberColumn"
                  :key="index"
                  :value="item.value"
                  :label="item.caculate"
                >{{item.caculate + " : "+item.name}}</a-select-option>
              </a-select>
              <a-input-number
                style="width: 100%"
                class="price"
                size="small"
                :formatter="value => $FormatData.formatMoney(value)"
                :parser="value => $FormatData.parseMoney(value)"
                v-model:value="listFilterTable[5].FilterName"
                defaultValue="0"
                :controls="false"
                @blur="filterName($event.target.value,5)"
                @pressEnter="filterName($event.target.value,5)"
              />
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.ChangeWithTime}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                :defaultValue="`all`"
                dropdownClassName="select-menu-group"
                @change="filterOperator($event.value,6)"
                v-model:value="listFilterTable[6].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterYesNo"
                  :key="index"
                  :value="item.value"
                  :label="item.value"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.FreePriceAdjustment}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                :defaultValue="`all`"
                dropdownClassName="select-menu-group"
                @change="filterOperator($event,7)"
                v-model:value="listFilterTable[7].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterYesNo"
                  :key="index"
                  :value="item.value"
                  :label="item.name"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.QuantitativeNVL}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                :defaultValue="`all`"
                dropdownClassName="select-menu-group"
                @change="filterOperator($event,8)"
                v-model:value="listFilterTable[8].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterSetup"
                  :key="index"
                  :value="item.value"
                  :label="item.name"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.ShowOnMenu}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                :defaultValue="`all`"
                dropdownClassName="select-menu-group"
                @change="filterOperator($event,9)"
                v-model:value="listFilterTable[9].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterYesNo"
                  :key="index"
                  :value="item.value"
                  :label="item.name"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
          <div class="th">
            <div class="text">{{language.MenuDetail.StopSale}}</div>
            <div class="filter">
              <a-select
                :size="`small`"
                class="select-menu-group"
                show-search
                style="width: 100%;"
                :filter-option="filterOption"
                :defaultValue="`all`"
                dropdownClassName="select-menu-group"
                @change="filterOperator($event,10)"
                v-model:value="listFilterTable[10].Operator"
              >
                <a-select-option
                  v-for="(item,index) in filterYesNo"
                  :key="index"
                  :value="item.value"
                  :label="item.name"
                >{{item.name}}</a-select-option>
              </a-select>
            </div>
          </div>
        </div>
      </div>
      <div>
        <div class="tbody">
          <div
            v-for="(item,index) in listMenu"
            class="tr"
            :class="{'active' : item.MenuId== menuId}"
            @click="selectRow(item)"
            @dblclick="btnEdit(item.MenuId)"
            :key="index"
          >
            <div class="td">{{ $FormatData.formatTypeOfMenu(item.TypeOfMenu)}}</div>
            <div class="td">{{item.MenuCode}}</div>
            <div class="td">{{item.MenuName}}</div>
            <div class="td">{{item.MenuGroupName}}</div>
            <div class="td">{{item.UnitName}}</div>
            <div class="td" style="text-align:right;">{{$FormatData.formatMoney(item.Price)}}</div>
            <div class="td" style="text-align:center;">
              <base-checkbox :checked="item.ChangeWithTime" />
            </div>
            <div class="td" style="text-align:center;">
              <base-checkbox :checked="item.FreePriceAdjustment" />
            </div>
            <div class="td">{{$FormatData.formatQuantitativeNVL(item.QuantitativeNVL)}}</div>

            <div class="td" style="text-align:center;">
              <base-checkbox :checked="item.NotDisplayed?true:false" />
            </div>
            <div class="td" style="text-align:center;">
              <base-checkbox :checked="item.StopSale" />
            </div>
          </div>
          <base-loading v-if="isLoading" />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Language from "../../../resources/language/vie";
import Emum from "../../../utils/enum";
import BaseLoading from "../../base/BaseLoading.vue";
import BaseCheckbox from "../../base/BaseCheckbox.vue";

export default {
  components: { BaseLoading, BaseCheckbox },
  props: {
    listMenu: {
      type: Array,
      default: () => []
    },
    menuId: {
      type: String,
      default: ""
    },
    listFilter: {
      type: Array,
      default: () => []
    },
    isLoading: {
      type: Boolean,
      default: false
    }
  },
  mounted() {
    this.listFilterTable = this.listFilter;
  },
  data() {
    return {
      language: this.$Language,
      filterTextColumn: [
        {
          name: this.$Language.Filter.Contain,
          value: this.$Enum.Filter.Like,
          caculate: this.$Language.Calculation.Contain
        },
        {
          name: this.$Language.Filter.Equal,
          value: this.$Enum.Filter.Equal,
          caculate: this.$Language.Calculation.Equal
        },
        {
          name: this.$Language.Filter.StartWith,
          value: this.$Enum.Filter.StartWith,
          caculate: this.$Language.Calculation.StartWith
        },
        {
          name: this.$Language.Filter.EndsWith,
          value: this.$Enum.Filter.EndsWith,
          caculate: this.$Language.Calculation.EndsWith
        },
        {
          name: this.$Language.Filter.NotContain,
          value: this.$Enum.Filter.NotLike,
          caculate: this.$Language.Calculation.NotContain
        }
      ],
      filterNumberColumn: [
        {
          name: Language.Filter.Equal,
          value: Emum.Filter.Like,
          caculate: this.$Language.Calculation.Equal
        },
        {
          name: Language.Filter.Less,
          value: Emum.Filter.Less,
          caculate: this.$Language.Calculation.Less
        },
        {
          name: Language.Filter.LessEqual,
          value: Emum.Filter.LessEqual,
          caculate: this.$Language.Calculation.LessEqual
        },
        {
          name: Language.Filter.Greater,
          value: Emum.Filter.Greater,
          caculate: this.$Language.Calculation.Greater
        },
        {
          name: Language.Filter.GreaterEqual,
          value: Emum.Filter.GreaterEqual,
          caculate: this.$Language.Calculation.GreaterEqual
        }
      ],
      filterYesNo: [
        {
          name: this.$Language.Filter.Yes,
          value: this.$Enum.Filter.NotContain
        },
        { name: this.$Language.Filter.No, value: this.$Enum.Filter.Equal },
        {
          name: this.$Language.All,
          value: this.$Enum.Filter.NotLike
        }
      ],
      filterSetup: [
        {
          name: this.$Language.Filter.Setup,
          value: this.$Enum.Filter.NotContain
        },
        {
          name: this.$Language.Filter.NoSetup,
          value: this.$Enum.Filter.Equal
        },
        {
          name: this.$Language.All,
          value: this.$Enum.Filter.NotLike
        }
      ],

      typeOfMenu: [
        ...this.$TypeOfMenuModel.listTypeOfMenu,
        { name: Language.All, value: "" }
      ],
      listFilterTable: this.listFilter
    };
  },
  methods: {
    /**
     * Sử lí sự kiện tìm kiếm dropdown
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
     * Sử lí sự kiện tìm kiếm phân trang
     * CreatedBy: duylv - 01/10/2021
     */
    filterName(value, index) {
      if (typeof value == "string" && value.indexOf(".") > 0) {
        value = value.replaceAll(".", "");
      }
      this.listFilterTable[index].FilterName = value;
      this.$emit("onChangeFilter", this.listFilterTable);
    },

    /**
     * Sử lí sự kiện tìm kiếm phân trang
     * CreatedBy: duylv - 01/10/2021
     */
    filterOperator(value, index) {
      this.listFilterTable[index].Operator = value;
      this.$emit("onChangeFilter", this.listFilterTable);
    },
    /**
     * Hàm sử lí nút sửa
     * CreatedBy: duylv - 01/10/2021
     */
    btnEdit(id) {
      this.$emit("btnEdit", id);
    },

    /**
     * Hàm sử lí chọn hàng
     * CreatedBy: duylv - 01/10/2021
     */
    selectRow(value) {
      this.$emit("selectRow", value);
    }
  },
  watch: {
    listFilter: {
      deep: true,
      handler() {
        this.listFilterTable = this.listFilter;
      }
    }
  }
};
</script>
<style scoped>
@import url("../../../assets/css/base/table.css");
</style>
