<template>
  <div class="VaultKeep px-1 d-inline-block" style="min-width:12rem; max-width:20rem">
<div class="card" >
  <img v-show=keepData.img class="card-img-top" :src=keepData.img alt="Error loading image">
  <div class="card-body">
    <h5 class="card-title" @click="goToKeep()">{{keepData.name}}</h5>
    <p class="card-text">{{keepData.description}}</p>
    <button class="btn btn-danger" @click="removeFromVault()">Remove</button>
    <!-- <p>{{keepData.views}}, {{keepData.keeps}}</p> -->
    
  </div>
</div>

  </div>
</template>


<script>
export default {
  name: 'VaultKeep',
  props: ["keepData"],
  data(){
    return {}
  },
  mounted() {
    
  }, 
  computed:{
    

  },
  methods:{
 
    goToKeep(){
      this.$store.commit("setActiveKeep", {})
      this.$router.push({
      name:"KeepDetails",
      params:{ keepId: this.keepData.id }
      })
    },

    removeFromVault(){
      this.$store.dispatch("removeFromVault", this.keepData.id)
    }

  },
  components:{}
}
</script>


<style scoped>

</style>