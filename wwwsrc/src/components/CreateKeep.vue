<template>
  <div class="CreateKeep">
    <form id="keepForm" @submit.prevent="createKeep()">
    <div class="form-group">
      <label for="name">Name*</label>
      <input required v-model="newKeep.name" type="text" name="name" class="form-control" placeholder="Enter Keep Name"/>
    </div>
    <div class="form-group">
      <label for="description">Description*</label>
      <input required v-model="newKeep.description" type="text" name="description" class="form-control" placeholder="Enter Keep Description"/>
    </div>
    <div class="form-group">
      <label for="img">Image URL</label>
      <input v-model="newKeep.img" type="text" name="img" class="form-control" placeholder="Enter Image URL"/>
            <small>*required fields</small>

    </div>

    <div class="form-check">
    <input v-model="newKeep.isPrivate" class="form-check-input" type="checkbox" value="" id="isPrivateCheck">
    <label class="form-check-label" for="isPrivateCheck">
    Hide your Keep from others
  </label>
  <div>
  <button type="submit" class="btn btn-light">Create Keep</button>
  </div>
</div>

</form>
  </div>
</template>


<script>
export default {
  name: 'CreateKeep',
  data(){
    return {
      isPrivate: false,
      newKeep: {}
    }
  },
  mounted() {}, 
  computed:{},
  methods:{
    createKeep(){
      debugger
      this.$store.dispatch("createKeep", this.newKeep);
      document.getElementById("keepForm").reset();
    }
  },
  components:{}
}
</script>


<style scoped>

</style>