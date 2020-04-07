<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg">
    <div class="justify-content-start" id="header-img">
      <img class="header-img" src="./assets/elevate-sweets.png">
      <ul class="navbar-nav ml-auto">
        <li class="nav-item"><router-link to="/">Home</router-link></li>
        <li class="nav-item"><router-link to="/standardcakes">Standard Cakes</router-link></li>
      </ul>
    </div>  
    <router-view/>
    </nav>
  </div>
</template>

<style>
body{
  margin: 100px;
}

#header-img {
  height: 150px;
}

#header-img > img {
  height: 100%;
}
</style>