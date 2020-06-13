<template>
  <div>
    <p>댓글 {{replies.length}}개</p>
    <div class="field-reply">
      <div class="btn-group-reply">
        <input
          id="reply-input"
          class="input-add-reply"
          type="text"
          name="add-reply"
          placeholder="댓글 추가..."
          v-model="replyContent"
        />
        <button type="button" class="btn-reply-cancel" v-on:click="replyContent = ''">취소</button>
        <button
          type="button"
          class="btn-reply-add"
          v-on:click="$emit('AddReply', replyContent, () => {replyContent = ''})"
        >댓글</button>
      </div>
    </div>
    <!-- <div class="repy-user-info">
            <p>UserId</p>
    </div>-->
    <div class="container-reply" v-for="(reply, index) in replies" :key="index">
      <div class="container-left">
        <div class="container-top">
          <div class="reply-userId">UserId</div>
          <!-- <div class="reply-createdOn">{{reply.creatdOn}}</div> -->
          <div class="reply-createdOn">2020-06-12</div>
        </div>
        <div class="container-bottom">
          <div class="reply-content">{{reply.content}}</div>
        </div>
      </div>
      <div class="container-right">
        <div class="btn-reply-delete" ref="reply-menu-area">
          <!-- <i class="material-icons">delete</i> -->
          <img
            src="@/assets/menu.png"
            width="16"
            height="auto"
            style="opacity:.8; cursor: pointer;"
            @click="index == menuVisible ? menuVisible = -1 : menuVisible = index"
          />
          <transition name="fade">
            <div class="menu" v-if="menuVisible == index">
              <div class="menu-el">
                <i class="material-icons">edit</i> 수정
              </div>
              <div class="menu-el" v-on:click="$emit('DeleteReply', replies[index])">
                <i class="material-icons">delete</i> 삭제
              </div>
            </div>
          </transition>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Reply",
  props: {
    replies: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      replyContent: "",
      menuVisible: -1
    };
  },
  methods: {
    showMenu(i) {
      this.menuVisible = i;
    }
  }
};
</script>

<style scoped>
.btn-group-reply {
  text-align: right;
}
.btn-group-reply .btn-reply-add,
.btn-reply-cancel {
  /* float: right; */
  margin: 10px 0px 20px 15px;
}
.container-reply {
  display: flex;
  justify-content: space-between;
  margin-bottom: 15px;
  padding-bottom: 10px;
  border-bottom: 1px solid #cacaca;
}
.container-left {
  display: flex;
  flex-flow: column;
}
.container-right {
  padding-top: 15px;
  position: relative;
}
.container-top {
  display: flex;
  align-items: center;
}
.container-bottom {
  margin-top: 8px;
}
.reply-createdOn {
  font-size: 12px;
  color: #cacaca;
  margin-left: 15px;
}
.menu {
  position: absolute;
  top: 10px;
  left: 20px;
  background-color: #fff;
  box-shadow: 2px 2px 3px 0px rgba(0, 0, 0, 0.2);
  width: max-content;
}
.menu-el {
  padding: 5px 10px;
  text-align: center;
  background-color: #fff;
  transition: background-color 0.25s;
  cursor: pointer;
}
.menu-el:hover {
  background-color: #eee;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.material-icons {
  vertical-align: middle;
}
</style>