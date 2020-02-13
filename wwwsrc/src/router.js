import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Keep from "./views/Keep.vue";
// @ts-ignore
import newvault from "./views/NewVault.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/keep/:id",
      name: "keep",
      component: Keep
    },
    {
      path: "/newvault/:id",
      name: "newvault",
      component: newvault
    },

    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    }
  ]
});
