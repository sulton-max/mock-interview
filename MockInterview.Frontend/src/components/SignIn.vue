<template>
  <v-container class="mt-5">
    <v-form ref="form" v-model="isValid" :disabled="isLoading">
      <v-row>
        <v-col cols="12">
          <label for="email">Email</label>
          <v-text-field
              v-model="authenticationDetail.emailAddress"
              label="Email"
              id="email"
              class="mt-1"
              type="email"
              :rules="emailRules"
              outlined
              dense
              required
              prepend-inner-icon="fa-solid fa-envelope"
          ></v-text-field>
        </v-col>
        <v-col cols="12">
          <label for="password">Password</label>
          <v-text-field
              v-model="authenticationDetail.password"
              label="Password"
              id="password"
              class="mt-1"
              :rules="passwordRules"
              outlined
              dense
              required
              prepend-inner-icon="fa-solid fa-lock  "
          ></v-text-field>
        </v-col>
        <v-col cols="12" class="d-flex justify-center">
          <v-btn depressed color="primary" @click="login" :loading="isLoading">
            Sign In
          </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>

<script lang="ts">
import BaseComponent from "@/helpers/mixins/baseComponent";
import {Component} from "vue-property-decorator";
import {AuthenticationDetail} from "@/types/authenticationDetail";
import {AuthService} from "@/service/authService";

@Component
export default class SignIn extends BaseComponent{

  // Data:
  public authenticationDetail = new AuthenticationDetail();
  public isValid = false;
  public emailRules = [
    (v: string) => !!v || 'E-mail is required',
    (v: string) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
  ];
  public passwordRules = [
    (v: string) => !!v || 'Password is required',
    (v: string) => /^(?=(.*[a-zA-Z]){1,})(?=(.*[0-9]){1,}).{8,}$/.test(v) || `Password is not valid, (at least 8 character, one uppercase letter, one lowercase letter, one symbol and number)`
  ];

  // Methods:
  public async login(): Promise<void> {
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    //@ts-ignore
    this.$refs['form'].validate();

    const authService = new AuthService();
    await this.startLoading(async () => {
      const response = await authService.login(this.authenticationDetail);
    })
  }
}
</script>

<style scoped>

</style>