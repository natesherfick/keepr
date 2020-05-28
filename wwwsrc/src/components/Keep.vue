<template>
  <div class="Keep px-1 d-inline-block" style="min-width:12rem; max-width:20rem">
<div class="card">
  <img v-show=keepData.img class="card-img-top" :src=keepData.img alt="Error loading image">
  <div class="card-body">
    <h5 class="card-title">{{keepData.name}}</h5>
    <p class="card-text">{{keepData.description}}</p>
    <p>{{keepData.views}}, {{keepData.keeps}}</p>
    <button v-show="this.$auth.user.sub == keepData.userId" class="btn-small btn-danger" @click="deleteKeep(keepData.id)">x</button>
  </div>
</div>

  </div>
</template>


<script>
export default {
  name: 'Keep',
  props: ["keepData"],
  data(){
    return {}
  },
  mounted() {
    
  }, 
  computed:{
    

  },
  methods:{
    deleteKeep(keepId){
      if(window.confirm("Are you sure you want to delete this vault?")){
      this.$store.dispatch("deleteKeep", keepId)
      }
    },

  },
  components:{}
}
</script>


<style scoped>

</style>