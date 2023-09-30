<template>
    <div class="row justify-center q-pa-md">
      <div class="col-12">
        <c-subtitle title="事工團出席管理" />
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { ComponentBase } from "src/components";
  import { Options } from "vue-class-component";
  
  @Options({
    components: {
    },
  })
  export default class Member extends ComponentBase {
  
    async mounted() {
      //
    }
  }
  </script>
  
  <style lang="scss" scoped>
  @import '../../css/quasar.variables.scss';
  
  </style>
  