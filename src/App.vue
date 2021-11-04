<template>
  <div id="nav">
    <Header />
    <div class="flex">
      <sidebar />
      <content />
    </div>
  </div>
</template>
<script>
import Content from "./components/layout/Content.vue";
import Header from "./components/layout/Header.vue";
import Sidebar from "./components/layout/Sidebar.vue";
export default {
  components: { Sidebar, Header, Content }
};
</script>
<style>

</style>
