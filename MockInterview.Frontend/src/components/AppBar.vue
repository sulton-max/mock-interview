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
                <v-container class="mt-5">
                  <v-row>
                    <v-col cols="6">
                      <label for="firstName">First name</label>
                      <v-text-field
                          label="First name"
                          id="firstName"
                          class="mt-1"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-user-tie"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <label for="lastName">Last name</label>
                      <v-text-field
                          label="Last name"
                          id="lastName"
                          class="mt-1"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-user-tie"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <label for="email">Email</label>
                      <v-text-field
                          label="Email"
                          id="email"
                          class="mt-1"
                          type="email"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-envelope"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <label for="password">Password</label>
                      <v-text-field
                          label="Password"
                          id="password"
                          class="mt-1"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-lock  "
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <v-btn-toggle v-model="selectedGender" color="primary" class="mt-5">
                        <v-btn value="male">
                          <v-icon left>
                            fa-solid fa-person
                          </v-icon>
                          <span class="hidden-sm-and-down">Male</span>
                        </v-btn>

                        <v-btn value="female">
                          <v-icon left>
                            fa-solid fa-person-dress
                          </v-icon>
                          <span class="hidden-sm-and-down">Female</span>
                        </v-btn>
                      </v-btn-toggle>
                    </v-col>
                    <v-col cols="6">
                      <label for="dateOfBirth">Date of birth</label>
                      <v-menu
                          v-model="menu2"
                          :close-on-content-click="false"
                          :nudge-right="40"
                          transition="scale-transition"
                          offset-y
                          min-width="auto"
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                              v-model="date"
                              label="Date of birth"
                              id="dateOfBirth"
                              class="mt-1"
                              outlined
                              prepend-inner-icon="mdi-calendar"
                              readonly
                              dense
                              v-bind="attrs"
                              v-on="on"
                          ></v-text-field>
                        </template>
                        <v-date-picker
                            v-model="date"
                            @input="menu2 = false"
                        ></v-date-picker>
                      </v-menu>
                    </v-col>
                    <v-col cols="12" class="d-flex justify-center">
                      <v-btn depressed color="primary">
                        Register Now
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
              </v-tab-item>
              <v-tab-item>
                <v-container class="mt-5">
                  <v-row>
                    <v-col cols="12">
                      <label for="email">Email</label>
                      <v-text-field
                          label="Email"
                          id="email"
                          class="mt-1"
                          type="email"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-envelope"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <label for="password">Password</label>
                      <v-text-field
                          label="Password"
                          id="password"
                          class="mt-1"
                          outlined
                          dense
                          required
                          prepend-inner-icon="fa-solid fa-lock  "
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" class="d-flex justify-center">
                      <v-btn depressed color="primary">
                        Sign In
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
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

  @Component
  export default class AppBar extends Vue {
    public isOpenRegisterDialog = false;
    public activeRegisterTab = 1;
    public selectedGender = "male";

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