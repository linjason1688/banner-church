export const StringUtility = {
  convertStringToNumber: (str: string) => {
    if (!str) {
      str = "";
    }
    return parseInt(str, 36);
  },
  isNullOrEmpty: (str: string) => {
    return str === undefined || str === null || str === "";
  },
  validateEmail: (email: string) => {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/.test(email);
  },
};
