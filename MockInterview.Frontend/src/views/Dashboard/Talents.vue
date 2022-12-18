<template>
  <v-container>
    <dashboard-page-header page-title="Talents" full-name="Tohirbek Odilkuziev"/>

    <v-row>
      <v-col cols="9" class="d-flex align-center">
        <search-bar placeholder="Search talents..."/>
        <div class="d-flex" style="width: 60%; margin-left: 12px;">
          <v-select
              :items="items"
              label="All Interviewers"
              dense
              outlined
              class="mr-3"
          ></v-select>
          <v-select
              :items="items"
              label="All Interviewers"
              dense
              outlined
          ></v-select>
        </div>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <v-data-table
            :headers="headers"
            :items="talents"
            item-key="name"
            class="elevation-1"
            :loading="isLoading"
        >
          <template v-slot:[`item.fullName`]="{ item }">
            <span>{{item.firstName}} {{item.lastName}}</span>
          </template>
          <template v-slot:[`item.contact`]="{ item }">
            <span v-if="item.contact != null">{{item.contact.phoneNumber}}</span>
            <span v-else>Not supported</span>
          </template>
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon
                small
                class="mr-2"
                @click="editItem(item)"
            >
              mdi-pencil
            </v-icon>
            <v-icon
                small
                @click="deleteItem(item)"
            >
              mdi-delete
            </v-icon>
          </template>
          <template v-slot:no-data>
            <v-btn
                color="primary"
                @click="getTalents"
            >
              Reset
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>

  <!--  Delete Talent Warning Dialog:  -->
    <v-dialog v-model="dialogDelete" max-width="500px">
      <v-card>
        <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="closeDeleteDialog">Cancel</v-btn>
          <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import BaseComponent from "@/helpers/mixins/baseComponent";
import {Component} from "vue-property-decorator";

import DashboardPageHeader from "@/components/DashboardPageHeader.vue";
import SearchBar from "@/components/SearchBar.vue";
import {UserDto} from "@/types/userDto";
import {UsersService} from "@/service/usersService";
import {EntityQueryOptions} from "@/types/entityQueryOptions";


@Component({
  components:{
    DashboardPageHeader,
    SearchBar
  }
})
export default class Talents extends BaseComponent{

  // Data:
  public dialogDelete = false;
  public items = ['Foo', 'Bar', 'Fizz', 'Buzz'];
  public itemIsGoingToBeDeleted: UserDto = new UserDto();
  public talents = new Array<UserDto>();
  public headers = [
    {
      text: 'Full name',
      align: 'start',
      sortable: false,
      value: 'fullName',
    },
    {
      text: 'Email',
      align: 'start',
      sortable: false,
      value: 'emailAddress',
    },
    {
      text: 'Gender',
      align: 'start',
      sortable: false,
      value: 'gender',
    },
    {
      text: 'Date of birth',
      align: 'start',
      sortable: false,
      value: 'dateOfBirth',
    },
    {
      text: 'Phone number',
      align: 'start',
      sortable: false,
      value: 'contact',
    },
    {
      text: 'Actions',
      align: 'start',
      sortable: false,
      value: 'actions',
    }
  ];

  // Methods:
  public async mounted(): Promise<void>{
   await this.getTalents();
  }

  public async getTalents(): Promise<void>{
    const userService = new UsersService();
    await this.startLoading(async () => {
      const response = await userService.getUserByFilter({
        filterOptions: null,
        includeOptions: null,
        sortOptions: null,
        paginationOptions: {
          pageToken: 1,
          pageSize: 10,
        }
      } as EntityQueryOptions)

      this.talents = response.data;
    })
  }

  public closeDeleteDialog(): void{
    this.dialogDelete = false;
    this.itemIsGoingToBeDeleted = new UserDto();
  }

  public deleteItem(itemData: UserDto): void{
    this.dialogDelete = true;
    this.itemIsGoingToBeDeleted = itemData;
  }

  public async deleteItemConfirm(): Promise<void>{
    const usersService = new UsersService();
    await this.startLoading(async () => {
      const response = await usersService.deleteById(this.itemIsGoingToBeDeleted.id);
      console.log(response)
    })
  }
}
</script>

<style scoped>

</style>