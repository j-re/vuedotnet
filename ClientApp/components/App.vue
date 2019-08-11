<template>
  <div>
    <h1>Welcome to Hands on Vue.js with ASP.NET Core!</h1>
    <p>The time is: {{ time }}</p>
    <p>The current users of our system are:</p>
    <ul>
      <li v-for="user in users" :key="user.userName">{{ user.fullName }} - {{ user.userName }}</li>
    </ul>
    <product-list />
  </div>
</template>
<script>
import ProductList from "./products/List.vue"
export default {
  name: "app",
  components:{
    //ProductList: ProductList
    ProductList //es6 support for keyvalues of the samename
  },
  data() {
    return {
      time: new Date().toString(),
      users: []
    };
  },
  mounted() {
    fetch("/api/users")
      .then(response => {
        return response.json();
      })
      .then(data => {
        this.users = data;
      });
  }
};
</script>