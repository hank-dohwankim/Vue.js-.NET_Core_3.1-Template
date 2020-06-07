<template>
  <div v-if="post" class="edit-post container">
    <h2>게시물 [ {{post.title}} ] 수정</h2>
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
        <input
          type="text"
          name="add-tagName"
          @keydown.space.prevent="AddTag"
          @keydown.enter.prevent="AddTag"
          @keydown.tab.prevent="AddTag"
          v-model="tagName"
        />
        <div class="container-tags">
          <div class="tagName-chip" v-for="(tagName, index) in post.tags" :key="index">
            <div class="label">{{tagName.tagName}}</div>
            <div class="btn-remove" @click="post.tags.splice(index, 1)">X</div>
          </div>
        </div>
      </div>
      <div class="btnGroup">
        <div class="field center-align">
          <p v-if="feedback" class="red-text">{{feedback}}</p>
          <div v-on:click="EditPost" class="btn green">수정</div>
        </div>
        <div class="field center-align">
          <p v-if="feedback" class="red-text">{{feedback}}</p>
          <div v-on:click="DeletePost" class="btn pink">삭제</div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "EditPost",
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
        this.tags = post.tags;
        console.log(this.tags);
      });
  },
  methods: {
    EditPost() {
      if (this.post.title) {
        this.feedback = null;
        console.log(this.title, this.content, this.tags);
        this.$axios
          .patch(
            "https://localhost:44371/api/post/" + this.$route.params.post_id,
            {
              id: this.post.id,
              title: this.post.title,
              content: this.post.content
            },
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
    },
    AddTag() {
      if (this.tagName) {
        this.tags.push(this.tagName);
        this.tags = this.tags.filter(
          (el, index, arr) => arr.indexOf(el) === index
          // this.feedback = "d";
        );
        // arr = [1,1,2,3,1]
        // index : [0,1,2,3,4]
        // arr.indexOf(el): [0,0,2,3,0]
        this.tagName = null;
        this.feedback = null;
      } else {
        this.feedback = "태그를 입력하세요.";
      }
    }
  }
};
</script>

<style scoped>
.edit-post {
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