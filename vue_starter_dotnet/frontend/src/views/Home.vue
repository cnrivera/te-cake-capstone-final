<template>
<div id="homepage">
  <div id="hometext">
    <p>There was one who said unto me that the universe was going to cause me to tremble,
    That I am not the sharpest cutting implement in the storehouse.She had the appearance unto me as a stupid one,
    With her finger and her thumb
    In the frame of a Greek gamma upon her forehead.
    Behold, the years begin coming, and do not cease from coming.
    Fed unto the axioms, and I fell upon the earth and ran.
    It was not acceptable if not to live for the sake of pleasurable things.
    Your brain increases its wisdom, but your heart increases its stupidity.
    A great amount to do, a great amount to see,
    Therefore, there is no difficult problem if we take the streets of the backside.
    </p>
  </div>
  <div id="homebtn">
    <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">Standard Cakes</router-link>
    <router-link :to="{name: ''}" class="btn btn-info" role="button">Make a Cake</router-link>
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
