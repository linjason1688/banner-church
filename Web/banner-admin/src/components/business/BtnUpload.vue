<template>
  <div>
    <q-file
      filled
      bottom-slots
      v-model="file"
      :label="label"
      @update:model-value="handleFileChanged"
      counter
      :filter="checkFiles"
    >
      <template v-slot:prepend>
        <q-icon name="cloud_upload" @click.stop.prevent />
      </template>
      <template v-slot:append>
        <q-icon name="close" @click.stop.prevent="model = null" class="cursor-pointer" />
      </template>

      <template v-slot:hint v-if="!autoUpload">{{ hint }}</template>
      <template v-slot:after v-if="!autoUpload">
        <q-btn round dense flat icon="send" @click="uploadFileAsync" />
      </template>
    </q-file>
  </div>
</template>

<script lang="ts">
// Component
import { FileUploadedEvent } from "src/data/dto";
import { BusinessError } from "src/data/errors";
import { WithLoading } from "src/util/TsDecorators";
import { Options } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";
import { ButtonBase } from "../buttons/ButtonBase";

@Options({})
export default class BtnUpload extends ButtonBase {
  @Prop({ type: String, default: () => "" })
  private category!: string;

  @Prop({ type: String, default: () => "檔案上傳" })
  private label!: string;

  @Prop({ type: String, default: () => "" })
  private hint!: string;

  /**
   * ex: "image/png"
   */
  @Prop({ type: Array, default: ["image/png", "image/jpeg"] })
  private acceptTypes!: string[];

  /**
   * Bytes
   */
  @Prop({ type: String, default: () => 100 * 1024 * 1024 })
  private maxSize!: number;

  /**
   * Upload files without clicking the button.
   * @private
   */
  @Prop({ type: Boolean, default: true })
  private autoUpload!: boolean;

  private file: File | null = null;

  checkFiles(files: File[]) {
    return files.filter((file) => {
      return this.acceptTypes.some((t) => file.type.indexOf(t) > -1) && file.size < this.maxSize;
    });
  }

  async handleFileChanged() {
    if (this.autoUpload) {
      await this.uploadFileAsync();
    }
  }

  @WithLoading()
  async uploadFileAsync() {
    if (!this.category) {
      throw new BusinessError("請指定上傳檔案類別");
    }

    const file = this.file;

    const res = await this.apis.feature.file.uploadFileAsync(this.category, file);

    this.onFileUploaded({ fileKey: res.data.fileKey });
  }

  @Emit("uploaded")
  // eslint-disable-next-line
  onFileUploaded(res: FileUploadedEvent) {
    //
  }
}
</script>
