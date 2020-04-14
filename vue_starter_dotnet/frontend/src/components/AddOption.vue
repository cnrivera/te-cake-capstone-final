<template>
<div id="addoptioncontainer">
  <div id="addoptionform">
  <form @submit.prevent="addFrosting">
  <div class="form-group">
      <label for="frosting">Add New Frosting:</label>
      <input v-model="frosting.frosting" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="imageName">New Frosting is currently available:</label>
      <input type="checkbox" v-model="frosting.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addFilling">
  <div class="form-group">
      <label for="frosting">Add New Filling:</label>
      <input v-model="filling.filling" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="imageName">New Filling is currently available:</label>
      <input type="checkbox" v-model="filling.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addFlavor">
  <div class="form-group">
      <label for="frosting">Add New Flavor:</label>
      <input v-model="flavor.flavor" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="imageName">New Flavor is currently available:</label>
      <input type="checkbox" v-model="flavor.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addStyle">
  <div class="form-group">
      <label for="frosting">Add New Cake Style:</label>
      <input v-model="style.style" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="imageName">New Style is currently available:</label>
      <input type="checkbox" v-model="style.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
  </form>
  </div>
  <!-- <div id="addoptionform">
  <form @submit.prevent="addSize">
  <div class="form-group">
      <label for="frosting">Add New Cake Size:</label>
      <input v-model="size.size" type="text" class="form-control" />
    </div>
    <div class="form-group">
      <label for="imageName">New Size is currently available:</label>
      <input type="checkbox" v-model="size.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
  </form>
  </div> -->
  
  </div>
</template>

<script>
export default {
    name: 'add-option',
    data() {
    return {
      frosting: {
          frosting: '',
          isAvailable: true
        },
      filling: {
          filling: '',
          isAvailable: true

        },
        flavor: {
          flavor: '',
          isAvailable: true
        },
        style: {
          style: '',
          isAvailable: true,
          price: 0
        },
        size: {
          size: '',
          isAvailable: true,
          price: 0
        },

      updateFillingOptionErrors: false,
      updateFrostingOptionErrors: false,
      updateFlavorOptionErrors: false,
      updateSizeOptionErrors: false,
      updateStyleOptionErrors: false,
    };
    
  },
methods: {
    addFrosting() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFrosting`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.frosting),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes/' });
          } else {
            this.updateFrostingOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    addFilling() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFilling`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.filling),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes/' });
          } else {
            this.updateFlavorOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    addFlavor() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFlavor`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.flavor),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes/' });
          } else {
            this.updateFillingOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
     addStyle() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newStyle`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.style),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes/' });
          } else {
            this.updateStyleOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  }
}
</script>



<style>
#addoptionform{
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}
#addoptionform .form-group {
  width: 49%;
}
#addoptioncontainer {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  font-weight: bold;
}
#addoptionform .checkbox {
  width: 35px;
}

</style>