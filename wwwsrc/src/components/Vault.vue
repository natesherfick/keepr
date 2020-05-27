<template>
  <div class="Vault">
  <div @click="goToVault()">
    {{vaultData.name}}
  </div>

  </div>
</template>


<script>
export default {
  name: 'Vault',
  props: ["vaultData"],
  data(){
    return {}
  },
  mounted() {

  }, 
  computed:{
    
  },
  methods:{
    goToVault(vaultId){
      console.log("going");
      this.$store.commit("setVaultKeeps", [])
      this.$store.dispatch("getVaultKeeps", this.vaultData.id)}
  },
  components:{}
}
</script>


<style scoped>

</style>