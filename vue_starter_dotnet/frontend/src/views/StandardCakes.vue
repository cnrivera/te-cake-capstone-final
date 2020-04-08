<template>
<div class="container">
    <h1>here</h1>
  <div v-for="cake in cakes" :key="cake.name" class="cakeinfo">
      <h3>{{cake.name}} price: ${{cake.price}}</h3>
      <p>style: {{cake.style}} size: {{cake.size}} flavor: {{cake.flavor}}</p>
      <p>icing: {{cake.icing}} filling: {{cake.filling}}</p>
      <p>{{cake.description}}</p>
  </div>

  <router-link to="/createcake" >Add New Cake</router-link>
</div>
</template>

<script>

export default {
    name: "standard-cakes",
    data() {
        return {
            /*cakes: [
                {
                    name: 'holy sheet cake',
                    price: 50,
                    style: 'sheetcake',
                    size: 'large',
                    flavor: 'vanilla',
                    icing: 'chocolate',
                    filling: 'raspberry',
                    description: 'thats a damn good cake'
                },
                {
                    name: 'nice cake!',
                    price: 40,
                    style: 'layer cake',
                    size: 'small',
                    flavor: 'vanilla',
                    icing: 'chocolate',
                    filling: 'vanilla',
                    description: 'MMMmmmm cake!'
                }
            ]*/
            cakes: []
        }
    },
    methods: {
    getCakeList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/getAll`)
        .then((response) => {
          return response.json();
        })
        .then((data) => {
            this.cakes = data;
        })
        .catch((err) => console.error(err));
    },
  },
  created() {
    console.log("hello");
    this.getCakeList();
  }
}
</script>

<style>
.cakeinfo {
    margin-top: 15px;
    padding: 15px;
    background-color: hsla(188, 56%, 8%, 0.7);
    color: whitesmoke;
    border-radius: 5px;
}
</style>