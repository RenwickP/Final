import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    vaults: [],
    activeVaults: {}
  },
  mutations: {
    setKeeps(state, data) {
      state.publicKeeps = data;
    },
    setVaults(state, data) {
      state.vaults = data;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      console.log("from store", res);
      commit("setKeeps", res.data);
    },
    async deleteKeep({ commit, dispatch }, id) {
      console.log("hey look at me you triggered me");
      let res = await api.delete("keeps/" + id);
      console.log("from delete", id);
      dispatch("getKeeps");
      console.log("reading stuff", res.data);
    },
    async makeKeep({ commit, dispatch }, keep) {
      let res = await api.post("keeps", keep);
      dispatch("getKeeps");
    },

    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      console.log("Vaults from store", res.data);
      commit("setVaults", res.data);
    },

    async getVaultKeepByVaultId({ commit, dispatch }, VaultId) {
      let res = await api.get("vaultkeeps/" + VaultId + "/keeps");
      console.log("vk by Id from store", res.data);
    }
  }
});
