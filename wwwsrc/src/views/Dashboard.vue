<template>
  <div class="dashboard container-fluid">
    <h1>My Vaults</h1>
    <div class="row">
      <div class="col-3">
    <Vault v-for="userVault in userVaults" :key="userVault.id" :vaultData="userVault"/>
    </div>
    <div class="col-9">
    <VaultKeep v-for="keep in vaultKeeps" :key="keep.id" :keepData="keep"/>
    </div>
    </div>
    <hr>
    <h1>My Keeps</h1>
    <div class="card-columns">
    <Keep v-for="userKeep in userKeeps" :key="userKeep.id" :keepData="userKeep"/>
    </div>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import Vault from "../components/Vault.vue"
import Keep from "../components/Keep.vue"
import VaultKeep from "../components/VaultKeep.vue"
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
    Keep,
    VaultKeep
  }
};
</script>

<style></style>
