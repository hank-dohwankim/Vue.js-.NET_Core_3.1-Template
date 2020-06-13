<template>
  <div class="index-container">
    <!-- <ul class="btnList container">
      <li>데스크탑</li>
      <li>웹페이지</li>
      <li>모바일</li>
      <li>
        
      </li>
    </ul>-->
    <div class="container-btn">
      <div class="btn-wrapper">
        <router-link :to="{name: 'AddPost'}">
          <div id="btnAddPost" class="btn waves-effect waves-light">
            Add New Post
            <i class="material-icons right">send</i>
          </div>
        </router-link>
      </div>
    </div>
    <div class="index container">
      <div class="card" v-for="post in posts" :key="post.id">
        <router-link :to="{name: 'PostDetail', params:{post_id:post.id}}">
          <div class="card-content">
            <!-- <a href="#" data-target="dropdown1">
          <i class="material-icons edit" @click="editPost(post.id)">edit</i>
        </a>
            <i class="material-icons delete" @click="deletePost(post.id)">delete</i>-->
            <h4 class="category indigo-text">{{ post.category.categName }}</h4>
            <h2 class="title indigo-text">{{ post.title }}</h2>
            <p class="indigo-text">{{ post.content }}</p>
            <div class="location">
              <i class="material-icons">location_on</i>
              <p>{{post.location}}</p>
            </div>
            <ul class="tags">
              <li v-for="(tag, index) in post.tags" :key="index">
                <span class="chip">{{ tag.tagName }}</span>
              </li>
            </ul>
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Index",
  data() {
    return {
      posts: []
    };
  },
  methods: {},
  mounted() {
    this.$axios.get("https://localhost:44371/api/post").then(result => {
      console.log(result);
      this.posts = result.data;
    });
  }
};
</script>

<style scoped>
.index {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-gap: 30px;
  margin-top: 60px;
  margin-bottom: 100px;
}

.index .card {
  cursor: pointer;
}

.index .title {
  font-size: 1.8em;
  margin-top: 20px;
  text-align: left;
}

.index .category {
  font-size: 1em;
  text-align: right;
  margin-top: 0;
}

.index .tags {
  margin: 10px auto;
  margin-top: 10px;
  margin-bottom: -10px;
}
.index .tags li {
  display: inline-block;
}
.index .edit {
  position: absolute;
  top: 20px;
  right: 40px;
  cursor: pointer;
  color: #aaa;
}
.index .delete {
  position: absolute;
  top: 20px;
  right: 10px;
  cursor: pointer;
  color: #aaa;
}

.btnList #btnAddPost {
  margin: 30px 0px 20px 0px;
  float: right;
}

.location {
  margin-top: 30px;
  display: inline-block;
  text-transform: uppercase;
  display: inline-flex;
}
.container-btn {
  margin-top: 50px;
  width: 100%;
  text-align: center;
}
.btn-wrapper {
  width: 70%;
  display: inline-block;
  text-align: right;
}

.index-container {
  font-family: Arial, Helvetica, sans-serif;
  line-height: 1.4em;
  max-width: 1280px;
  margin: auto;
}
</style>
