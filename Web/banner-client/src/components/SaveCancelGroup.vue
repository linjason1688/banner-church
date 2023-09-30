<template>
  <div class="flex justify-center q-py-sm app-savecancel-group app-savecancel-group-fixed">
    <c-btn-save class="q-mr-md" @click="save" />
    <c-btn-cancel @click="cancel" />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Emit } from "vue-property-decorator";

export default class SaveCancelGroup extends ComponentBase {
  @Emit("save") save(e: MouseEvent) { return e; }
  @Emit("cancel") cancel(e: MouseEvent) { return e; }
}
</script>