<template>
  <v-app id="inspire">

    <v-navigation-drawer v-model="drawer" app color="lightBlue" class="side-menu">
      <div class="company-logo">
        <v-img src="/icon/TechCells_Logo.svg"/>
      </div>

      <v-list nav>
        <v-list-item-group v-model="selectedSideMenuItem" active-class="active" color="primary" mandatory>
          <v-list-item
              v-for="link in links"
              :link="true"
              :key="link.icon"
              :to="link.pageUrl"
          >
            <v-list-item-icon>
              <v-icon>{{ link.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>{{ link.text }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <v-main class="pa-0">
      <v-container>
        <router-view/>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component} from "vue-property-decorator";
import {DashboardSideBar} from "@/enums/DashboardSideBar";

@Component
export default class Dashboard extends Vue {
  public selectedSideMenuItem = DashboardSideBar.Interviewers;
  public drawer = null;
  public links = [
    {
      icon: 'fa-solid fa-users',
      text: 'Interviewers',
      pageUrl: '/dashboard/interviewers'
    },
    {
      icon: 'fa-solid fa-people-group',
      text: 'Talents',
      pageUrl: '/dashboard/talents'
    },
    {
      icon: 'fa-solid fa-list-check',
      text: 'Interviews',
      pageUrl: '/dashboard/Interviews'
    },
  ];
}
</script>

<style scoped lang="scss">
.side-menu{
  .company-logo{
    width: 100%;
    .v-image{
      width: 120px;
      margin: 30px 0 60px 16px;
    }
  }
}
</style>