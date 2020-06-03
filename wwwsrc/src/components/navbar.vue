<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link class="navbar-brand" :to="{ name: 'home' }">Keepr</router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link"
            >Home</router-link
          >
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }"
            >My-Dashboard</router-link
          >
        </li>
      </ul>
      <span class="navbar-text">


        <!-- Button trigger modal -->
<button v-show="this.$auth.user" type="button" class="btn btn-primary mr-3" data-toggle="modal" data-target="#keepModal">
  Create Keep
</button>

<button v-show="this.$auth.user" type="button" class="btn btn-primary mr-3" data-toggle="modal" data-target="#vaultModal">
  Create Vault
</button>

<!-- Modal -->
<div class="modal fade" id="keepModal" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="keepModalLabel">Create Keep</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <CreateKeep></CreateKeep>
      </div>
    </div>
  </div>
</div>


<div class="modal fade" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="vaultModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="vaultModalLabel">Create Keep</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <CreateVault/>
      </div>
    </div>
  </div>
</div>


        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";
import CreateKeep from "../components/CreateKeep.vue"
import CreateVault from "../components/CreateVault.vue"

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  },
  components: {
    CreateKeep,
    CreateVault
  }
};
</script>

<style></style>
