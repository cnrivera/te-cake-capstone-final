<template>
    <div id="adminmenu">
        <button v-on:click="openCreateCake" class="btn btn-info">Create Cake</button>
        <button v-on:click="openPendingOrders" class="btn btn-info">Pending Orders</button>
        <button v-on:click="openToggleCakes" class="btn btn-info">disable cake</button>

        <div v-if="createCakeOpen">
          <create-cake/>
        </div>

        <div v-if="pendingOrdersOpen">
          <pending-orders/>
        </div>

        <div v-if="toggleCakesOpen">
          <cake-availability/>
        </div>

    </div>
</template>

<script>
import CreateCake from '@/components/CreateCake.vue'
import PendingOrders from '@/components/PendingOrders.vue'
import CakeAvailability from '@/components/CakeAvailability.vue'

export default {
  components: {
    CreateCake,
    PendingOrders,
    CakeAvailability,
  },
  data() {
    return {
      createCakeOpen: false,
      pendingOrdersOpen: false,
      toggleCakesOpen: false,
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
    clearScreen() {
      this.createCakeOpen = false;
      this.pendingOrdersOpen = false;
      this.toggleCakesOpen = false;
    },
  }
}
</script>

<style>

</style>