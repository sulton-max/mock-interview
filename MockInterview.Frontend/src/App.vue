<template>
  <v-app>
    <app-bar v-if="!$router.currentRoute.path.includes('dashboard')"/>
    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import AppBar from "@/components/AppBar.vue";

export default Vue.extend({
  name: 'App',
  components: {
    AppBar
  },
  data: () => ({
    //
  }),
});
</script>
