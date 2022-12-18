<template>
  <v-container class="mt-5">
    <v-form ref="form" v-model="isValid" :disabled="isLoading">
      <v-row>
        <v-col cols="6">
          <label for="firstName">First name</label>
          <v-text-field
              v-model="userDto.firstName"
              label="First name"
              id="firstName"
              class="mt-1"
              :rules="firstNameRules"
              outlined
              dense
              required
              prepend-inner-icon="fa-solid fa-user-tie"
          ></v-text-field>
        </v-col>
        <v-col cols="6">
          <label for="lastName">Last name</label>
          <v-text-field
              v-model="userDto.lastName"
              label="Last name"
              id="lastName"
              class="mt-1"
              :rules="lastNameRules"
              outlined
              dense
              required
              prepend-inner-icon="fa-solid fa-user-tie"
          ></v-text-field>
        </v-col>
        <v-col cols="6">
          <label for="email">Email</label>
          <v-text-field
              v-model="userDto.emailAddress"
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
        <v-col cols="6">
          <label for="password">Password</label>
          <v-text-field
              v-model="userDto.password"
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
              v-model="isOpenDateOfBirthMenu"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="auto"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                  v-model="dateOfBirthModel"
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
                v-model="dateOfBirthModel"
                @input="isOpenDateOfBirthMenu = false"
            ></v-date-picker>
          </v-menu>
        </v-col>
        <v-col cols="12" class="d-flex justify-center">
          <v-btn depressed color="primary" @click="register" :loading="isLoading">
            Register Now
          </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>

<script lang="ts">
import BaseComponent from "@/helpers/mixins/baseComponent";
import {Component, Watch} from "vue-property-decorator";
import {UserDto} from "@/types/userDto";
import {AuthService} from "@/service/authService";
import {ContactDto} from "@/types/contactDto";

@Component
export default class Register extends BaseComponent {

  // Data:
  public userDto = new UserDto();
  public dateOfBirthModel: Date | null = null;
  public isOpenDateOfBirthMenu = false;
  public isValid = false;
  public selectedGender = "male";
  public firstNameRules = [
    (v: string) => !!v || 'First name is required',
    (v: string) => (v && v.length <= 10) || 'First name must be less than 10 characters',
  ];
  public lastNameRules = [
    (v: string) => !!v || 'Last name is required',
    (v: string) => (v && v.length <= 10) || 'Last name must be less than 10 characters',
  ];
  public emailRules = [
    (v: string) => !!v || 'E-mail is required',
    (v: string) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
  ];
  public passwordRules = [
    (v: string) => !!v || 'Password is required',
    (v: string) => /^(?=(.*[a-zA-Z]){1,})(?=(.*[0-9]){1,}).{8,}$/.test(v) || `Password is not valid, (at least 8 character, one uppercase letter, one lowercase letter, one symbol and number)`
  ];

  // Methods:
  public mounted(): void{
    this.userDto.gender = this.selectedGender;
    this.userDto.contact = new ContactDto();
    this.userDto.contact.phoneNumber = 9998908098;
  }
  public async register(): Promise<void>{
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    //@ts-ignore
    this.$refs['form'].validate();
    const authService = new AuthService();
    await this.startLoading(async () => {
      const response = await authService.register(this.userDto);
      console.log(response);
    })
    console.log("userDto: ", this.userDto);
  }

  // Watch:
  @Watch('dateOfBirthModel')
  public onDateOfBirthChanged(changedDateOfBirth: Date) {
    this.userDto.dateOfBirth = new Date(changedDateOfBirth).toJSON();
  }

  @Watch('selectedGender')
  public onSelectedGenderChanged(changedSelectedGender: string): void{
    this.userDto.gender = changedSelectedGender;
  }
}
</script>

<style scoped>

</style>