<template>
  <div id="pendingorderscontainer"> 
    <table id="orders" class = "table-bordered table-hover table-striped"> 
      <thead>
        <tr>
          <th>Order ID Number</th>
          <th>Pick Up Time</th>
          <th>Order Details</th>
          <th>Customer Details</th>
          <th>Order Status</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in orders" :key="order.name" class="orderdetails">
          <td >{{order.orderId}}</td>
          <td>{{order.date}} at {{order.time}}</td>
          <td><b>Cake Name:</b> {{order.cake.name}} <br/> <b>Style:</b> {{order.cake.style}} <br/> <b>Size:</b> {{order.cake.size}}<br/>
          <b>Flavor:</b> {{order.cake.flavor}} <br/> <b>Frosting:</b> {{order.cake.flavor}} <br/> <b>Filling:</b> {{order.cake.filling}} <br/> <b>Quantity:</b> {{order.quantity}}
          <br/><b>Writing on Cake:</b> {{order.cake.writingOnCake}}</td>
          <td><b>Customer Name:</b> {{order.customerName}} <br/> <b>Email:</b> {{order.email}} <br/> <b>Customer Phone:</b> {{order.phoneNumber}}</td>
          <td><select v-model="order.orderStatus" v-on:change.prevent="UpdateOrderStatus(order.orderId, order.orderStatus)">
    <option v-for="status in statusChange" :key="status" :value="status">
      {{ status }} 
    </option>
</select></td>
        </tr>
      </tbody>
    </table>
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
table{
  margin-top: 30px;
  margin-left: 2%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}

h1{
  padding: 5px;
}
th {  
    font-weight: bold; /* Make sure they're bold */
}

td, th {  
    padding: 5px;
}
td{

}
.table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
  background-color: hsla(187, 53%, 39%, 0.7);
  color: white;
}

</style>