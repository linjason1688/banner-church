import { CourseTimeSchedules$ } from "src/services/CourseTimeSchedule";

export interface CourseAppendix$ {
  appendixType: string;
  path: string;
}

export interface CoursePrice$ {
  priceName: string;
  price: number;
  isDueDate: string;
}

export interface Course$ {
  name: string;
  signUpDateS: string;
  signUpDateE: string;
  description: string;
  classDate: string;
  openDateS: string;
  openDateE: string;
  price: number | null;
  discountPrice: number | null;
  coursePrices: Array<CoursePrice$>;
  courseAppendices: Array<CourseAppendix$>;
  courseTimeSchedules: Array<CourseTimeSchedules$>;
  cover: string;
  formFile: string;
}

export function convertPrice(e: Course$) : number | null {
  if (e.coursePrices) {
    let result = null;
    e.coursePrices.forEach(e => {
      if (e.isDueDate == "N") {
        result = `${e.priceName} NT$${e.price}`;
      }
    });
    return result;
  }
  return null;
}

export function convertDiscountPrice(e: Course$) : number | null {
  if (e.coursePrices) {
    let result = null;
    e.coursePrices.forEach(e => {
      if (e.isDueDate == "Y") {
        result = `${e.priceName} NT$${e.price}`;
      }
    });
    return result;
  }
  return null;
}
