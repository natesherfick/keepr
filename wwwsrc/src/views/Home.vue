<template>
  <div class="home container-fluid">

<br>
   <div class="card-columns">
    <Keep v-for="publicKeep in publicKeeps" :key="publicKeep.id" :keepData="publicKeep"/>
    </div>

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
