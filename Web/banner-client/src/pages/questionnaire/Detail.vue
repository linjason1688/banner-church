<template>
  <div class="row justify-center q-pa-md">
    <div class="col-12 col-md-8">
      <c-subtitle title="滿意度調查"></c-subtitle>
      <div>
        <c-form-card class="c-gray-bgcolor-50">
          <q-form>
            <div class="text-center">
              <div class="c-heading-h2 q-mb-lg">滿意度調查</div>
              <div class="c-content-subtitle q-mb-lg">為增進服務品質與工作效率請協助填寫此份問卷，感謝大家配合</div>
              <hr>
            </div>

            <div class="c-content-title q-pa-sm q-mb-md c-bgcolor-gray-white">基本資料</div>
            <div class="q-pa-md q-mb-md c-bgcolor-gray-white">
              <div class="c-content-subtitle">1. 請選擇平常前往的區域</div>
              <div class="q-mx-sm q-mb-md">
                <q-checkbox v-model="form.taichung" label="台中" :disable="disable" />
                <q-checkbox v-model="form.taipei" label="台北" :disable="disable" />
                <q-checkbox v-model="form.kaohsiung" label="高雄" :disable="disable" />
              </div>
              <div class="c-content-subtitle">2. 請選擇受洗狀態</div>
              <c-option-group :options="baptizedTypeList" class="q-px-sm q-mb-md" color="primary"
                              v-model="form.baptizedType" :disable="disable" />
            </div>

            <div class="c-content-title q-pa-sm q-mb-md c-bgcolor-gray-white">滿意度調查</div>
            <div class="q-pa-md c-bgcolor-gray-white">
              <div class="c-content-subtitle">1. 對於客服人員服務態度滿意度</div>
              <div class="row items-center q-mb-md">
                <div>非常不滿意</div>
                <c-option-group :options="satisfyTypeList" class="q-ml-none q-mr-md inline-block" color="primary"
                                v-model="form.satisfaction" :disable="disable" />
                <div>非常滿意</div>
              </div>
              <div class="c-content-subtitle">2. 針對總體顧客服務經驗將會給予何種評價</div>
              <div class="row items-center q-mb-md">
                <div>非常不滿意</div>
                <c-option-group :options="satisfyTypeList" class="q-ml-none q-mr-md inline-block" color="primary"
                                v-model="form.evaluation" :disable="disable" />
                <div>非常滿意</div>
              </div>
            </div>
          </q-form>
        </c-form-card>
      </div>
    </div>
  </div>

  <div class="row">
    <div class="col-12">
      <c-savecancel-group @save="updateAsync()" @cancel="cancel()" />
    </div>
  </div>
</template>

<script lang="ts">
import { PagedRequest } from "src/data/dto";
import { Options } from "vue-class-component";
import { UpdateUserQuestionnaireCommand } from "src/api/feature";
import { ref } from "vue";
import { DetailComponentBase } from "components/DetailComponentBase";

@Options({
  components: {},
})
export default class Detail extends DetailComponentBase {

  baptizedTypeList = [
    {
      label: "已受洗",
      value: "1",
    },
    {
      label: "未受洗",
      value: "0",
    },
  ];
  satisfyTypeList = [
    {
      label: "1",
      value: "1",
    },
    {
      label: "2",
      value: "2",
    },
    {
      label: "3",
      value: "3",
    },
    {
      label: "4",
      value: "4",
    },
    {
      label: "5",
      value: "5",
    },
  ];

  form = {
    id: null,
    questionnaireId: null,
    userId: null,
    questionnaireGoArea: ref(false),

    baptizedType: "",
    satisfaction: ref(""),
    evaluation: ref(""),

    taichung: false,
    taipei: false,
    kaohsiung: false,
  };

  disable = false;

  async mounted() {
    try {
      const e = (await this.apis.feature.userQuestionnaire.findUserQuestionnaire(this.$route.params.id as unknown as number))
      if (e.data && e.data.records[0]) {
        if (e.data.records[0].comment) {
          this.form = JSON.parse(e.data.records[0].comment);
        }
      }
    } finally {
      this.disable = this.$route.query.view == "1";
    }
  }

  async updateAsync(request?: PagedRequest) {
    let questionnaireId = parseInt(this.$route.query.questionnaireId as string,10);
    let userQuestionnaireId = parseInt(this.$route.params.id as string,10);
    
    let updateCommand = {} as UpdateUserQuestionnaireCommand;
    Object.assign(updateCommand,request);
    Object.assign(updateCommand,this.form);
    updateCommand.id = userQuestionnaireId;
    updateCommand.questionnaireId = questionnaireId;
    updateCommand.userId = this.$appStore.getters.userProfile.id;
    updateCommand.questionnaireWriteType = "1";
    updateCommand.writeQuestionnaireDate = this.$fmt.formatDateTime(new Date());
    updateCommand.comment = JSON.stringify({ ...updateCommand, comment: undefined });
    await this.apis.feature.userQuestionnaire.putUserQuestionnaire(updateCommand);

    this.showSuccessNotify("填寫問卷完成")
    void this.$router.push("/m/questionnaire/index");
  }

  cancel() {
    this.$router.go(-1);
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
