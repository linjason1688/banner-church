<template>
  <div>
    <div class="row justify-center q-pa-md">
      <div class="col-12">
        <c-sub-title title="結業狀態"></c-sub-title>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { Options } from "vue-class-component";
import SubTitle from "components/SubTitle.vue";

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class Graduation extends ComponentBase {

@Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }
}
</script>