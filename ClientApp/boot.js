import Vue from 'vue';
import BoostrapVue from 'bootstrap-vue';
import VueToastr from '@deveodk/vue-toastr';
import '@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css';
import axios from "axios";
import router from "./router";
import VeeValidate from "vee-validate";
import "./helpers/validation";
import "./helpers/interceptors";

Vue.use(BoostrapVue);
Vue.use(VueToastr, {
    defaultPosition: 'toast-bottom-left'
});
Vue.use(VeeValidate);


import store from "./store";

import { currency, date } from "./filters";



Vue.filter("date", date);
Vue.filter("currency", currency);

const initialStore = localStorage.getItem("store");

if (initialStore) {
    store.commit("initialise", JSON.parse(initialStore));
    if (store.getters.isAuthenticated) {
        axios.defaults.headers.common["Authorization"] = `Bearer ${
            store.state.auth.access_token
            }`;
    }
}



new Vue({
    el: '#app-root',
    router: router,
    store,
    render: h => h(require('./components/App.vue'))
});