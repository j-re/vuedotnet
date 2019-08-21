import Vue from 'vue';
import VueRouter from 'vue-router';
import BoostrapVue from 'bootstrap-vue';
import NProgress from "nprogress";
import VueToastr from '@deveodk/vue-toastr';
import '@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css';


Vue.use(VueRouter);
Vue.use(BoostrapVue);
Vue.use(VueToastr, {
    defaultPosition: 'toast-bottom-left'
});

//import page components
import Catalogue from "./pages/Catalogue.vue";
import Product from "./pages/Product.vue";
import Cart from "./pages/Cart.vue";
import store from "./store";
import { currency } from "./filters"

Vue.filter("currency", currency);

const routes = [
    { path: "/products", component: Catalogue },
    { path: "/products/:slug", component: Product },
    { path: "/cart", component: Cart },
    { path: "*", redirect: "/products" }
];

const router = new VueRouter({ mode: "history", routes: routes });
router.beforeEach((to, from, next) => {
    NProgress.start();
    next();
});

router.afterEach((to, from) => {
    NProgress.done();
});

new Vue({
    el: '#app-root',
    router: router,
    store,
    render: h => h(require('./components/App.vue'))
});
