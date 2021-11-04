<template>
  <div class="pagination">
    <div class="current-page">
      <button class="prev-all" @click="onClickFirstPage" :disabled="isInFirstPage">
        <span class="icon-paging icon-page-first"></span>
      </button>
      <button class="prev" @click="onClickPreviousPage" :disabled="isInFirstPage">
        <span class="icon-paging icon-page-prev"></span>
      </button>
      <div class="horizontal"></div>
      <div class="text-page">Trang</div>
      <a-input-number
        size="small"
        style="width:40px; text-align: center;"
        id="inputNumber"
        :defaultValue="pageIndex"
        :value="pageIndex"
        :min="1"
        :max="totalPage"
        @change="onchangePageIndex($event)"
        @blur="onChangePage(pageIndex)"
        @pressEnter="onChangePage(pageIndex)"
      />
      <div class="text-page" style="margin-left:10px;">Trên {{totalPage}}</div>

      <button class="next" @click="onClickNextPage" :disabled="isInLastPage">
        <span class="icon-paging icon-page-next"></span>
      </button>
      <button class="next-all" @click="onClickLastPage" :disabled="isInLastPage">
        <span class="icon-paging icon-page-last"></span>
      </button>
      <div class="horizontal"></div>
      <button @click="btnRefresh" class="next-all">
        <span class="icon-tool icon-page-refresh"></span>
      </button>
      <a-select
        :size="`small`"
        class="select-menu-group"
        style="width: 80px;"
        :defaultValue="25"
        v-model:value="pageSize"
        dropdownClassName="select-menu-group"
        @change="onChangePageSize($event)"
      >
        <a-select-option value="10">10</a-select-option>
        <a-select-option value="25">25</a-select-option>
        <a-select-option value="50">50</a-select-option>
        <a-select-option value="100">100</a-select-option>
      </a-select>
    </div>
    <div
      v-if="totalRecord != 0"
      class="page-size"
    >Hiển thị {{pageSize *(pageIndex - 1) + 1}} - {{pageSize * pageIndex > totalRecord?totalRecord:pageSize * pageIndex }} trên {{totalRecord}} kết quả</div>
    <div
      v-if="totalRecord == 0"
      class="page-size"
    >Hiển thị {{pageSize *(pageIndex - 1)}} - {{pageSize * pageIndex > totalRecord?totalRecord:pageSize * pageIndex }} trên {{totalRecord}} kết quả</div>
  </div>
</template>
<script>
export default {
  props: {
    totalPage: {
      type: Number,
      required: true
    },
    totalRecord: {
      type: Number,
      required: true
    },
    currentPage: {
      type: Number,
      required: true
    },
    pageSize: {
      type: Number,
      required: true
    }
  },
  data() {
    return {
      pageIndex: this.currentPage
    };
  },
  computed: {
    /**
     * Xử lí khi chọn trang đầu
     * CreatedBy: duylv - 25/9/2021
     */
    isInFirstPage() {
      return this.pageIndex == 1;
    },

    /**
     * Xử lí khi chọn trang cuối
     * CreatedBy: duylv - 25/9/2021
     */
    isInLastPage() {
      return this.pageIndex == this.totalPage;
    },

    /**
     * Xử lí tổng số trang hiển thị
     * CreatedBy: duylv - 25/9/2021
     */
    startPage() {
      if (this.pageIndex == 1) {
        return 1;
      }
      if (this.pageIndex == this.totalPage) {
        return this.totalPage - this.maxVisibleButtons + 1;
      }
      return this.pageIndex - 1;
    },

    /**
     * Xử lí tổng số trang hiển thị khi đến trang cuối
     * CreatedBy: duylv - 25/9/2021
     */
    endPage() {
      return Math.min(
        this.startPage + this.maxVisibleButtons - 1,
        this.totalPage
      );
    },

    /**
     * Xử lí chọn khi load trang
     * CreatedBy: duylv - 25/9/2021
     */
    pages() {
      const range = [];
      for (let i = this.startPage; i <= this.endPage; i += 1) {
        range.push({
          name: i,
          isDisabled: i === this.pageIndex
        });
      }
      return range;
    }
  },
  methods: {
    /**
     * Hàm sử lí khi chọn page size
     * CreatedBy: duylv - 27/9/2021
     */
    onChangePageSize(pageSize) {
      this.$emit("pagechanged", {
        pageIndex: 1,
        pageSize: +pageSize
      });
    },

    /**
     * Hàm sử lí khi nhập input paging
     * CreatedBy: duylv - 25/9/2021
     */
    onchangePageIndex(value) {
      if (value == "" || value == null || value == undefined) {
        this.pageIndex = this.currentPage;
      } else {
        this.pageIndex = value;
      }
    },

    /**
     * Hàm xử lí nút quay về đầu trang
     * CreatedBy: duylv - 25/9/2021
     */
    onClickFirstPage() {
      this.pageIndex = 1;
      this.$emit("pagechanged", {
        pageIndex: this.pageIndex,
        pageSize: this.pageSize
      });
    },

    /**
     * Hàm xử lí nút lùi về 1 trang
     * CreatedBy: duylv - 25/9/2021
     */
    onClickPreviousPage() {
      this.pageIndex = this.pageIndex - 1;
      this.$emit("pagechanged", {
        pageIndex: this.pageIndex,
        pageSize: this.pageSize
      });
    },

    /**
     * Hàm xử lí chọn từng trang
     * CreatedBy: duylv - 25/9/2021
     */
    onChangePage(e) {
      this.pageIndex = e;
      this.$emit("pagechanged", {
        pageIndex: this.pageIndex,
        pageSize: this.pageSize
      });
    },

    /**
     * Hàm xử lí chuyển trang tiếp theo
     * CreatedBy: duylv - 25/9/2021
     */
    onClickNextPage() {
      if (this.pageIndex + 1 > this.totalPage) {
        this.pageIndex = this.totalPage;
      } else {
        this.pageIndex = this.pageIndex + 1;
      }
      this.$emit("pagechanged", {
        pageIndex: this.pageIndex,
        pageSize: this.pageSize
      });
    },

    /**
     * Hàm xử lí nút chuyển đến cuối trang
     * CreatedBy: duylv - 25/9/2021
     */
    onClickLastPage() {
      this.pageIndex = this.totalPage;
      this.$emit("pagechanged", {
        pageIndex: this.totalPage,
        pageSize: this.pageSize
      });
    },

    /**
     * Hàm xử lí nút refresh
     * CreatedBy: duylv - 01/10/2021
     */
    btnRefresh() {
      this.$emit("btnRefresh", {
        pageIndex: 1,
        pageSize: 25
      });
    }
  },
  watch: {
    currentPage() {
      this.pageIndex = this.currentPage;
    }
  }
};
</script>
<style scoped>
@import url("../../assets/css/base/paging.css");
.dx-fieldset{
  margin: 0;
  padding: 0;
}
</style>
