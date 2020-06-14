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

<style></style>
