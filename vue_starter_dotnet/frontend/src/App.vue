<template>
  <div id="app">
    
    <nav class="navbar navbar-inverse">
      <div id="navbarcontents" class="container-fluid">

        <div id="header-img">
          <img class="header-img" src="./assets/elevate-sweets.png">
        </div>  
        <router-link :to="{name: 'home'}" class="btn btn-info" role="button">Home</router-link>
        <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">Standard Cakes</router-link>
        <router-link :to="{name: 'login'}" class="btn btn-info" role="button">Employee Login</router-link>
      </div>
    </nav>

    <router-view/>
  </div>
</template>

<style>
html, #app{
  background-color: rgb(24, 184, 184);
}
.navbar{
  background-color: rgb(56, 54, 54);
}
#navbarcontents {
  display: flex;
  justify-content: left;
}
#loginbutton {
  justify-content: right;
}
#navbarcontents .btn{
  margin: 10px;
}
#header-img {
  height: 15vh;
  margin-right: 40px;
}
#header-img > img {
  height: 100%;
}

</style>