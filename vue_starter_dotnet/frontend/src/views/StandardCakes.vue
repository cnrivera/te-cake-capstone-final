<template>
<div id="standardcakescontainer">
  <div v-for="cake in cakes" :key="cake.name" class="cakeinfo">
    <h3>{{cake.name}}</h3>
    <div class="cakeimg">
      <img v-bind:src="require('../../src/assets/' + cake.imageName)" /> 
      <div class="price">${{cake.price}}</div>
    </div>
    <p>{{cake.description}}</p>
    <ul>
      <li>Style: {{cake.style}}</li>
      <li>Size: {{cake.size}}</li>
      <li>Flavor: {{cake.flavor}}</li>
      <li>Icing: {{cake.icing}}</li>
      <li>Filling: {{cake.filling}}</li>
    </ul>
    <router-link v-bind:to="{name: 'order-cake',params: {id:cake.id}}" class="btn btn-info" role="button">Purchase Cake</router-link>
  </div>

  <router-link to="/createcake" class="newcakebtn btn btn-lg btn-info btn-block">Add New Cake</router-link>
</div>
</template>

<script>

export default {
    name: "standard-cakes",
    data() {
      return {
        cakes: [],
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
  width: 49%;
}
#standardcakescontainer {
  margin-left: 14%;
  margin-right: 14%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}
.cakeimg > img {
  width: 100%;
  border-radius: 5px;
  margin-bottom: 10px;
}
li {
  list-style: none;
}
h3 {
  text-align: center;
}
.cakeimg {
  position: relative;
}
.price {
  position: absolute;
  top: 8px;
  right: 10px;
  background-color: hsla(188, 56%, 8%, 0.7);
  padding: 5px;
  border-radius: 5px;
  font-size: 1.5vw;
}
#standardcakescontainer .newcakebtn {
  margin: 20px;
  border: 2px solid black;
  box-shadow: 1px 2px 20px rgba(0,0,0,.6);
}
</style>