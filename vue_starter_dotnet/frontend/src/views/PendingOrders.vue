<template>
    <div id="pendingorderscontainer"> 
         <h1>testing</h1>    
     
      <div v-for="order in orders" :key="order.name" class="orderdetails">
            <h2>testing2</h2>
      </div>
      
  </div>
</template>

<script>
export default {
    name: "pending-orders",
    data() {
      return {
        orders: [],
      }
    },
    methods: {
    getPendingOrders() {
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/getAllOrders`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.orders = data;
      })
      .catch((err) => console.error(err));
    },
  },
  created() {
    this.getPendingOrders();
  }
}
</script>


<style>

</style>