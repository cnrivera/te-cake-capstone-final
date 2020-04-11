<template>
    <div id="pendingorderscontainer"> 
         <h1>All Pending Orders</h1>    
      <div v-for="order in orders" :key="order.name" class="orderdetails">
      <ul>
        <li><b>Customer Name:</b> {{order.customerName}}</li>
        <li><b>Pick up Date and Time:</b> {{order.date}} {{order.time}}</li>
        <li><b>Pick up Date and Time:</b> {{order.pickupDateTime}}</li>
        
      </ul>
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