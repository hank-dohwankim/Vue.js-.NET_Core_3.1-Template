<template>
  <div class="field reply">
    <label for="reply">댓글 :</label>
    <div class="container-reply">
      <div class="reply-list" v-for="(reply, index) in post.replies" :key="index">
        <div class="label">{{reply.content}}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Reply"
};
</script>

<style scoped>
</style>