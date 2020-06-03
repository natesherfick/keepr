<template>
<div class="KeepDetails container-fluid">
  <div class="row">
    <div class="col-7 mx-auto">
      <h2 class="text-center" v-if="!editingName" @click="editingName = true">
        <b>{{activeKeep.name}}</b>
      </h2>
      <div v-else class="mb-2 text-center">
        <input class="text-center" type="text" width="30" @keyup.enter="editKeepName()" v-model="activeKeep.name" />
      </div>

      <h4 class="text-center">{{activeKeep.description}}</h4>

  <img v-show=activeKeep.img class="card-img-top" :src=activeKeep.img alt="Error loading image">
<div class="row">
      <!-- <div class="col-6 text-right"><b>Views</b></div>
      <div class="col-6"><b>Keeps</b></div>
      <div class="col-6 text-right">{{activeKeep.views}}</div>
      <div class="col-6">{{activeKeep.keeps}}</div> -->

      <div class="dropdown col-6 text-right">
  <button class="btn btn-secondary dropdown-toggle" @click="getVaults()" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Add Keep to a Vault
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a v-for="userVault in userVaults" :key="userVault.id" @click="addKeepToVault(userVault.id)">{{userVault.name}}</a>
  </div>
</div>



      <div class="col-6"><button v-if="this.$auth.user.sub == activeKeep.userId" class="btn btn-danger" @click="deleteKeep(activeKeep.id)">delete</button></div>
</div>

          
</div>
  </div>



</div>
</template>


<script>
export default {
  name: 'keepDetails',
  data(){ 
    return {
    editingName: false,
    editingDescription: false,
    }
  },
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
    console.log("vaults?",this.$store.state.userVaults);
    
  }, 
  computed:{
    activeKeep(){return this.$store.state.activeKeep
    },
    userVaults(){return this.$store.state.userVaults
    },
    getVaults(){this.$store.dispatch("getVaults")
    },
    
  },
  methods:{
    editKeepName() {
      console.log(this.activeKeep);
      this.$store.dispatch("editKeepName", this.activeKeep)
      this.editingName = false
    },
       deleteKeep(keepId){
      if(window.confirm("Are you sure you want to delete this keep?")){
      this.$store.dispatch("deleteKeep", keepId)
      this.$router.push({
      name:"Home"})
      location.reload()
      }
    },
    addKeepToVault(userVaultId){
      let vaultKeep = {vaultId: userVaultId, keepId: this.activeKeep.id};
      this.$store.dispatch("addKeepToVault", vaultKeep)
      console.log("adding keep to vault", vaultKeep);
    },
  },
  components:{}
}
</script>


<style scoped>

</style>