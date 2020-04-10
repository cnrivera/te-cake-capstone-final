<template>
  <div id="ordercake">

    <div class="ordercakeimg">
      <img v-bind:src="require('../../src/assets/' + orderInfo.cake.imageName)" /> 
      <div class="price">${{orderInfo.cake.price}}</div>
    </div>

    <div class="ordercakedetails">
      <h3>{{orderInfo.cake.name}}</h3>
      <p>{{orderInfo.cake.description}}</p>
      <ul>
        <li><b>Style:</b> {{orderInfo.cake.style}}</li>
        <li><b>Size:</b> {{orderInfo.cake.size}}</li>
        <li><b>Flavor:</b> {{orderInfo.cake.flavor}}</li>
        <li><b>Frosting:</b> {{orderInfo.cake.frosting}}</li>
        <li><b>Filling:</b> {{orderInfo.cake.filling}}</li>
      </ul>

      <form class="form-register" @submit.prevent="submitOrder">
        <div class="alert alert-danger" role="alert" v-if="createOrderErrors">
        There were problems creating this order.
      </div>
      <div class="orderforms">
        <div class="form-group">
          <label for="name">Quantity:</label>
          <input v-model="orderInfo.quantity"
          type="text"
          class="form-control"
          required
          />
        </div>
        <div class="form-group">
          <label for="price">Name:</label>
          <input v-model="orderInfo.customerName"
          type="text"
          class="form-control"
          required
          />
        </div>
        <div class="form-group">
        <label for="name">Phone:</label>
        <input v-model="orderInfo.phoneNumber"
        type="text"
        class="form-control"
        required
        />
        </div>
        <div class="form-group">
        <label for="name">Email:</label>
        <input v-model="orderInfo.email"
        type="text"
        class="form-control"
        required
        />
      </div>

      </div>
      <div class="form-group" v-if="orderInfo.cake.style != 'Cupcake'">
      <label for="name">Message:</label>
      <input v-model="orderInfo.writingOnCake"
      type="text"
      class="form-control"
      required
      />
      <input type="hidden" v-model="orderInfo.id"/>
      </div>
      <button class="btn btn-lg btn-info btn-block" type="submit" >Submit Order</button>
    </form>

    </div>

  </div>
</template>

<script>
export default {
  name: 'order-cake',
  data() {
    return {
      
      orderInfo: {
        quantity: '',
        customerName: '',
        phoneNumber: '',
        email: '',
        writingOnCake: '',
        orderStatus: 'pending',

        cake: []
      },
      createOrderErrors: false,
    };
  },
  methods: {
    submitOrder() {
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/cakeOrder`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.orderInfo),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes' });
          } else {
            this.createOrderErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    getCake(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/getCake/${id}`)
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
    this.getCake(this.$route.params.id);
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