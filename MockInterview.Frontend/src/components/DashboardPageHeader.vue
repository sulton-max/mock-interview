<template>
  <v-row>
    <v-col cols="6" class="d-flex justify-start align-center">
      <h2>{{pageTitle}}</h2>
    </v-col>
    <v-col cols="6" class="d-flex justify-end align-center">
      <div class="avatar-wrapper">
        <v-avatar size="36px" color="primary" rounded>
          <img
              v-if="fullName"
              alt="Avatar"
              src="https://avatars0.githubusercontent.com/u/9064066?v=4&s=460"
          >
          <span v-else class="white--text text-h6">{{fullName.split(' ')[0][0].toUpperCase() + fullName.split(' ')[1][0].toUpperCase()}}</span>
        </v-avatar>
        <h4 class="ml-2">{{fullName}}</h4>
      </div>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component, Prop} from "vue-property-decorator";

@Component
export default class DashboardPageHeader extends Vue{
  @Prop(String) readonly pageTitle!: string
  @Prop(String) readonly fullName!: string
}
</script>

<style scoped lang="scss">
.avatar-wrapper{
  display: flex;
  align-items: center;
  padding: 5px 10px;
  border-radius: 10px;
  transition: all 0.3s;
  &:hover{
    background: #FAFAFA;
    cursor: pointer;
  }
  &:active {
    background: #eeeded;
  }
}
</style>