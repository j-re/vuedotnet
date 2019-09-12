<template>
  <b-container fluid class="page">
    <b-row>
      <b-col cols="3">
        <filters v-if="filters.brands.length" :filters="filters" />
      </b-col>
      <b-col cols="9">
        <div class="mt-4 flex">
          <search-bar class="search" />
          <product-sort class="ml-4" />
        </div>
        <product-list :products="sortedProducts" />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import axios from "axios";
import Filters from "../components/catalogue/Filters.vue";
import SearchBar from "../components/catalogue/SearchBar.vue";
import ProductSort from "../components/catalogue/ProductSort.vue";
import ProductList from "../components/catalogue/ProductList.vue";

export default {
  name: "catalogue",
  components: {
    Filters,
    SearchBar,
    ProductSort,
    ProductList
  },
  computed: {
    filters() {
      return this.$store.state.filters;
    },
    sortedProducts() {
      return this.$store.getters.sortedProducts;
    }
  },
  beforeRouteEnter(to, from, next) {
    axios
      .all([
        axios.get("/api/products", { params: to.query }),
        axios.get("/api/filters")
      ])
      .then(
        axios.spread((products, filters) => {
          next(vm => vm.setData(products.data, filters.data));
        })
      );
  },
  beforeRouteUpdate(to, from, next) {
    axios.get("/api/products", { params: to.query }).then(response => {
      this.products = response.data;
      next();
    });
  }
};
</script>

<style lang="scss" scoped>
.flex {
  display: flex;
  flex-direction: row;

  .search {
    flex: 1;
  }
}
</style>
