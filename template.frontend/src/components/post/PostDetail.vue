<template>
  <div v-if="post" class="post-detail container">
    <div class="btnGroup">
      <router-link :to="{name: 'Index'}">
        <div class="field center-align">
          <div v-on:click="Index" class="btn blue">뒤로가기</div>
        </div>
      </router-link>
      <router-link :to="{name: 'EditPost'}">
        <div class="field center-align">
          <div v-on:click="EditPost" class="btn green">수정</div>
        </div>
      </router-link>
      <div class="field center-align">
        <p v-if="feedback" class="red-text">{{feedback}}</p>
        <div v-on:click="DeletePost" class="btn pink">삭제</div>
      </div>
    </div>
    <form @submit.prevent="EditPost">
      <div class="field title">
        <label for="title">제목 :</label>
        <input type="text" name="title" v-model="post.title" />
      </div>
      <div class="field content">
        <label for="content">의뢰내용 :</label>
        <input type="text" name="content" v-model="post.content" />
      </div>
      <div v-for="(location, index) in locations" :key="index">
        <div class="field add-location">
          <label for="add-location">지역 :</label>
          <input
            type="text"
            name="location"
            @keydown.space.prevent="AddLocation"
            @keydown.enter.prevent="AddLocation"
            @keydown.tab.prevent="AddLocation"
            v-model="locations[index]"
          />
        </div>
      </div>
      <div v-for="(tagName, index) in post.tags" :key="index">
        <label for="tagName"></label>
      </div>
      <div class="field add-tagName">
        <label for="add-tagName">태그 :</label>
        <div class="container-tags">
          <div class="tagName-chip" v-for="(tagName, index) in post.tags" :key="index">
            <div class="label">{{tagName.tagName}}</div>
          </div>
        </div>
      </div>
      <div class="field reply">
        <label for="reply">댓글 :</label>
        <div class="container-reply">
          <div class="reply-list" v-for="(reply, index) in post.replies" :key="index">
            <div class="label">{{reply.content}}</div>
          </div>
        </div>
      </div>
      <!-- <reply :val="post" /> -->
    </form>
  </div>
</template>

<script>
import reply from "./Reply";
export default {
  name: "PostDetail",
  components: {
    reply: reply
  },
  data() {
    return {
      post: null,
      title: null,
      content: null,
      tagName: null,
      tags: [],
      location: null,
      locations: [],
      feedback: null
    };
  },
  created() {
    this.$axios
      .get("https://localhost:44371/api/post/" + this.$route.params.post_id)
      .then(result => {
        this.post = result.data;
        this.replies = post.replies;
        this.tags = post.tags;
        console.log(this.replies);
      });
  },
  methods: {
    DeletePost() {
      if (this.post.title) {
        this.feedback = null;
        console.log(this.title, this.content, this.tags);
        this.$axios
          .delete(
            "https://localhost:44371/api/post/" + this.$route.params.post_id,
            { "content-type": "text/json" }
          )
          .then(() => {
            this.$router.push({ name: "Index" }).catch(err => {
              consoe.log(error.response);
            });
          });
      } else {
        this.feedback = "제목을 입력해 주십시오.";
      }
    }
  }
};
</script>

<style scoped>
.post-detail {
  margin-top: 60px;
  padding: 20px;
  max-width: 500px;
}
.tagName-chip {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  margin-right: 10px;
  margin-bottom: 10px;
  padding: 5px;
  background-color: #dfdfdf;
  border-radius: 20px;
}
.label {
  padding: 0px 5px;
}
.btn-remove {
  cursor: pointer;
  padding: 5px;
  border-radius: 50%;
  width: 20px;
  height: 20px;
  box-sizing: border-box;
  background-color: #585858;
  color: #fff;
  display: inline-flex;
  align-items: center;
  justify-content: center;
}
.btnGroup {
  text-align: center;
  display: inline;
}
</style>