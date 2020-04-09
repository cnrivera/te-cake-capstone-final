<template>
  <div id="ordercake">

    <div class="ordercakeimg">
      <img v-bind:src="require('../../src/assets/' + cake.imageName)" /> 
      <div class="price">${{cake.price}}</div>
    </div>

    <div class="ordercakedetails">
      <h3>{{cake.name}}</h3>
      <p>{{cake.description}}</p>
      <ul>
        <li><b>Style:</b> {{cake.style}}</li>
        <li><b>Size:</b> {{cake.size}}</li>
        <li><b>Flavor:</b> {{cake.flavor}}</li>
        <li><b>Frosting:</b> {{cake.frosting}}</li>
        <li><b>Filling:</b> {{cake.filling}}</li>
      </ul>

      <form class="form-register" @submit.prevent="submitOrder">
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
          <input v-model="orderInfo.name"
          type="text"
          class="form-control"
          required
          />
        </div>
        <div class="form-group">
        <label for="name">Phone:</label>
        <input v-model="orderInfo.phone"
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
      <div class="form-group" v-if="cake.style != 'Cupcake'">
      <label for="name">Message:</label>
      <input v-model="orderInfo.message"
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
  name: 'orderCake',
  data() {
    return {
      cake: [],
      orderInfo: {
        quantity: '',
        name: '',
        phone: '',
        email: '',
        message: '',
        
        cakename: '',
        style: '',
        size: '',
        flavor: '',
        frosting: '',
        filling: '',
        totalcost: '',
      },
    }
  },
  methods: {
    createCake() {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/newCake`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.cake),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes' });
          } else {
            this.createCakeErrors = true;
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
        this.cake = data;
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