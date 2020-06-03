<template>
  <div class="Vault">
  <div @click="goToVault()">

  <h4 class="text-center" v-if="!editingName">
  <b>{{vaultData.name}}</b>
      </h4>
      <div v-else class="mb-2 text-center">
        <input class="text-center" type="text" width="30" @keyup.enter="editVaultName()" v-model="vaultData.name" />
      </div>    
      
      <button class="btn btn-light" @click="editingName = true">Edit Vault</button>

      <button class="btn btn-danger" @click="deleteVault(vaultData.id)">x</button>
  </div>

  </div>
</template>


<script>
export default {
  name: 'Vault',
  props: ["vaultData"],
  data(){
    return {
      editingName: false
    }
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
    editVaultName() {
      console.log(this.vaultData);
      this.$store.dispatch("editVaultName", this.vaultData)
      this.editingName = false
    },
  },
  components:{}
}
</script>


<style scoped>

</style>