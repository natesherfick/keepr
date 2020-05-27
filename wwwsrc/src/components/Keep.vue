<template>
  <div class="Keep">
<div class="col-4">
  {{keepData.name}}
</div>
<button class="btn btn-danger" @click="deleteKeep(keepData.id)">X</button>

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