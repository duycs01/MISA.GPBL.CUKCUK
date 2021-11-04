<template >
  <div class="sidebar">
    <div v-for="item in menuItem" :key="item.name">
      <router-link class="sidebar-item" :to="item.path">
        <span class="icon-sidebar" :class="item.icon"></span>
        <span class="text">{{ item.name}}</span>
      </router-link>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      menuItem: [
        {
          path: "/",
          name: this.$Language.SidebarMenu.Report,
          icon: "icon-report"
        },
        {
          path: "/menu",
          name: this.$Language.SidebarMenu.Menu,
          icon: "icon-menu"
        },
        {
          path: "/employee",
          name: this.$Language.SidebarMenu.Employee,
          icon: "icon-purchase"
        },
        {
          path: "/",
          name: this.$Language.SidebarMenu.Warehouse,
          icon: "icon-warehouse"
        },
        {
          path: "/",
          name: "Quỹ tiền mặt",
          icon: "icon-cash"
        },
        {
          path: "/",
          name: "Quỹ tiền gửi",
          icon: "icon-deposits"
        },
        {
          path: "/",
          name: "Chi phí",
          icon: "icon-const"
        },
        {
          path: "/",
          name: "Khuyến mại",
          icon: "icon-promotion"
        }
      ]
    };
  }
};
</script>
<style scoped>
@import url("../../assets/css/layout/sidebar.css");
</style>