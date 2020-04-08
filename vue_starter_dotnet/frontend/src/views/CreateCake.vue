<template>
<div id="cakeform">
  <h1>Create a New Cake</h1>
  <div class="alert alert-danger" role="alert" v-if="createCakeErrors">
        There were problems creating this cake.
      </div>
  <form class="form-register" @submit.prevent="createCake">
  <div class="form-group">
    <label for="name">Name:</label>
    <input v-model="cake.name"
    type="text"
    class="form-control"
    placeholder="cake name"
    required
    />
  </div>
  <div class="form-group">
    <label for="price">Price:</label>
    <input v-model="cake.price"
    type="text"
    class="form-control"
    placeholder="price of cake"
    required
    />
  </div>
  <div class="form-group">
    <label for="style">Style:</label>
    <input v-model="cake.style"
    type="text"
    class="form-control"
    placeholder="what is it"
    required
    />
  </div>
  <div class="form-group">
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
    <label for="icing">Icing:</label>
    <input v-model="cake.icing"
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
  </div>
  <div class="form-group">
    <label for="description">Description:</label>
    <input v-model="cake.description"
    type="text"
    class="form-control"
    required
    />
  </div>
  <div class="form-group">
    <label for="imageName">Image File Name, if loaded (otherwise leave placeholder file)</label>
    <input v-model="cake.imageName"
    type="text"
    class="form-control"
    />
  </div>
  <div class="form-group">
    <label for="imageName">Cake is available for sale:</label>
    <input type="checkbox" v-model="cake.isAvailable"
    class="form-control"
    />
  </div>
  
  <button class="btn btn-lg btn-info btn-block" type="submit" >
        Create Cake
      </button>
      </form>
</div>

</template>

<script>
export default {
  name: 'createCake',
  data() {
    return {
      cake: {
        name: '',
        price: '',
        style: '',
        size: '',
        flavor: '',
        icing: '',
        filling: '',
        description: '',
        imageName: 'placeholder-image.png',
        isAvailable: true
      },
      createCakeErrors: false,
    };
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
  },

}
</script>

<style>
#cakeform{
    margin: 100px;
}
</style>