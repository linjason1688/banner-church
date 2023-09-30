import { HashMap } from "src/data/dto";
import { Store } from "vuex";

interface FakeStore {
  state: HashMap<unknown>;
  getters: HashMap<unknown>;
  _actions: HashMap<unknown>;
  _mutations: HashMap<unknown>;
  _modules: {
    root: {
      _children: HashMap<unknown>;
    };
  };
}

/**
 * 目前沒有使用
 * OBSOLETE
 * @param arg
 */
export function useModuleProxy(arg: Store<unknown>) {
  const modules: HashMap<unknown> = {};

  const store = arg as unknown as FakeStore;

  const moduleNames = Object.getOwnPropertyNames(store._modules.root._children);

  moduleNames.forEach((m) => {
    const proxy = {
      state: {} as unknown,
      actions: {} as HashMap<unknown>,
      mutations: {} as HashMap<unknown>,
      getters: {} as HashMap<unknown>,
    };
    //
    Object.getOwnPropertyNames(store._actions)
      .filter((x) => x.startsWith(m))
      .forEach((x) => {
        proxy.actions[x.replace(`${m}/`, "")] = (payload: unknown) => {
          return arg.dispatch(x, payload);
        };
      });
    //
    Object.getOwnPropertyNames(store._mutations)
      .filter((x) => x.startsWith(m))
      .forEach((x) => {
        proxy.mutations[x.replace(`${m}/`, "")] = (payload: unknown) => {
          return arg.commit(x, payload);
        };
      });
    //
    Object.getOwnPropertyNames(store.getters)
      .filter((x) => x.startsWith(m))
      .forEach((x) => {
        Object.defineProperty(
          //
          proxy.getters,
          x.replace(`${m}/`, ""),
          { get: () => store.getters[x] }
        );
      });

    proxy.state = store.state[m];

    //
    modules[m] = proxy;
  });

  Object.assign(store, modules);

  // to see what vuex store looks like....
  console.log(store, modules);
}
