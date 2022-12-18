import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import {DashboardChildren} from "@/router/dashboard/dashboardChildren";
import Dashboard from "@/views/Dashboard/Dashboard.vue";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/dashboard',
    redirect: '/dashboard/interviewers',
    name: "Dashboard",
    component: Dashboard,
    children: DashboardChildren,
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
