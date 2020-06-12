<template>
  <nav class="nav-extended">
    <div class="nav-wrapper">
      <div class="brand-logo center">
        <ul id="nav-mobile" class="right hid-on-med-and-down">
          <router-link :to="{name: 'Index'}">
            <!-- <router-link path="/"> -->
            <div>Home</div>
          </router-link>
        </ul>
      </div>
      <ul id="nav-mobile" class="right hid-on-med-and-down">
        <li>
          <router-link :to="{name: 'Login'}">
            <div>Login</div>
          </router-link>
        </li>
        <li>
          <router-link :to="{name: 'Register'}">
            <!-- <router-link path="/"> -->
            <div>Register</div>
          </router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: "Navbar"
};
</script>

<style scoped>
</style>

