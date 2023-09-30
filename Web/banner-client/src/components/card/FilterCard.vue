<template>
  <q-card class="q-pb-md c-filter-card">
    <q-card-section class="row justify-center">
      <div class="col-auto">
        <div class="c-heading-h4 ">全部篩選</div>
        <q-separator size="2px" class="c-primary-background-300" />
      </div>
    </q-card-section>

    <q-card-section>
      <p class="q-px-md q-mb-md c-content-body">課程型態</p>
      <div class="q-px-md q-gutter-sm">
        <q-chip v-for="(item, index) in classTypeList" :key="item.index" outline square clickable :v-model="item.selected"
          class="c-class-filter-btn" @click="onClickClassType(index, item)" :class="{
            'c-class-filter-btn': !item.selected,
            'c-class-filter-btn__active': item.selected,
          }">
          {{ item.label }}
        </q-chip>
      </div>
    </q-card-section>

    <q-card-section>
      <p class="q-px-md q-mb-md c-content-body">課程日期</p>
      <div class="row justify-between">
        <div class="col-5 q-px-md">
          <c-column label="">
            <c-date-picker v-model="selectedDateS" role="n"></c-date-picker>
          </c-column>
        </div>

        <div class="col-1 relative-position">
          <p class="c-content-body absolute-center">－</p>
        </div>
        <div class="col-5 q-px-md">
          <c-column label="">
            <c-date-picker v-model="selectedDateE" role="n"></c-date-picker>
          </c-column>
        </div>
      </div>
    </q-card-section>

    <q-card-section>
      <p class="q-px-md q-mb-md c-content-body">開課堂點</p>
      <div class="row q-px-md q-gutter-sm">
        <q-chip v-for="(item, index) in organizationList" :key="index" outline square clickable class="c-class-filter-btn"
          :v-model="item.selected" @click="onClickOrganization(index, item)" :class="{
            'c-class-filter-btn': !item.selected,
            'c-class-filter-btn__active': item.selected,
          }">
          {{ item.name }}
        </q-chip>
      </div>
    </q-card-section>

    <q-card-section>
      <div class="row justify-center">
        <div class="col-auto">
          <q-btn rounded class="q-mx-sm c-gray-white c-primary-background-500" @click="reset">重置</q-btn>
          <q-btn rounded class="q-mx-sm c-gray-white c-primary-background-500" @click="onComplete">完成</q-btn>
        </div>
      </div>
    </q-card-section>
  </q-card>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { Emit } from "vue-property-decorator";
import { OrganizationView } from "src/api/feature";
import { filter } from "dom7";
import { divide } from "lodash";
import { container } from "webpack";

export interface Organization$ extends OrganizationView {
  selected: boolean;
}

export interface ClassType {
  index: string;
  label: string;
  selected: boolean;
}

export interface Conditions {
  selectedClassType: { [name: string]: ClassType },
  classTypeList: Array<ClassType>,
  selectedDateS: string,
  selectedDateE: string,
  selectedOrganizations: { [name: string]: Organization$ },
}

@Options({})
export default class FilterCard extends ComponentBase {

  selectedOrganizations: { [name: string]: Organization$ } = {};
  selectedClassType: { [name: string]: ClassType } = {};
  selectedDateS: string = "";
  selectedDateE: string = "";

  organizationList: Array<Organization$> = [];

  classTypeList = [
    {
      index: "0",
      label: "實體",
      selected: false,
    },
    {
      index: "1",
      label: "線上",
      selected: false,
    },
  ];

  onClickOrganization(index: number, e: Organization$) {
    this.organizationList[index].selected = !this.organizationList[index].selected;
    if (this.selectedOrganizations[e.id] == undefined) {
      this.selectedOrganizations[e.id] = e;
    } else {
      delete this.selectedOrganizations[e.id];
    }
  }

  onClickClassType(index: number, classType: ClassType) {
    this.classTypeList[index].selected = !this.classTypeList[index].selected;

    if (this.selectedClassType[classType.label] == undefined) {
      this.selectedClassType[classType.label] = classType;
    } else {
      delete this.selectedClassType[classType.label];
    }
  }

  async mounted() {
    let organizations = (await this.apis.feature.organization.fetchOrganizations()).data;
    this.organizationList = organizations.map((e) => ({ ...e, selected: false }));
  }

  @Emit("completed")
  onComplete() {
    const conditions: Conditions = {
      selectedClassType: this.selectedClassType,
      classTypeList: this.classTypeList,
      selectedDateS: this.selectedDateS,
      selectedDateE: this.selectedDateE,
      selectedOrganizations: this.selectedOrganizations,
    };
    return conditions;
  }

  reset() {
    this.classTypeList.forEach(e => e.selected = false);
    this.organizationList.forEach(e => e.selected = false);
    this.selectedDateS = "";
    this.selectedDateE = "";
    
  }
}


</script>
