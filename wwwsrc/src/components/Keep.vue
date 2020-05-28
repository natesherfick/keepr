<template>
  <div class="Keep" display="inline-block">
<div class="card my-3" style="width: 18rem;">
  <img v-show=keepData.img class="card-img-top" :src=keepData.img alt="Error loading image">
  <div class="card-body">
    <h5 class="card-title">{{keepData.name}}</h5>
    <p class="card-text">{{keepData.description}}</p>
    <p>{{keepData.views}}, {{keepData.keeps}}</p>
    <button v-show="this.$auth.user.sub == keepData.userId" class="btn btn-danger" @click="deleteKeep(keepData.id)">x</button>
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
      this.$store.dispatch("deleteKeep", keepId)
    },

  },
  components:{}
}
</script>


<style scoped>

</style>