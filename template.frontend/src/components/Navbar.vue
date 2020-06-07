<template>
  <nav class="nav-extended">
    <div class="nav-wrapper">
      <ul>
        <li>
          <router-link :to="{name: 'Index'}">
            <!-- <router-link path="/"> -->
            <div>Home</div>
          </router-link>
        </li>
      </ul>
      <div class="brand-logo center">
        <ul id="nav-mobile" class="right hid-on-med-and-down">
          <li>
            <a href="#">Post</a>
          </li>
          <li>
            <a href="#">Developer</a>
          </li>
          <li>
            <a href="#">Category</a>
          </li>
        </ul>
      </div>
      <ul id="nav-mobile" class="right hid-on-med-and-down">
        <li>
          <a href="#">Login</a>
        </li>
        <li>
          <a href="#">Register</a>
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

