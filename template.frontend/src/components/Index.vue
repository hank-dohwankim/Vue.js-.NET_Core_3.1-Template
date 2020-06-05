<template>
  <div class="index container">
    <div class="card" v-for="post in posts" :key="post.id">
      <div class="card-content">
        <!-- <a href="#" data-target="dropdown1">
          <i class="material-icons edit" @click="editPost(post.id)">edit</i>
        </a>
        <i class="material-icons delete" @click="deletePost(post.id)">delete</i>-->
        <h4 class="category indigo-text">{{ post.category }}</h4>
        <h2 class="title indigo-text">{{ post.title }}</h2>
        <p class="indigo-text">{{ post.content }}</p>
        <ul class="tags">
          <li v-for="(tag, index) in post.tags" :key="index">
            <span class="chip">{{ tag }}</span>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Index",
  data() {
    return {
      posts: []
    };
  },
  methods: {
    deletePost(id) {
      this.posts = this.posts.filter(post => {
        return post.id != id;
      });
    }
  },
  mounted() {
    axios.get("https://localhost:44371/api/post").then(result => {
      console.log(result);
      this.posts = result.data;
    });
  }
};
</script>

<style>
.index {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-gap: 30px;
  margin-top: 60px;
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
  margin: 30px auto;
  margin-bottom: 0;
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
</style>
