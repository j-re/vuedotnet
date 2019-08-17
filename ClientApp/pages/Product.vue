<template>
  <div class="page">
    <product-details :product="product" />
  </div>
</template>
<script>
import ProductDetails from "../components/product/Details.vue";
export default {
  name: "product",
  components: {
    ProductDetails
  },
  data() {
    return {
      product: null
    };
  },
  methods: {
    setData(product) {
      this.product = product;
    }
  },
  beforeRouteEnter(to, from, next) {
    const slug = to.params.slug;

    fetch(`/api/products/${slug}`)
      .then(response => {
        return response.json();
      })
      .then(product => {
        next(vm=> vm.setData(product));
      });
  }
};
</script>