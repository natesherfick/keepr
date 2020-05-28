<template>
  <div class="Vault">
  <div @click="goToVault()">
    <h3>{{vaultData.name}}</h3>
    <button class="btn-small btn-danger" @click="deleteVault(vaultData.id)">x</button>
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
      if(window.confirm("Are you sure you want to delete this vault?")){
      this.$store.dispatch("deleteVault", vaultId)
      }
    },
  },
  components:{}
}
</script>


<style scoped>

</style>