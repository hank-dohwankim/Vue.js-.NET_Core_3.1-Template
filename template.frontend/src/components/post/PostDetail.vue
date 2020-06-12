<template>
  <div v-if="post" class="post-detail container">
    <div class="btnGroup">
      <router-link :to="{name: 'Index'}">
        <div v-on:click="Index" class="btn blue">뒤로가기</div>
      </router-link>
      <div class="btn-modify">
        <router-link :to="{name: 'EditPost'}">
          <div v-on:click="EditPost" class="btn green">수정</div>
        </router-link>
        <div class="field center-align">
          <button v-on:click="DeletePost" class="btn pink">삭제</button>
        </div>
      </div>
    </div>
    <form @submit.prevent="EditPost">
      <div class="field title">
        <label for="title">제목 :</label>
        <input type="text" name="title" v-model="post.title" />
      </div>
      <div class="field category">
        <label for="category">카테고리 :</label>
        <input type="text" name="category" v-model="post.category.categName" />
      </div>
      <div class="field content">
        <label for="content">의뢰내용 :</label>
        <input type="text" name="content" v-model="post.content" />
      </div>
      <div class="field location">
        <label for="location">지역 :</label>
        <input type="text" name="location" v-model="post.location" />
      </div>
      <div class="tag-list">
        <label for="add-tagName">태그 :</label>
        <div class="tagName-chip" v-for="(tagName, index) in post.tags" :key="index">
          <div class="label">{{tagName.tagName}}</div>
        </div>
      </div>
      <p>댓글 {{post.replies.length}}개</p>
      <div class="field-reply">
        <div class="btn-group-reply">
          <input
            id="reply-input"
            class="input-add-reply"
            type="text"
            name="add-reply"
            placeholder="댓글 추가..."
            v-model="post.replies.content"
          />
          <button type="button" class="btn-reply-cancel" v-on:click="CrearReply()">취소</button>
          <button type="button" class="btn-reply-add" v-on:click="AddReply(replyContent)">댓글</button>
        </div>
      </div>
      <!-- <div class="repy-user-info">
            <p>UserId</p>
      </div>-->
      <div class="container-reply" v-for="(reply, index) in post.replies" :key="index">
        <p class="reply-userId">UserId</p>
        <p class="reply-content">{{reply.content}}</p>
        <p class="reply-createdOn">{{reply.creatdOn}}</p>
        <p class="btn-reply-delete" v-on:click="DeleteReply(post.replies[index])">
          <i class="material-icons">delete</i>
        </p>
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
    // Index: Index
    // reply: reply
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
    console.log(post);
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
              consoe.log(error.response);
            });
          });
      } else {
        this.feedback = "제목을 입력해 주십시오.";
      }
    },
    AddReply() {
      var _this = this;
      if (this.post.replies.content) {
        this.feedback = null;
        this.$axios
          .post(
            "https://localhost:44371/api/post/" +
              this.$route.params.post_id +
              "/reply/",
            {
              content: this.post.replies.content
            },
            { "content-type": "text/json" }
          )
          .then(function(response) {
            console.log("Add reply response : " + response.data.id);
            _this.post.replies.content = null;
            console.log(
              "Check reply content is null : " + _this.post.replies.content
            );
            _this.CrearReply();
            _this.GetPostById(response.data.id); // 이해 안감. 왜지?
          });
      } else {
        this.feedback = "댓글 내용을 입력해 주십시오.";
      }
    },
    DeleteReply: function(replyObj) {
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
.btnGroup {
  text-align: center;
  display: inline;
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
  display: inline-flex;
  margin-bottom: 20px;
}
.btnGroup div {
  margin-left: 10px;
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
.btn-group-reply .btn-reply-add,
.btn-reply-cancel {
  float: right;
  margin: 10px 0px 20px 15px;
}

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