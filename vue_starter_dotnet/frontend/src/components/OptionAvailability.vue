<template>
  <div id='optionavailability'>

    <div class="stylegroup">
      <h2>Cake Style's</h2>
      <div v-for="option in options.styles" :key="option.id">
        <button v-if="!option.available" class="btn btn-success btn-block">{{option.style}}</button>
        <button v-if="option.available" class="btn btn-danger btn-block">{{option.style}}</button>
      </div>
    </div>

  </div>
</template>

<script>
export default {
  name: 'option-availability',
  data() {
    return {
      options: {
        styles: [],
        sizes: [],
        flavors: [],
        frostings: [],
        fillings: [],
      }
    }
  },
  methods: {
    getFrostingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFrostings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.frostings = data;
      })
      .catch((err) => console.error(err));
    },
    getFillingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFillings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.fillings = data;
      })
      .catch((err) => console.error(err));
    },
    getFlavorsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFlavors`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.flavors = data;
      })
      .catch((err) => console.error(err));
    },
    getStylesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllStyles`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.styles = data;
      })
      .catch((err) => console.error(err));
    },
    getSizesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizes`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.sizes = data;
      })
      .catch((err) => console.error(err));
    },
  },
  created() {
    this.getFrostingsList();
    this.getFillingsList();
    this.getFlavorsList();
    this.getSizesList();
    this.getStylesList();
  },
}
</script>

<style>
  #optionavailability {
    margin-left: 10%;
    margin-right: 10%;
  }
 .stylegroup {
  margin-top: 15px;
  padding: 15px;
  padding-right: 35px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
 }
</style>