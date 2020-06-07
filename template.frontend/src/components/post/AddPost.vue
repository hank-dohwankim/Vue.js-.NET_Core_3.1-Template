<template>
  <div class="add-post container">
    <form @submit.prevent="AddPost">
      <div class="field title">
        <label for="title">제목 :</label>
        <input type="text" name="title" v-model="title" />
      </div>
      <div class="field content">
        <label for="content">의뢰내용 :</label>
        <input type="text" name="content" v-model="content" />
      </div>
      <div v-for="(tag, index) in tags" :key="index">
        <label for="tag"></label>
      </div>
      <div class="field add-tag">
        <label for="add-tag">태그 :</label>
        <input
          type="text"
          name="add-tag"
          @keydown.space.prevent="AddTag"
          @keydown.enter.prevent="AddTag"
          @keydown.tab.prevent="AddTag"
          v-model="tag"
        />
        <div class="container-tags">
          <div class="tag-chip" v-for="(tag, index) in tags" :key="index">
            <div class="label">{{tag}}</div>
            <div class="btn-remove" @click="tags.splice(index, 1)">X</div>
          </div>
        </div>
      </div>
      <div class="field center-align">
        <p v-if="feedback" class="red-text">{{feedback}}</p>
        <button class="btn pink">제출하기</button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "AddPost",
  data() {
    return {
      title: null,
      content: null,
      tag: null,
      feedback: null,
      tags: []
    };
  },
  created() {
    console.log(
      navigator.geolocation.getCurrentPosition(console.log, console.error)
    );
  },
  methods: {
    AddPost() {
      console.log(this.title, this.content, this.tags);
    },
    AddTag() {
      if (this.tag) {
        this.tags.push(this.tag);
        this.tags = this.tags.filter(
          (el, index, arr) => arr.indexOf(el) === index
        );
        // arr = [1,1,2,3,1]
        // index : [0,1,2,3,4]
        // arr.indexOf(el): [0,0,2,3,0]
        this.tag = null;
        this.feedback = null;
      } else {
        this.feedback = "태그를 입력하세요.";
      }
    }
  }
};
</script>

<style>
.add-post {
  margin-top: 60px;
  padding: 20px;
  max-width: 500px;
}
.tag-chip {
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
</style>