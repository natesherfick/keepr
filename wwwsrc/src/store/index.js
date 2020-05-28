import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

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
    userVaults: [],
    userKeeps: [],
    vaultKeeps: [],
    
  },
  mutations: {
    setPublicKeeps(state, publicKeeps){
      state.publicKeeps = publicKeeps
    },
    setUserVaults(state, userVaults){
      state.userVaults = userVaults
    },
    setUserKeeps(state, userKeeps){
      state.userKeeps = userKeeps
    },
    setVaultKeeps(state, vaultKeeps){
      state.vaultKeeps = vaultKeeps
    },
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({commit, dispatch}) {
      let res = await api.get("keeps")
      commit("setPublicKeeps", res.data)
    },
    async getKeepsByUser({commit, dispatch}, userId) {
      let res = await api.get("keeps/userId/"+ userId)
      commit("setUserKeeps", res.data)
    },
    async getVaults({commit, dispatch}) {
      let res = await api.get("vaults")
      commit("setUserVaults", res.data)
    },
    async getVaultKeeps({commit, dispatch}, vaultId) {
      let res = await api.get("vaults/" + vaultId + "/keeps")
      commit("setVaultKeeps", res.data)
      console.log(res.data);
      
    },
    async createKeep({commit, dispatch}, newKeep) {
      let res = await api.post("keeps", newKeep)
      dispatch("getPublicKeeps")
    },

    async deleteKeep({dispatch}, keepId){
      await api.delete("keeps/"+ keepId)
      dispatch("getPublicKeeps")
    },
    async deleteVault({dispatch}, vaultId){
      await api.delete("vaults/"+ vaultId)
      dispatch("getVaults")
    },


  }
});
