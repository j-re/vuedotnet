<template>
 <div>
      <b-form-radio v-model="rselected" name="stocklevel-radio" value="in" @change="filter">In Stock</b-form-radio>
      <b-form-radio v-model="rselected" name="stocklevel-radio" value="out" @change="filter" >Out of Stock</b-form-radio>
      <b-form-radio v-model="rselected" name="stocklevel-radio" value="all" @change="filter">All</b-form-radio>
     </div>
</template>

<script>
export default {
  name: "radio-filter",
  data() {
    return {
      rselected: "all"
    };
  },
  props: {
    queryKey: {
      type: String,
      required: true
    }
  },
  computed: {
    selected() {
      return this.$route.query[this.queryKey] || "";
    }
  },
  methods: {
    clear() {
      if (this.selected.length) {
        let query = Object.assign({}, this.$route.query);
        delete query[this.queryKey];

        this.$router.push({ query: query });
      }
    },
    filter(e) {
      let query = Object.assign({}, this.$route.query);

      if (e.trim()) {
        query.stocklevel = e;
      } else {
        delete query.stocklevel;
      }

      this.$router.push({ query: query });
    }
  }
};
</script>

<style>
</style>

