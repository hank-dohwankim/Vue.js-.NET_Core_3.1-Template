import Vue from "vue";
import Router from "vue-router";
import Index from "@/components/Index";

Vue.use(Router);

export default new Router({
  mode: "history", //history fallback api
  routes: [
    {
      path: "/",
      name: "Index",
      component: Index
    },
    {
      path: "/add-post",
      name: "AddPost",
      component: () => import("@/components/post/AddPost") //AddPost Lazy Loading
    }
  ]
});
