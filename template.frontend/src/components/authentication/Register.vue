<template>
  <div id="container">
    <div class="form-wrap">
      <form>
        <!-- <div class="form-group">
          <label for="first-name">First Name</label>
          <input type="text" name="firstName" id="first-name" />
        </div>
        <div class="form-group">
          <label for="last-name">Last Name</label>
          <input type="text" name="lastName" id="last-name" />
        </div> -->
        <div class="form-group">
          <label for="user-name">User Name</label>
          <input type="text" name="userName" id="user-name" />
        </div>
        <div class="form-group">
          <label for="email">Email</label>
          <input type="email" name="email" id="email" />
        </div>
        <div class="form-group">
          <label for="password">Password</label>
          <input type="password" name="password" id="password" />
        </div>
        <div class="form-group">
          <label for="password2">Confirm Password</label>
          <input type="password" name="pasword2" id="password2" />
        </div>
        <button type="submit" class="btn">Sign Up</button>
        <p class="bottom-text">
          <!-- By clicking the Sign Up button, you agree to our
          <a href="#">Terms & Conditions</a> and
          <a href="#">Privacy Policy</a> -->
        </p>
      </form>
    </div>
    <footer>
      <p>
        Already have an account?
        <router-link :to="{ name: 'Login' }">
          Login Here
        </router-link>
      </p>
    </footer>
  </div>
</template>

<script>
export default {
  name: "Register"
};
</script>

<style scoped>
#container {
  margin: 30px auto;
  max-width: 400px;
  padding: 20px;
}

.form-wrap {
  background: #fff;
  padding: 15px 25px;
  color: #333;
}

.form-wrap p {
  text-align: center;
}

.form-wrap .form-group {
  margin-top: 15px;
}

.form-wrap .form-group label {
  display: block;
  color: #666;
}

.form-wrap .form-group input {
  border: #ddd 1px solid;
  border-radius: 5px;
}

.form-wrap button {
  display: block;
  width: 100%;
  margin-top: 20px;
}

.form-wrap .bottom-text {
  margin-top: 20px;
}

footer {
  text-align: center;
  margin-top: 10px;
}
</style>
