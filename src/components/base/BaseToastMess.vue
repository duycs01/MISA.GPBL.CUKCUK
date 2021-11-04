<template>
  <div class="toast-mess">
    <div class="content-mess" :class="{'border-red' : messageDetail.icon == `icon-error`}">
      <div :class="messageDetail.icon" class="icon-tool"></div>
      <div class="text">{{messageDetail.mess}}</div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    messageDetail: { type: Object }
  },
  components: {}
};
</script>
<style scoped>
@import url("../../assets/css/base/toastMess.css");
</style>