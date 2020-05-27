<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <CreateKeep></CreateKeep>
    <Keep v-for="publicKeep in publicKeeps" :key="publicKeep.id" :keepData="publicKeep"/>

  </div>
</template>

<script>
import Keep from "../components/Keep.vue"
import CreateKeep from "../components/CreateKeep.vue"
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
    CreateKeep
    }
};
</script>
