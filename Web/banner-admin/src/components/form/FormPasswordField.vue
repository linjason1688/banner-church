<template>
  <q-input class="q-mb-md" :label="label" stack-label :type="isPwd ? 'password' : 'text'" v-model="password">
    <template v-slot:append>
      <q-icon
        :name="isPwd ? 'visibility_off' : 'visibility'"
        class="cursor-pointer"
        @click="isPwd = !isPwd"
      />
    </template>
  </q-input>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class FormPasswordField extends FormBase {
  password = "";
  isPwd = "password";

  @Prop({ type: String })
  label!: string;
  
  created() {
    //
  }
}
</script>
