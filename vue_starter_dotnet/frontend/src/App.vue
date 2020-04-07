<template>
  <div id="app">
    
    <nav class="navbar navbar-inverse">
      <div id="navbarcontents" class="container-fluid">

        <div id="header-img">
          <img class="header-img" src="./assets/elevate-sweets.png">
        </div>  
        <div id="navbutton">
          <button><router-link :to="{name: 'home'}">Home</router-link></button>
          <button><router-link :to="{name: 'standard-cakes'}">Standard Cakes</router-link></button>
        </div>
        <div id="loginbutton">
          <button><router-link :to="{name: 'login'}">Emplayee Login</router-link></button>
        </div>
      </div>
    </nav>

    <router-view/>
  </div>
</template>

<style>
body{
  margin: 100px;
  color: white;
}
.navbar{
  background-color: rgb(80, 76, 76);
  margin-bottom: 15px;
}
#navbarcontents {
  display: flex;
}
#navbutton {
  display: flex;
  justify-content: flex-start;
}
#loginbutton {
  display: flex;
  justify-content: flex-end;
}
#navbarcontents button{
  margin: 10px;
}
#header-img {
  height: 150px;
}
#header-img > img {
  height: 100%;
}

</style>