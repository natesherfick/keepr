<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <Vault v-for="userVault in userVaults" :key="userVault.id" :vaultData="userVault"/>
    <div v-for="keep in vaultKeeps" :key="keep.id">{{keep.name}}</div>
    <Keep v-for="userKeep in userKeeps" :key="userKeep.id" :keepData="userKeep"/>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import Vault from "../components/Vault.vue"
import Keep from "../components/Keep.vue"
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getVaults")
    this.$store.dispatch("getKeepsByUser", this.$auth.user.id)

  },
  computed: {
    userVaults(){return this.$store.state.userVaults},
    userKeeps(){return this.$store.state.userKeeps},
    vaultKeeps(){return this.$store.state.vaultKeeps},
  },
  methods: {
    
  },
  components:{
    Vault,
    Keep
  }
};
</script>

<style></style>
