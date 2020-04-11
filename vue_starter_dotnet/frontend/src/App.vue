<template>
  <div id="app">
    
    <div id="navbarcontents" class="container-fluid">

      <img src="./assets/elevate-sweets.png">
      <div id="navbarbuttons">
        <router-link :to="{name: 'home'}" class="btn btn-info" role="button">Home</router-link>
        <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">House Favorites</router-link>
        <router-link :to="{name: 'admin-menu'}" class="btn btn-info" role="button">Admin Menu</router-link>
        <router-link :to="{name: 'pending-orders'}" class="btn btn-info" role="button">Pending Orders</router-link>
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
  justify-content: left;
  height: 15vh;
}
#loginbutton {
  justify-content: right;
}
#navbarbuttons {
  display: flex;
  align-items: center;
}
#navbarbuttons .btn{
  font-size: 22px;
  margin: 10px;
}
#navbarcontents > img{
  height: 100%;
  margin-right: 50px;
}

</style>