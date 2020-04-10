<template>
  <div id="ordercake">

 <!--    <div class="ordercakeimg">
      <img v-bind:src="require('../../src/assets/' + orderInfo.cake.imageName)" /> 
      <div class="price">${{orderInfo.cake.price}}</div>
    </div> -->

   <div class="form-group">
      <label for="style">Style:</label>
      <select v-model="selected">
      <option v-for="style in orderInfo.cake.styles" :key="style.id" :value="style.style">
       {{ style.style }}
      </option>
</select>
<span>Selected: {{ selected }}</span>

      class="form-control"
      required
      />
    </div>


<!--     <div class="form-group">
      <label for="size">Size:</label>
      <input v-model="cake.size"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="flavor">Flavor:</label>
      <input v-model="cake.flavor"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="icing">Frosting:</label>
      <input v-model="cake.frosting"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="filling">Filling:</label>
      <input v-model="cake.filling"
      type="text"
      class="form-control"
      required
      />
    </div> -->


    <!-- <div class="ordercakedetails">
      <h3>{{orderInfo.cake.name}}</h3>
      <p>{{orderInfo.cake.description}}</p>
      <ul>
        <li><b>Style:</b> {{orderInfo.cake.style}}</li>
        <li><b>Size:</b> {{orderInfo.cake.size}}</li>
        <li><b>Flavor:</b> {{orderInfo.cake.flavor}}</li>
        <li><b>Frosting:</b> {{orderInfo.cake.frosting}}</li>
        <li><b>Filling:</b> {{orderInfo.cake.filling}}</li>
      </ul> -->

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
        <div class="form-group">
        <label for="name">Date:</label>
        <input v-model="orderInfo.date"
        type="text"
        class="form-control"
        required
        />
        </div>
        <div class="form-group">
        <label for="name">Time:</label>
        <select v-model="orderInfo.time" class="form-control">
          <option value="9:00am">9:00am</option>
          <option value="10:00am">10:00am</option>
          <option value="11:00am">11:00am</option>
          <option value="12:00am">12:00am</option>
          <option value="1:00pm">1:00pm</option>
          <option value="2:00pm">2:00pm</option>
          <option value="3:00pm">3:00pm</option>
          <option value="4:00pm">4:00pm</option>
          <option value="5:00pm">5:00pm</option>
        </select>
      </div>

      </div>
      <div class="form-group" v-if="orderInfo.cake.style != 'Cupcake'">
      <label for="name">Message:</label>
      <input v-model="orderInfo.writingOnCake"
      type="text"
      class="form-control"
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
        date: '',
        time: '',

        cake: [
          {
            name: 'Custom',
            styles: [
                {id: 1, style: 'sheet cake'},
                {id: 2, style: 'layer cake'}
              ],
            sizes: [
              {size: 'full-pan'},
              {size: 'half-pan'},
              {size: '3-tier'},
              {size: '12-inch'}
            ],
            flavors: [
              {flavor: 'vanilla'},
              {flavor: 'chocolate'}
            ],
            frostings: [
              {frosting: 'vanilla buttercream'},
              {frosting: 'chocolate buttercream'}
            ],
            fillings: [
              {filling: 'raspberry'},
              {filling: 'orange cream'}
            ],
            price: ''
          }
          
        ]
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
    
  },
  created() {
    // this.getCake(this.$route.params.id);
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