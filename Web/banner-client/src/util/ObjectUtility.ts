import { HashMap, KeyValuePair } from "src/data/dto";

function deepClone<T>(data: T): T {
  return JSON.parse(JSON.stringify(data)) as T;
}

function getValueOf<T>(data: unknown, path: string): T {
  const value = path.split(".").reduce((acc, item) => {
    // prevent undefined property access
    if (!acc) {
      return undefined;
    }
    const nested = acc as HashMap<string>;

    return nested[item];
  }, data);
  return value as T;
}

function retrieveClassName(obj: unknown) {
  return getValueOf(obj, "__proto__.constructor.name");
}

function getKeyValues<T>(obj: unknown): KeyValuePair<string, T>[] {
  return Object.getOwnPropertyNames(obj).map((key) => {
    return {
      key,
      value: getValueOf(obj, key),
    };
  });
}

/**
 * copy fields that dest owned
 * @param src
 * @param dest
 */
function copyProperties(src: unknown, dest: unknown) {
  Object.getOwnPropertyNames(dest).forEach((n) => {
    const value = getValueOf(src, n);
    if (value !== undefined) {
      (dest as Record<string, unknown>)[n] = value;
    }
  });
}

export const ObjectUtility = {
  deepClone,
  getValueOf,
  retrieveClassName,
  getKeyValues,
  copyProperties,
};
