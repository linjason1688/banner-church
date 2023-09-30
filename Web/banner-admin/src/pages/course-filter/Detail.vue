<template>
  <q-page class="q-pa-lg">
    <div class="row q-mb-md">
      <div class="col-12">
        <c-subtitle title="設定課程檔修與上課對象"></c-subtitle>
      </div>
    </div>
    <div class="row justify-center">
      <div class="col-8">

        <c-form-card class="c-outline-radius">
          <q-form @submit="submitAsync">
            <c-row>
              <div class="col-12 col-md-12">
                <c-column label="課程分類">
                  <c-form-course-management-type v-model="courseManagementTypeId"
                                                 outlined clearable dense
                    :rules="[(val: number) => !!val || '請選擇課程分類']"
                  />
                </c-column>
              </div>
            </c-row>

            <c-row>
              <div class="col-12 col-md-12">
              <c-column label="課程名稱">
                <c-form-course-management v-model:courseManagementId.sync="form.courseManagementId"
                                          outlined clearable dense
                  :courseManagementTypeId="courseManagementTypeId" :rules="[(val: number) => !!val || '請選擇課程名稱']" />
              </c-column>
              </div>
            </c-row>

            <c-column label="先修課程">
              <c-form-group-course-management v-for="(value, key) in courseFilter" :key="key"
                v-model:courseManagementId="value.courseManagementId"
                v-model:courseManagementTypeId="value.courseManagementTypeId"
                                              outlined clearable dense />
              <q-btn round flat icon="add" @click="addCourseFilters()"></q-btn>
            </c-column>

            <c-column label="性別">
              <c-form-gender v-model="form.courseSex" :hasAllOptions="false" />
            </c-column>

            <c-column label="年齡限制">
              <c-input v-model="form.ageUp" placeholder="輸入年齡下限">
                <template v-slot:append>
                  <span class="c-content-body c-text-color-100">以上</span>
                </template>
              </c-input>
              <c-input v-model="form.ageDown" placeholder="輸入年齡上限">
                <template v-slot:append>
                  <span class="c-content-body c-text-color-100">以下</span>
                </template>
              </c-input>
            </c-column>

            <c-column label="牧養職分">
              <q-checkbox v-for="(value, index) in ministryRespList" :key="index" v-model="pastoralFilter"
                :label="value.name" :val="value.id" />
            </c-column>

            <c-column label="事工團">
              <c-form-group-ministry v-for="(value, key) in respFilter" :key="key" v-model:ministryId="value.ministry"
                v-model:ministryRespId="value.ministryResp"></c-form-group-ministry>
              <q-btn round flat icon="add" @click="addRespFilters()"></q-btn>
            </c-column>

            <div class="row">
              <div class="col">
                <c-btn-history-back class="q-mr-md" />
                <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
                <c-btn-save type="submit" />
              </div>
            </div>
          </q-form>
        </c-form-card>
      </div>
    </div>

  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateCourseManagementFilterCommand,
  DeleteCourseManagementFilterCommand,
  UpdateCourseManagementFilterCommand,
  CourseManagementView,
  MinistryRespView,
  CreateCourseManagementFilterCourseCommand,
  CreateCourseManagementFilterPastoralCommand,
  CreateCourseManagementFilterRespCommand,
  QueryCourseManagementFilterCourseRequest,
  QueryCourseManagementFilterPastoralRequest,
  QueryCourseManagementFilterRespRequest,
  DeleteCourseManagementFilterPastoralCommand,
  DeleteCourseManagementFilterCourseCommand,
  DeleteCourseManagementFilterRespCommand,
} from "src/api/feature";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import FormGroupMinistry from "components/formGroup/FormGroupMinistry.vue";
import FormGroupCourseManagement from "components/formGroup/FormGroupCourseManagement.vue";

interface CourseFilter {
  id: number | undefined;
  courseManagementId: number | undefined;
  courseManagementTypeId: number | undefined;
}

interface RespFilter {
  id: number | undefined;
  ministry: number | undefined;
  ministryResp: number | undefined;
}

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {
    "c-form-course-management": FormCourseManagement,
    "c-form-course-management-type": FormCourseManagementType,
    "c-form-group-ministry": FormGroupMinistry,
    "c-form-group-course-management": FormGroupCourseManagement,
  },
})
export default class Detail extends DetailComponentBase {

  form = {
    id: undefined,
    courseManagementId: null,
    organizationId: undefined,
    courseSex: null,
    ageUp: 0,
    ageDown: 0,
    name: "",
  };


  courseManagementTypeId: number | null = null;
  courseFilter: Array<CourseFilter> = [];
  respFilter: Array<RespFilter> = [];
  pastoralFilter: Array<number> = [];

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  async created() {
    await this.getMinistryResp();
    await this.getCourseManagements();
    if (this.isUpdateMode) {
      void this.getCourseManagementFilter(this.deleteKey);
      this.courseFilter = await this.queryCourseManagementFilterCourses(this.deleteKey);
      this.respFilter = await this.queryCourseManagementFilterResp(this.deleteKey);
      this.pastoralFilter = await this.queryCourseManagementFilterPastorals(this.deleteKey);
    }
  }

  @WithLoading()
  async submitAsync() {
    if (this.isUpdateMode) {
      await this.updateAsync();
    } else {
      await this.createAsync();
    }
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as CreateCourseManagementFilterCommand;
      await this.apis.feature.courseManagementFilter.createCourseManagementFilter(request)
        .then((response) => {
          this.createCourseManagementFilterCourses(response.data.id, this.courseFilter);
          this.createCourseManagementFilterResp(response.data.id, this.respFilter);
          this.createCourseManagementFilterPastorals(response.data.id, this.pastoralFilter);
        })
    });
    this.$router.go(-1);
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.courseManagementFilter.putCourseManagementFilter(request as unknown as UpdateCourseManagementFilterCommand);
      void this.modifyCourseManagementFilterCourses(this.deleteKey);
      void this.modifyCourseManagementFilterResp(this.deleteKey);
      void this.modifyCourseManagementFilterPastorals(this.deleteKey);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.courseManagementFilter.deleteCourseManagementFilter(request as unknown as DeleteCourseManagementFilterCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }

  addCourseFilters() {
    this.courseFilter.push({
      id: undefined,
      courseManagementId: undefined,
      courseManagementTypeId: undefined,
    });
  }

  addRespFilters() {
    this.respFilter.push({
      id: undefined,
      ministry: undefined,
      ministryResp: undefined,
    });
  }

  createCourseManagementFilterCourses(courseManagementFilterId: number, courseAry: CourseFilter[]) {
    if (courseAry.length <= 0) {
      return;
    }
    courseAry.map(async (x) => {
      await this.executeAsync(async () => {
        const request = Object.assign({}, x) as unknown as CreateCourseManagementFilterCourseCommand;
        request.id = 0;
        request.courseManagementFilterId = courseManagementFilterId;
        await this.apis.feature.courseManagementFilterCourse.createCourseManagementFilterCourse(request);
      });
    })
  }

  createCourseManagementFilterResp(courseManagementFilterId: number, respAry: RespFilter[]) {
    if (respAry.length <= 0) {
      return;
    }
    respAry.map((x) => {
      const request = {
        id: 0,
        courseManagementFilterId: courseManagementFilterId,
        ministryRespId: x.ministryResp,
      } as CreateCourseManagementFilterRespCommand;
      void this.apis.feature.courseManagementFilterResp.createCourseManagementFilterResp(request)
    })
  }

  createCourseManagementFilterPastorals(courseManagementFilterId: number, pastoralAry: number[]) {
    if (pastoralAry.length <= 0) {
      return;
    }
    pastoralAry.map((x) => {
      const request = {
        id: 0,
        courseManagementFilterId: courseManagementFilterId,
        pastoralId: x,
      } as CreateCourseManagementFilterPastoralCommand;
      void this.apis.feature.courseManagementFilterPastoral.createCourseManagementFilterPastoral(request);
    })
  }

  deleteCourseManagementFilterCourses(courseAry: CourseFilter[]) {
    if (courseAry.length <= 0) {
      return;
    }
    courseAry.map((x) => {
      const request = {
        id: x.id,
      } as DeleteCourseManagementFilterCourseCommand;
      void this.apis.feature.courseManagementFilterCourse.deleteCourseManagementFilterCourse(request);
    })
  }

  deleteCourseManagementFilterResp(respAry: RespFilter[]) {
    if (respAry.length <= 0) {
      return;
    }
    respAry.map((x) => {
      const request = {
        id: x.id,
      } as DeleteCourseManagementFilterRespCommand;
      void this.apis.feature.courseManagementFilterResp.deleteCourseManagementFilterResp(request);
    })
  }

  deleteCourseManagementFilterPastorals(pastoralAry: number[]) {
    if (pastoralAry.length <= 0) {
      return;
    }
    pastoralAry.map((x) => {
      let courseManagementFilterPastoralId = this.courseManagementFilterPastoralMap.get(x)
      const request = {
        id: courseManagementFilterPastoralId,
      } as DeleteCourseManagementFilterPastoralCommand;
      void this.apis.feature.courseManagementFilterPastoral.deleteCourseManagementFilterPastoral(request);
    })
  }

  async modifyCourseManagementFilterCourses(courseManagementFilterId: number) {
    let originalCourseFilter = await this.queryCourseManagementFilterCourses(courseManagementFilterId);
    let originalSet = new Set(this.getIDs(originalCourseFilter));
    let newSet = new Set(this.getIDs(this.courseFilter));
    let remove = originalCourseFilter.filter((e) => {
      return !newSet.has(e.id)
    });
    let add = this.courseFilter.filter((e) => {
      return !originalSet.has(e.id)
    });
    void this.createCourseManagementFilterCourses(courseManagementFilterId, add);
    void this.deleteCourseManagementFilterCourses(remove);
  }

  async modifyCourseManagementFilterResp(courseManagementFilterId: number) {
    let originalRespFilter = await this.queryCourseManagementFilterResp(courseManagementFilterId);
    let originalSet = new Set(this.getIDs(originalRespFilter));
    let newSet = new Set(this.getIDs(this.respFilter));
    let remove = originalRespFilter.filter((e) => {
      return !newSet.has(e.id)
    });
    let add = this.respFilter.filter((e) => {
      return !originalSet.has(e.id)
    });
    void this.createCourseManagementFilterResp(courseManagementFilterId, add);
    void this.deleteCourseManagementFilterResp(remove);
  }

  async modifyCourseManagementFilterPastorals(courseManagementFilterId: number) {
    if (this.pastoralFilter.length <= 0) {
      return;
    }
    let originalPastoralFilter = await this.queryCourseManagementFilterPastorals(courseManagementFilterId);
    let originalSet = new Set(originalPastoralFilter);
    let newSet = new Set(this.pastoralFilter);
    let remove = originalPastoralFilter.filter((e) => {
      return !newSet.has(e)
    });
    let add = this.pastoralFilter.filter((e) => {
      return !originalSet.has(e)
    });
    void this.createCourseManagementFilterPastorals(courseManagementFilterId, add);
    void this.deleteCourseManagementFilterPastorals(remove);
  }

  async queryCourseManagementFilterCourses(courseManagementFilterId: number) {
    let tmpAry: Array<CourseFilter> = [];
    await this.apis.feature.courseManagementFilterCourse.queryCourseManagementFilterCourses({ courseManagementFilterId: courseManagementFilterId } as QueryCourseManagementFilterCourseRequest)
      .then((response) => {
        if (response.data.records) {
          response.data.records.map((x) => {
            let courseManagementTypeId = this.courseManagementMap.get(x.courseManagementId)?.courseManagementTypeId;
            tmpAry.push({
              id: x.id,
              courseManagementId: x.courseManagementId,
              courseManagementTypeId: courseManagementTypeId,
            });
          })
        }
      })
    return tmpAry;
  }

  async queryCourseManagementFilterResp(courseManagementFilterId: number) {
    let tmpAry: Array<RespFilter> = [];
    let request = {
      courseManagementFilterId: courseManagementFilterId,
    } as QueryCourseManagementFilterRespRequest;
    await this.apis.feature.courseManagementFilterResp.queryCourseManagementFilterResps(request)
      .then((response) => {
        response.data.records.map((x) => {
          let ministryId = this.ministryRespMap.get(x.ministryRespId)?.ministryId;
          tmpAry.push({ id: x.id, ministry: ministryId, ministryResp: x.ministryRespId })
        });
      });
    return tmpAry;
  }

  courseManagementFilterPastoralMap = new Map();
  async queryCourseManagementFilterPastorals(courseManagementFilterId: number) {
    let tmpAry: Array<number> = [];
    let request = {
      courseManagementFilterId: courseManagementFilterId,
    } as QueryCourseManagementFilterPastoralRequest;
    await this.apis.feature.courseManagementFilterPastoral.queryCourseManagementFilterPastorals(request)
      .then((response) => {
        response.data.records.map((x) => {
          tmpAry.push(x.pastoralId);
          this.courseManagementFilterPastoralMap.set(x.pastoralId, x.id);
        });
      });
    return tmpAry;
  }

  async getCourseManagement(courseManagementId: number) {
    await this.apis.feature.courseManagement.getCourseManagement(courseManagementId)
      .then((response) => {
        if (response.data) {
          this.courseManagementTypeId = response.data.courseManagementTypeId;
        }
      })
  }

  courseManagementMap = new Map<number, CourseManagementView>();
  async getCourseManagements() {
    await this.apis.feature.courseManagement.fetchCourseManagements()
      .then((response) => {
        if (response.data) {
          response.data.map((x) => {
            this.courseManagementMap.set(x.id, x);
          })
        }
      })
  }

  async getCourseManagementFilter(courseManagementFilterId: number) {
    const res = await this.apis.feature.courseManagementFilter.getCourseManagementFilter(courseManagementFilterId);
    await this.getCourseManagement(res.data.courseManagementId);
    Object.assign(this.form, res.data);
  }

  ministryRespList = Array<MinistryRespView>();
  ministryRespMap = new Map<number, MinistryRespView>();
  async getMinistryResp() {
    await this.apis.feature.ministryResp.fetchMinistryResps()
      .then((response) => {
        if (response.data) {
          this.ministryRespList = response.data;
          response.data.map((x) => {
            this.ministryRespMap.set(x.id, x);
          })
        }
      })
  }

  getIDs<T extends RespFilter | CourseFilter>(ary: Array<T>): Array<number | undefined> {
    let IDs: Array<number | undefined> = [];
    ary.map((x) => {
      IDs.push(x.id);
    })
    return IDs;
  }
}
</script>

<style lang="scss" scoped></style>
