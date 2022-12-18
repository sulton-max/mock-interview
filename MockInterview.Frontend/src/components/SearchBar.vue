<template>
  <v-text-field
      v-model="searchText"
      outlined
      :label="placeholder"
      dense
      prepend-inner-icon="fa-solid fa-magnifying-glass"
  ></v-text-field>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component, Prop, VModel} from "vue-property-decorator";

@Component
export default class SearchBar extends Vue {
  @VModel({type: String}) searchText!: string;
  @Prop(String) readonly placeholder!: string;
}
</script>

<style scoped>

</style>