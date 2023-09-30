import { computed, reactive, ref } from "vue";

export const useIncrement = function () {
  const state = reactive({ count: 0 });
  const num = ref(0);

  function increment() {
    // state.count++;
    state.count++;
    num.value++;
  }

  const doubleValue = computed(() => {
    return state.count * 2;
  });

  return {
    increment,
    state,
    num,
    doubleValue,
  };
};
