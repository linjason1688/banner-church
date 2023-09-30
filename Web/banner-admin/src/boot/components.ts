import { boot } from "quasar/wrappers";
import AuthGuard from "src/components/AuthGuard.vue";
//
//
import Btn from "src/components/buttons/Btn.vue";
import BtnIconAfter from "src/components/buttons/BtnIconAfter.vue";
import BtnAudit from "src/components/buttons/BtnAudit.vue";
import BtnCreate from "src/components/buttons/BtnCreate.vue";
import BtnCreateSave from "src/components/buttons/BtnCreateSave.vue";
import BtnDetail from "src/components/buttons/BtnDetail.vue";
import BtnDownload from "src/components/buttons/BtnDownload.vue";
import BtnEdit from "src/components/buttons/BtnEdit.vue";
import BtnEditSave from "src/components/buttons/BtnEditSave.vue";
import BtnActionText from "src/components/buttons/BtnActionText.vue";
import BtnExecute from "src/components/buttons/BtnExecute.vue";
import BtnExport from "src/components/buttons/BtnExport.vue";
import BtnHistoryBack from "src/components/buttons/BtnHistoryBack.vue";
import BtnImport from "src/components/buttons/BtnImport.vue";
import BtnRemove from "src/components/buttons/BtnRemove.vue";
import BtnSave from "src/components/buttons/BtnSave.vue";
import BtnSearch from "src/components/buttons/BtnSearch.vue";
import BtnView from "src/components/buttons/BtnView.vue";
import Colon from "src/components/elementary/Colon.vue";
import Detail from "src/components/elementary/Detail.vue";
import DetailColumns from "src/components/elementary/DetailColumns.vue";
import EntityDetail from "src/components/elementary/EntityDetail.vue";
import PaginationNavigator from "src/components/elementary/PaginationNavigator.vue";
import StatusLight from "src/components/elementary/StatusLight.vue";
import Table from "src/components/elementary/Table.vue";
import Tip from "src/components/elementary/Tip.vue";
import SimplePagination from "src/components/elementary/SimplePagination.vue";
//
import FormDatePicker from "src/components/form/FormDatePicker.vue";
import FormDeletable from "src/components/form/FormDeletable.vue";
import FormInput from "src/components/form/FormInput.vue";
import FormSelect from "src/components/form/FormSelect.vue";
import FormSelectBoolean from "src/components/form/FormSelectBoolean.vue";
import FormTimePicker from "src/components/form/FormTimePicker.vue";
import MaskIdInput from "src/components/form/MaskIdInput.vue";
import MaskInput from "src/components/form/MaskInput.vue";
import Landing from "src/components/Landing.vue";
import PageTitle from "src/components/PageTitle.vue";
import PrivilegeGuard from "src/components/PrivilegeGuard.vue";
import FormField from "components/form/FormField.vue";
import FormOptionGroup from "components/form/FormOptionGroup.vue";
import MainLayout from "components/layouts/MainLayout.vue";
import DialogAlert from "components/elementary/DialogAlert.vue";
import FormCard from "components/card/FormCard.vue";
import FormCardFilled from "components/card/FormCardFilled.vue";
import FormGroupMeetup from "components/formGroup/FormGroupMeetup.vue";
import FormPasswordField from "components/form/FormPasswordField.vue";
import FormGroupKid from "components/formGroup/FormGroupKid.vue";
import FormGroupEmergency from "components/formGroup/FormGroupEmergency.vue";
import FormGroupCourseManagement from "components/formGroup/FormGroupCourseManagement.vue";
import SubTitle from "components/SubTitle.vue";
import BtnCancel from "components/buttons/BtnCancel.vue";
import FormStatusCd from "components/business/FormStatusCd.vue";
import FormGender from "components/business/FormGender.vue";
import FormSystemConfig from "components/business/FormSystemConfig.vue";
import FormRow from "components/form/FormRow.vue";
import FormColumn from "components/form/FormColumn.vue";
import FormInputGutter from "components/form/FormInputGutter.vue";
import SaveCancelGroup from "components/SaveCancelGroup.vue";
import BtnUpload from "components/business/BtnUpload.vue";
import FormPastoral from "components/business/FormPastoral.vue";

export default boot(({ app }) => {
  // vue default to kebab-case naming
  app.component("c-auth-guard", AuthGuard);
  app.component("c-landing", Landing);
  app.component("c-page-title", PageTitle);
  app.component("c-p-guard", PrivilegeGuard);

  //
  app.component("c-btn", Btn);
  app.component("c-btn-create", BtnCreate);
  app.component("c-btn-create-save", BtnCreateSave);
  app.component("c-btn-detail", BtnDetail);
  app.component("c-btn-download", BtnDownload);
  app.component("c-btn-edit", BtnEdit);
  app.component("c-btn-edit-save", BtnEditSave);
  app.component("c-btn-action-text", BtnActionText);
  app.component("c-btn-execute", BtnExecute);
  app.component("c-btn-export", BtnExport);
  app.component("c-btn-history-back", BtnHistoryBack);
  app.component("c-btn-import", BtnImport);
  app.component("c-btn-remove", BtnRemove);
  app.component("c-btn-save", BtnSave);
  app.component("c-btn-search", BtnSearch);
  app.component("c-btn-view", BtnView);
  app.component("c-btn-audit", BtnAudit);
  app.component("c-btn-icon-after", BtnIconAfter);
  app.component("c-btn-cancel", BtnCancel);
  app.component("c-btn-upload", BtnUpload);
  app.component("c-savecancel-group", SaveCancelGroup);

  // form
  app.component("c-input-deletable", FormDeletable);
  app.component("c-input", FormInput);
  app.component("c-input-gutter", FormInputGutter);
  app.component("c-select", FormSelect);
  app.component("c-select-bool", FormSelectBoolean);
  app.component("c-date-picker", FormDatePicker);
  app.component("c-time-picker", FormTimePicker);
  app.component("c-field", FormField);
  app.component("c-row", FormRow);
  app.component("c-column", FormColumn);
  app.component("c-option-group", FormOptionGroup);
  app.component("c-password-field", FormPasswordField);
  app.component("c-simple-pagination", SimplePagination);

  // formGroup
  app.component("c-form-group-meetup", FormGroupMeetup);
  app.component("c-form-group-kid", FormGroupKid);
  app.component("c-form-group-emergency", FormGroupEmergency);
  app.component("c-form-group-course-management", FormGroupCourseManagement);

  // form business
  app.component("c-form-status-cd", FormStatusCd);
  app.component("c-form-gender", FormGender);
  app.component("c-form-system-config", FormSystemConfig);
  app.component("c-form-pastoral", FormPastoral);

  // elementary
  app.component("c-mask-input", MaskInput);
  app.component("c-mask-id-input", MaskIdInput);
  app.component("c-status-light", StatusLight);
  app.component("c-table", Table);
  app.component("c-pagination", PaginationNavigator);
  app.component("c-entity-detail", EntityDetail);
  app.component("c-column-detail", DetailColumns);
  app.component("c-colon", Colon);
  app.component("c-detail", Detail);
  app.component("c-tip", Tip);
  app.component("c-dialog-alert", DialogAlert);
  app.component("c-subtitle", SubTitle);

  // layout
  app.component("c-main-layout", MainLayout);

  // card
  app.component("c-form-card", FormCard);
  app.component("c-form-card-filled", FormCardFilled);

});
