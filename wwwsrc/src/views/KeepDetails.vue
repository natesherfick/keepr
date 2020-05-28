<template>
  <div class="KeepDetails">
{{activeKeep.name}}

  </div>
</template>


<script>
export default {
  name: 'keepDetails',
  data(){
    return {}
  },
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
  }, 
  computed:{
    activeKeep(){return this.$store.state.activeKeep
    },
  },
  methods:{},
  components:{}
}
</script>


<style scoped>

</style>