<template>
  <v-app-bar absolute color="white" class="px-10">

    <v-toolbar-title>Mock Interview</v-toolbar-title>

    <v-btn depressed outlined color="primary" class="ml-5" @click="$router.push('Dashboard')">
      Dashboard
    </v-btn>

    <v-spacer></v-spacer>

    <v-btn depressed outlined color="primary" class="mr-5" @click="openRegisterDialog('signIn')">
      Sign In
    </v-btn>

    <v-btn depressed color="primary" @click="openRegisterDialog('registration')">
      Join Now
    </v-btn>


  <!--  Registration Dialog  -->
    <v-dialog v-model="isOpenRegisterDialog" max-width="1000px">
      <v-card>
        <v-btn icon style="position: absolute; z-index: 2; right: 5px; top: 5px;" @click="isOpenRegisterDialog = false">
          <v-icon>fa-solid fa-xmark</v-icon>
        </v-btn>
        <v-row class="ma-0">
          <v-col cols="6">
            <v-img src="/img/register_illustration.png"/>
          </v-col>
          <v-divider vertical></v-divider>
          <v-col cols="6">
            <v-tabs
                color="deep-purple accent-4"
                centered
                v-model="activeRegisterTab"
                class="mt-5"
            >
              <v-tab>Register</v-tab>
              <v-tab>Sign In</v-tab>

              <v-tab-item>
                <register />
              </v-tab-item>
              <v-tab-item>
                <sign-in />
              </v-tab-item>
            </v-tabs>
          </v-col>
        </v-row>
      </v-card>
    </v-dialog>
  </v-app-bar>
</template>

<script lang="ts">
  import Vue from 'vue';
  import {Component} from "vue-property-decorator";
  import Register from "@/components/Register.vue";
  import SignIn from "@/components/SignIn.vue";

  @Component({
    components:{
      Register,
      SignIn
    }
  })
  export default class AppBar extends Vue {
    public isOpenRegisterDialog = false;
    public activeRegisterTab = 1;

    // Methods:
    public openRegisterDialog(type: string): void{
      this.isOpenRegisterDialog = true;
      if (type === 'signIn') {
        this.activeRegisterTab = 1;
      } else{
        this.activeRegisterTab = 0;
      }
    }
  }
</script>

<style scoped>
</style>