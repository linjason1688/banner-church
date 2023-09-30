import { boot } from "quasar/wrappers";
import messages from "src/i18n";
import { createI18n } from "vue-i18n";

// 2. Just right before initializating the I18n instance, use the module

export default boot(({ app }) => {
  // Set i18n instance on app
  const i18n = createI18n({
    globalInstall: true,
    locale: "zh-TW",
    messages,
  });
  //
  app.use(i18n);
});
