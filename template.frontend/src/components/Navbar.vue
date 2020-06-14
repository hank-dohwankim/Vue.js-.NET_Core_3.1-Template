<template>
  <div>
    <nav class="nav-extended">
      <div class="nav-wrapper">
        <div class="brand-logo center">
          <ul id="nav-mobile" class="right hid-on-med-and-down">
            <router-link :to="{ name: 'Index' }">
              <!-- <router-link path="/"> -->
              <div><i class="material-icons">home</i>Home</div>
            </router-link>
          </ul>
        </div>
        <a href="#" data-target="mobile-demo" class="sidenav-trigger">
          <i class="material-icons">menu</i>
        </a>
        <ul class="right hide-on-med-and-down">
          <li>
            <router-link :to="{ name: 'Login' }">
              <div>Login</div>
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'Register' }">
              <!-- <router-link path="/"> -->
              <div>Register</div>
            </router-link>
          </li>
        </ul>
      </div>
    </nav>
    <ul class="sidenav" id="mobile-demo">
      <li>
        <router-link :to="{ name: 'Login' }">
          <div>Login</div>
        </router-link>
      </li>
      <li>
        <router-link :to="{ name: 'Register' }">
          <!-- <router-link path="/"> -->
          <div>Register</div>
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
document.addEventListener("DOMContentLoaded", function() {
  var elems = document.querySelectorAll(".sidenav");
  var instances = M.Sidenav.init(elems);
});
export default {
  name: "Navbar"
};
</script>

<style scoped></style>
