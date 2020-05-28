<template>
  <div class="home container">
    <div class="row">
      <h2 class="col-5 text-center">Create a Keep</h2><h2 class="col-5 text-center">Create a Vault</h2>
    <CreateKeep class="col-5" v-show="this.$auth.user"></CreateKeep>
    <CreateVault class="col-5" v-show="this.$auth.user"></CreateVault>
    </div>
    <Keep v-for="publicKeep in publicKeeps" :key="publicKeep.id" :keepData="publicKeep"/>

  </div>
</template>

<script>
import Keep from "../components/Keep.vue"
import CreateKeep from "../components/CreateKeep.vue"
import CreateVault from "../components/CreateVault.vue"
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps(){return this.$store.state.publicKeeps},
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps")
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components:{
    Keep,
    CreateKeep,
    CreateVault
    }
};
</script>
