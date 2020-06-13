<template>
  <div v-if="post" class="post-detail container">
    <div class="btnGroup">
      <router-link :to="{name: 'Index'}">
        <div class="btn blue">뒤로가기</div>
      </router-link>
      <div class="btn-modify">
        <router-link :to="{name: 'EditPost'}">
          <div class="btn green">수정</div>
        </router-link>
        <div class="field center-align">
          <button v-on:click="DeletePost" class="btn pink">삭제</button>
        </div>
      </div>
    </div>
    <form @submit.prevent="EditPost">
      <div class="field title">
        <label>제목 :</label>
        <div>{{post.title}}</div>
      </div>
      <div class="field category">
        <label>카테고리 :</label>
        <div>{{post.category.categName}}</div>
      </div>
      <div class="field content">
        <label>의뢰내용 :</label>
        <div>{{post.content}}</div>
      </div>
      <div class="field location">
        <label>지역 :</label>
        <div>{{post.location}}</div>
      </div>
      <div class="tag-list">
        <label for="add-tagName">태그 :</label>
        <div class="tagName-chip" v-for="(tagName, index) in post.tags" :key="index">
          <div class="label">{{tagName.tagName}}</div>
        </div>
      </div>
      <Reply :replies="post.replies" v-on:AddReply="AddReply" v-on:DeleteReply="DeleteReply" />
      <!-- <reply :val="post" /> -->
    </form>
  </div>
</template>

<script>
// .map() .filter() .sort() .forEach() .flat() .reduce() ...
import Reply from "./Reply";
export default {
  name: "PostDetail",
  components: {
    // Index: Index
    Reply
  },
  data() {
    return {
      post: null,
      title: null,
      content: null,
      tagName: null,
      tags: [],
      replies: [],
      category: {},
      categName: null,
      location: null,
      feedback: null,
      result: null,
      replyContent: null
    };
  },
  created() {
    this.$axios
      .get("https://localhost:44371/api/post/" + this.$route.params.post_id)
      .then(result => {
        this.post = result.data;
      });
    console.log(this.post);
  },
  methods: {
    GetPostById(postId) {
      this.$axios
        .get("https://localhost:44371/api/post/" + postId)
        .then(result => {
          this.post = result.data;
        });
    },
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
              console.log(error.response);
            });
          });
      } else {
        this.feedback = "제목을 입력해 주십시오.";
      }
    },
    AddReply(content, onSuccess) {
      var _this = this;
      if (content) {
        this.feedback = null;
        this.$axios
          .post(
            "https://localhost:44371/api/post/" +
              this.$route.params.post_id +
              "/reply/",
            {
              content
            },
            { "content-type": "text/json" }
          )
          .then(response => {
            // function () {}
            // () => {}
            console.log("Add reply response : " + response.data.id);
            this.post.replies.content = null;
            console.log(
              "Check reply content is null : " + this.post.replies.content
            );
            // _this.CrearReply();
            onSuccess();
            this.GetPostById(response.data.id); // 이해 안감. 왜지?
          });
      } else {
        this.feedback = "댓글 내용을 입력해 주십시오.";
      }
    },
    DeleteReply(replyObj) {
      var _this = this;
      console.log(replyObj);
      this.$axios
        .delete(
          "https://localhost:44371/api/post/" +
            this.$route.params.post_id +
            "/reply/" +
            replyObj.id,
          { "content-type": "text/json" }
        )
        .then(function(response) {
          console.log(response.data);
          _this.GetPostById(response.data.id); // 이해 안감. 왜지?
        });
    },
    CrearReply() {
      document.getElementById("reply-input").value = "";
    }
  }
};
</script>

<style scoped>
.post-detail {
  margin-top: 60px;
  margin-bottom: 100px;
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

.container-reply {
  border-bottom: 2px solid #dfdfdf;
  display: inline-grid;
  grid-template-columns: 1fr 9fr 5fr 1fr;
}
.container-reply p {
  margin: 10px 10px 5px 5px;
}

.btnGroup {
  display: flex;
  justify-content: space-between;
}

.btn.green {
  margin-right: 20px;
}

.btn-modify {
  display: inline-flex;
  margin-bottom: 20px;
}

.tag-list {
  display: inline-flex;
  margin-top: 10px;
  margin-bottom: 15px;
  vertical-align: middle;
}

.tag-list label {
  margin-top: 5px;
}

.tagName-chip {
  margin: 0;
  margin-left: 15px;
}

/* Reply props */

/* .btn-reply-add,
.btn-reply-cancel {
  visibility: hidden;
}

.input-add-reply:focus ~ .btn-reply-add {
  visibility: visible;
} */

.input-add-reply:focus ~ .btn-reply-cancel {
  visibility: visible;
}
</style>