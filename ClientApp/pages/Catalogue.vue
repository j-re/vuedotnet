<template>
    <product-list :products="products" />
</template>

<script>
    import ProductList from "../components/catalogue/productlist.vue";
    export default {
        name: "catalogue",
        data() {
            return {
                products: []
            }
        },
        mounted() {
            fetch("/api/products")
                .then(response => {
                    return response.json();
                })
                .then(products => {
                    this.products = products;
                });
        },

        components: {
            ProductList
        }
    }
</script>

<style>
</style>