import Vue from "vue";
import Vuex from "vuex";

import * as actions from "./actions";
import * as mutations from "./mutations";
import * as getters from "./getters";

Vue.use(Vuex);


const store = new Vuex.Store({
    strict: true,
    actions,
    mutations,
    getters,
    state: {
        cart: []
    }
});


store.subscribe((mutation, state) => {
    localStorage.setItem("store", JSON.stringify(state));
});

export default store;