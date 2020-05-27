<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <Vault v-for="userVault in userVaults" :key="userVault.id" :vaultData="userVault"/>
    public {{ publicKeeps }} user {{ userKeeps }}
  </div>
</template>

<script>
import Vault from "../components/Vault.vue"
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getVaults")
  },
  computed: {
    userVaults(){return this.$store.state.userVaults}
  },
  components:{
    Vault
  }
};
</script>

<style></style>
