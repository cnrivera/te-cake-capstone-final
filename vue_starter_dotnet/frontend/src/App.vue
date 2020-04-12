<template>
  <div id="app">
    <div id="navbarcontents" class="container-fluid">
      <div class="navbarbuttons">
        <img src="./assets/elevate-sweets.png">
        <router-link :to="{name: 'home'}" class="btn btn-info" role="button">Home</router-link>
        <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">House Favorites</router-link>
        <router-link :to="{name: 'order-custom-cake'}" class="btn btn-info" role="button">Custom Cake</router-link>
      </div>
      <div class="adminbutton">
        <router-link :to="{name: 'admin-menu'}" class="btn btn-default" role="button">Admin Menu</router-link>
      </div>
    </div>

    <router-view/>
  </div>
</template>

<style>
html, #app{
  background-color: rgb(45, 214, 214);
}
#navbarcontents {
  background-color: rgb(56, 54, 54);
  display: flex;
  justify-content: space-between;
  height: 15vh;
}
.navbarbuttons .btn{
  font-size: 22px;
  margin: 10px;
}
.navbarbuttons img{
  height: 100%;
  margin-right: 50px;
}
.adminbutton .btn{
  color: whitesmoke;
  width: 120px;
}
</style>