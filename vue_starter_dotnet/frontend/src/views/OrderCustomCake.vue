<template>
<div id="ordercustomcake">

  <form @submit.prevent="submitOrder(orderInfo.cake.size.basePrice, orderInfo.cake.size.size, )">
    <div class="alert alert-danger" role="alert" v-if="createOrderErrors">
      There were problems creating this order.
    </div>

    <div class="form-group">
      <label for="style">Style:</label>
      <select class="form-control" v-model="orderInfo.cake.style" @change.prevent="FilterSizes(orderInfo.cake.style.id)">
        <option v-for="style in cake.styles" :key="style.id" :value="style">{{ style.style }}</option>
      </select>
    </div>
      
    <div class="form-group">
      <label for="size">Size:</label>
      <select class="form-control" v-model="orderInfo.cake.size">
        <option v-for="size in cake.sizes" :key="size.id" :value="size">{{ size.size }} ${{size.basePrice}}</option>
      </select>
    </div>
    
    <div class="form-group">
      <label for="flavor">Flavor:</label>
      <select class="form-control" v-model="orderInfo.cake.flavor">
        <option v-for="flavor in cake.flavors" :key="flavor.id" :value="flavor.flavor">{{ flavor.flavor }}</option>
      </select>
    </div>
    
    <div class="form-group">
      <label for="frosting">Frosting:</label>
      <select class="form-control" v-model="orderInfo.cake.frosting">
        <option v-for="frosting in cake.frostings" :key="frosting.id" :value="frosting.frosting">{{ frosting.frosting }}</option>
      </select>
    </div>
      
    <div class="form-group">
      <label for="filling">Filling:</label>
      <select class="form-control" v-model="orderInfo.cake.filling">
        <option v-for="filling in cake.fillings" :key="filling.id" :value="filling.filling">{{ filling.filling }}</option>
      </select>
    </div>

    <div class="form-group">
      <label for="name">Quantity:</label>
      <input v-model="orderInfo.quantity" type="text" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="price">Name:</label>
      <input v-model="orderInfo.customerName" type="text" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="name">Phone:</label>
      <input v-model="orderInfo.phoneNumber" type="tel" class="form-control" required pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
        placeholder="123-456-7890" />
    </div>

    <div class="form-group">
      <label for="name">Email:</label>
      <input v-model="orderInfo.email" type="email" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="name">Date:</label>
      <input v-model="orderInfo.date" type="date" class="form-control" required />
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

    <div class="form-group" v-if="orderInfo.style != 'Cupcake'">
      <label for="name">Add Message to Cake ($10.00):</label>
      <input v-model.trim="orderInfo.writingOnCake" type="text" class="form-control" />
      <input type="hidden" v-model="orderInfo.id"/>
    </div>

    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit Order</button>
  </form>

</div>

  
</template>

<script>
export default {
  name: 'order-cake',
  data() {
    return {
      cake: {
        styles: [],
        sizes: [],
        flavors: [],
        frostings: [],
        fillings: []
      },
      orderInfo: {
        quantity: '',
        customerName: '',
        phoneNumber: '',
        email: '',
        writingOnCake: 'none',
        orderStatus: 'pending',
        date: '',
        time: '',
        cake: {
          name: 'Custom',
          style: '',
          size: '',
          flavor: '',
          frosting: '',
          filling: '',
          price: 25
        }
      },
      createOrderErrors: false,
    };
  },
  
  methods: {
    submitOrder(baseprice, size) {
      this.orderInfo.cake.price = baseprice;
      this.orderInfo.cake.size = size;

      if (this.orderInfo.writingOnCake !== 'none'){
        this.orderInfo.cake.price += 10;
      } 
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
            return response.json();
          }     
        })
        .then( (data)=>{
           let createdId=data;
           this.$router.push({ path: `/ordercustomcake/${createdId}`});
         
      })
    },
    getFrostingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFrostings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.frostings = data;
      })
      .catch((err) => console.error(err));
    },
    getFillingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFillings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.fillings = data;
      })
      .catch((err) => console.error(err));
    },
    getFlavorsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFlavors`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.flavors = data;
      })
      .catch((err) => console.error(err));
    },
    getStylesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllStyles`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.styles = data;
      })
      .catch((err) => console.error(err));
    },
    getSizesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizes`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.sizes = data;
      })
      .catch((err) => console.error(err));
    },
     FilterSizes(id){
        this.cake.sizes = this.cake.sizes.filter( u => {
          return u.styleId == id
        });
     }
  },
  created() {
    this.getFrostingsList();
    this.getFillingsList();
    this.getFlavorsList();
    this.getSizesList();
    this.getStylesList();
  }
}
</script>

<style>
#ordercustomcake {
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}
#ordercustomcake form {
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
#ordercustomcake div {
  width: 49%;
}
</style>