<template>
  <v-container>
    <h1>Hello World</h1>
  </v-container>
</template>

<script lang="ts">
  import Vue from 'vue';
  import {Component} from "vue-property-decorator";

  @Component
  export default class HelloWorld extends Vue {}
</script>


