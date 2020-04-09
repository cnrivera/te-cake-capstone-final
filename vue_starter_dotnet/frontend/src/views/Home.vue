<template>
<div id="homepage">
  <div id="hometext">
    <p>Elevate Sweets provides delicious artisan cakes and treats for all occasions using the finest seasonal ingredients available. All of our baked goods are made fresh daily by veteran bakers with a keen sense for flavor and aesthetic. Select from one of our house favorites or create a custom cake from our currently available options.</p>
  </div>
  <div id="homebtn">
    <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">House Favorites</router-link>
    <router-link :to="{name: ''}" class="btn btn-info" role="button">Custom Cake</router-link>
  </div>
</div>
</template>

<script>
export default {
  name: 'home'
}
</script>

<style>
#homepage {
  background-image: url('../../src/assets/home-background.jpg');
  height: 85vh;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
#hometext {
  width: 55%;
  padding: 10vh;
  font-size: 1.1vw;
  font-weight: bold;
}
#homebtn {
  padding: 10vh;
}
#homebtn .btn {
  border: 2px solid black;
  box-shadow: 1px 2px 40px rgba(0,0,0,.6);
  font-size: 2.2vw;
  font-weight: bold;
  margin-left: 4vh;
}
</style>
