<template>
  <div id="pendingorderscontainer"> 
    <h1>All Pending Orders</h1>    
    <div v-for="order in orders" :key="order.name" class="orderdetails">
    <ul>
      <li><b>Order Number:</b> {{order.orderId}}
      <li><b>Customer Name:</b> {{order.customerName}}</li>
      <li><b>Pick up Date and Time:</b> {{order.date}} {{order.time}}</li>
      <li><b>Current Order Status:</b>{{order.orderStatus}}</li>
      <li><label for="size"><b>Change Order Status To:</b></label>
    <select v-model="order.orderStatus" v-on:change.prevent="UpdateOrderStatus(order.orderId, order.orderStatus)">
    <option v-for="status in statusChange" :key="status" :value="status">
      {{ status }} 
    </option>
</select>
</li>
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
        statusChange: [
          'pending',
          'canceled',
          'ready',
          'completed'
        ]
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
  UpdateOrderStatus(orderId, orderStatus) {
    let orderNew = {
        orderId: orderId,
        orderStatus: orderStatus
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/updateOrderStatus`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(orderNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getPendingOrders();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
  created() {
    this.getPendingOrders();
  }
}
</script>


<style>

</style>