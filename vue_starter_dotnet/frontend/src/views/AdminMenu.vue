<template>
<div id="adminmenu">
  <button v-on:click="openPendingOrders" class="btn btn-info">Pending Orders</button>
  <button v-on:click="openCreateCake" class="btn btn-info">Create Cake</button>
  <button v-on:click="openToggleCakes" class="btn btn-info">Disable Cake</button>
  <button v-on:click="openRegester" class="btn btn-info">Register User</button>

  <div v-if="createCakeOpen">
    <create-cake/>
  </div>

  <div v-if="pendingOrdersOpen">
    <pending-orders/>
  </div>

  <div v-if="toggleCakesOpen">
    <cake-availability/>
  </div>

  <div v-if="registerOpen">
    <register/>
  </div>

</div>
</template>

<script>
import CreateCake from '@/components/CreateCake.vue'
import PendingOrders from '@/components/PendingOrders.vue'
import CakeAvailability from '@/components/CakeAvailability.vue'
import Register from '@/components/Register.vue'

export default {
  components: {
    CreateCake,
    PendingOrders,
    CakeAvailability,
    Register,
  },
  data() {
    return {
      createCakeOpen: false,
      pendingOrdersOpen: true,
      toggleCakesOpen: false,
      registerOpen: false,
    };
  },
  methods: {
    openCreateCake() {
      this.clearScreen();
      this.createCakeOpen = true;
    },
    openPendingOrders() {
      this.clearScreen();
      this.pendingOrdersOpen = true;
    },
    openToggleCakes() {
      this.clearScreen();
      this.toggleCakesOpen = true;
    },
    openRegester() {
      this.clearScreen();
      this.registerOpen = true;
    },
    clearScreen() {
      this.createCakeOpen = false;
      this.pendingOrdersOpen = false;
      this.toggleCakesOpen = false;
      this.registerOpen = false;
    },
  }
}
</script>

<style>
  #adminmenu .btn {
    margin: 10px;
    border: 2px solid black;
  }
</style>