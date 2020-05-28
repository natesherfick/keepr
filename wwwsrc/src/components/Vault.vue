<template>
  <div class="Vault">
  <div @click="goToVault()">
    {{vaultData.name}}
    <button class="btn btn-danger" @click="deleteVault(vaultData.id)">x</button>
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
      this.$store.dispatch("getVaultKeeps", this.vaultData.id)
      },
    deleteVault(vaultId){
      this.$store.dispatch("deleteVault", vaultId)
    },
  },
  components:{}
}
</script>


<style scoped>

</style>