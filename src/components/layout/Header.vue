<template>
  <div class="header">
    <div class="header-menu">
      <div class="toggle"></div>
      <div class="logo"></div>
    </div>
    <div class="header-content">
      <div class="header-cotent-left">
        <div class="flex">
          <a-select
            default-value="-- Tên nhà hàng --"
            show-search
            placeholder="Select a person"
            style="width: 200px; height: 35px;"
            :filterOption="filterOption"
          >
            <template v-slot:suffixIcon>
              <div class="icon-arrow-down"></div>
            </template>
            <a-select-option value="NH001">-- Tên nhà hàng --</a-select-option>
          </a-select>
          <a-select class="filter-branch" style="width: 24px; font-size:13px !importain;">
            <template v-slot:suffixIcon>
              <div class="icon-filter-branch"></div>
            </template>
          </a-select>
        </div>
      </div>
      <div class="header-content-right">
        <a-select
          default-value="Vietnamese"
          show-search
          style="width: 150px;"
          :filterOption="filterOption"
        >
          <template v-slot:suffixIcon>
            <div class="icon-arrow-down" style="margin-top: -5px;"></div>
          </template>
          <a-select-option
            v-for="(item, index) in language"
            :key="index"
            :value="item.key"
          >{{item.label}}</a-select-option>
        </a-select>
        <div class="icon-world"></div>
        <div class="icon-contact">
          <img src="../../assets/images/ic_support.svg" alt />
        </div>
        <div class="account">
          <div class="avartar">
            <div class="icon-user"></div>
          </div>
          <div class="user-name">Lê Văn Duy</div>
          <div class="icon-arrow-down"></div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      language: [
        {
          label: this.$Language.ComboboxLanguage.Vietnamese,
          key: "Vietnamese"
        },
        {
          label: this.$Language.ComboboxLanguage.English,
          key: "English"
        }
      ]
    };
  },
  methods: {
    filterOption(input, option) {
      return option.props.value.toLowerCase().indexOf(input.toLowerCase()) >= 0;
    }
  }
};
</script>
<style scoped>
@import url("../../assets/css/layout/header.css");
</style>
