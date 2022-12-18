import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import {DashboardChildren} from "@/router/dashboard/dashboardChildren";
import Dashboard from "@/views/Dashboard/Dashboard.vue";
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
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
