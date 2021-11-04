<template>
  <div class></div>
  <div class="table-scroll">
    <div class="table">
      <div class="thead">
        <div class="tr">
          <div class="th" style="width:38px !important">
            <div class="text">
              <base-checkbox
                :checked="filterCheckAll()"
                @change="onCheckAll($event.target.checked)"
              />
            </div>
          </div>
          <div class="th" style="width:465px;">
            <div class="text">{{language.TitleModal.ChooseServicePreferences}}</div>
          </div>
          <div class="th" :style="listServiceHobby.length >= 10? 'width:193px;':'width:175px;'">
            <div class="text">{{language.TitleModal.CollectMore}}</div>
          </div>
        </div>
      </div>
      <div class="tbody">
        <div v-for="(item,index) in listServiceHobby" :key="index" class="tr">
          <div class="td" style="width:38px">
            <base-checkbox
              :checked="indexOfServiceHobby(item) !== -1? true :false"
              @change="onChange(item)"
            />
          </div>
          <div class="td" style="width:465px;">{{item.ServiceHobbyName}}</div>
          <div
            class="td"
            style="text-align:right; width:175px;"
          >{{$FormatData.formatMoney(item.CollectMore)}}</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import BaseCheckbox from "../../../base/BaseCheckbox.vue";
export default {
  components: { BaseCheckbox },
  props: {
    listServiceHobbyPaging: {
      type: Array,
      default: () => []
    },
    listServiceHobbyTable: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      language: this.$Language,
      listServiceHobby: [],
      listChooseServiceHobby: []
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
     * Sự kiện checkbox
     * CreatedBy: duylv - 01/10/2021
     */
    onChange(value) {
      try {
        var rowIndex = this.indexOfServiceHobby(value);
        if (rowIndex !== -1) {
          this.listChooseServiceHobby.splice(rowIndex, 1);
        } else {
          this.listChooseServiceHobby.push(value);
        }
        this.$emit("btnChooseServiceHobby", this.listChooseServiceHobby);
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Sự kiện checkbox all
     * CreatedBy: duylv - 10/10/2021
     */
    onCheckAll(checked) {
      try {
        if (checked) {
          this.listChooseServiceHobby = JSON.parse(
            JSON.stringify(this.listServiceHobby)
          );
        } else {
          this.listChooseServiceHobby = [];
        }
        this.$emit("btnChooseServiceHobby", this.listChooseServiceHobby);
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Kiêm tra check all
     */
    filterCheckAll() {
      var isValid = true;
      var check = true;
      this.listServiceHobby.forEach(item => {
        check = this.indexOfServiceHobby(item) == -1 ? false : true;
        if (!check) {
          isValid = false;
        }
      });
      return isValid;
    },

    /**
     * Tìm vị trí của dịch vụ yêu thích
     * CreatedBy: duylv - 10/10/2021
     */
    indexOfServiceHobby(value) {
      try {
        return this.listChooseServiceHobby
          .map(function(item) {
            return item.ServiceHobbyId;
          })
          .indexOf(value.ServiceHobbyId);
      } catch (error) {
        console.log(error);
      }
    }
  },
  watch: {
    listServiceHobbyPaging: {
      deep: true,
      handler() {
        this.listServiceHobby = this.listServiceHobbyPaging;
      }
    },
    listServiceHobbyTable: {
      deep: true,
      handler() {
        this.listChooseServiceHobby = this.listServiceHobbyTable;
      }
    }
  }
};
</script>
<style scoped>
@import url("../../../../assets/css/base/table.css");
</style>
