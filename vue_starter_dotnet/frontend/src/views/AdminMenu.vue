<template>
    <div id="adminmenu">
        <button v-on:click="openCreateCake">Create Cake</button>
        <button v-on:click="openPendingOrders">Pending Orders</button>
        <button v-on:click="openToggleCakes">disable cake</button>


        <div v-if="createCakeOpen">
          <p>Create Cake Page</p>
        </div>


        <div v-if="pendingOrdersOpen">
          <p>Pending Orders Page</p>
        </div>


        <div v-if="toggleCakesOpen">
          <p>Toggle Cakes page</p>
        </div>

    </div>
</template>

<script>
export default {
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