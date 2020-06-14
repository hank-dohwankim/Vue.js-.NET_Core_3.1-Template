<template>
  <div id="app">
    <Navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "./components/Navbar";
import M from "materialize-css";

export default {
  name: "App",
  components: { Navbar },
  mounted() {
    M.AutoInit();
  }
};
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

body {
  font-family: "Raleway", sans-serif;
  background: #f5f5f5;
  line-height: 1.8;
}

a {
  text-decoration: none;
}
</style>
