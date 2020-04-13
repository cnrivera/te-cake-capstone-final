<template>
  <div id="confirmorder">

  <h2>Your Order is Confirmed</h2>
  <ul>
  <li>Order ID: {{order.orderId}}</li>
  <li>Pickup Date and Time: {{order.date}} at {{order.time}}</li>
  <li>Cake Name: {{order.cake.name}}</li>
  <li>Style: {{order.cake.style}} </li>
  <li>Size: {{order.cake.size}}</li>
  <li>Flavor: {{order.cake.flavor}}</li>
  <li>Frosting: {{order.cake.flavor}}</li>
  <li>Filling: {{order.cake.filling}}</li>
  <li>Quantity: {{order.quantity}}</li>
  <li>Writing on Cake: {{order.cake.writingOnCake}}</li>
  <li>Customer Name: {{order.customerName}} </li>              
  <li>Email: {{order.email}} </li>
  <li>Customer Phone: {{order.phoneNumber}}</li>
  </ul>

</div>
</template>

<script>
export default {
  name: 'confirm-order',
  data() {
      return {
        orders: []
    };
  },
  
  methods: {
    
    getOrder(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/getOrder/${id}`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.orderInfo.cake = data;
      })
      .catch((err) => console.error(err));
    }
  },
  created() {
    this.getOrder(this.$route.params.id);
  }
}
</script>

<style>
#ordercake {
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
#ordercake .ordercakedetails {
  width: 63%;
}
#ordercake .ordercakeimg {
  position: relative;
  width: 35%;
}
#ordercake .ordercakeimg > img {
  border-radius: 5px;
  width: 100%;
}
.ordercakedetails .orderforms {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
.ordercakedetails .orderforms div {
  width: 49%;
}
</style>