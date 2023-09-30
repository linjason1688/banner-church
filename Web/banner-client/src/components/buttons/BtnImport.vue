<template>
  <div>
    <q-btn v-bind="$attrs" color="amber darken-4" @click="handleUploadClick">
      <slot>匯入</slot>
      <q-icon class="q-ml-xs" name="cloud_upload"></q-icon>
    </q-btn>
    <input
      type="file"
      :accept="accept"
      @change="handleFileChanged"
      :key="fileInputKey"
      class="mb-hidden"
      ref="fileInput"
    />
    <q-tooltip v-if="showDownloadExampleFile" right>
      <template v-slot:activator="{ on }">
        <q-icon v-on="on" @click="downloadExampleFile" class="ml-1 ih-pointer" name="cloud_upload"></q-icon>
      </template>
      <slot name="example">下載範例檔</slot>
    </q-tooltip>
  </div>
</template>

<script lang="ts">
// Component
import { BusinessError } from "src/data/errors";
import { ExcelUtility } from "src/util";
import { Options } from "vue-class-component";
import { Emit, Prop, Ref } from "vue-property-decorator";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnImport extends ButtonBase {
  @Prop({ type: Boolean, default: () => false })
  showDownloadExampleFile!: boolean;

  @Prop({ default: () => [] })
  columns!: string[];

  @Prop({ type: String, default: "*" })
  accept!: string;

  @Prop({ type: Number, default: 10 })
  maxFileSize!: number;

  @Prop({ type: String, default: "UploadExample.xlsx" })
  exampleFileName!: string;

  @Ref("fileInput")
  fileInput!: HTMLInputElement;

  /**
   * 防止選取相同檔案無反應
   */
  fileInputKey = 0;

  handleUploadClick() {
    this.fileInput.click();
  }

  /**
   * 回傳
   * true: 已產出檔案下載
   * false: 未指定 column， 由 parent 接收事件下載
   */
  @Emit("downloadExampleFile")
  downloadExampleFile() {
    //
    if (this.columns && this.columns.length) {
      ExcelUtility.exportFile(this.exampleFileName, [], this.columns, [], { sheetName: "sheet" });
      return true;
    }
    return false;
  }

  @Emit("fileChanged")
  handleFileChanged(e: Event) {
    const target = e.target as HTMLInputElement;

    if (!target.files) {
      throw new Error("No file detected");
    }

    const file = target.files[0];
    const sizeMB = file.size >> 20;
    if (sizeMB >= this.maxFileSize) {
      throw new BusinessError(`檔案超過 ${this.maxFileSize} MB 限制! (${sizeMB})`);
    }

    this.fileInputKey = new Date().getTime();

    return file;
  }
}
</script>
