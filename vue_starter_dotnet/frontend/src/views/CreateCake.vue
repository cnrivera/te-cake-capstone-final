<template>
<div id="cakeform">
  <h1>Create a New Cake</h1>
  <div class="form-group">
    <label for="name">Name:</label>
    <input 
    type="text"
    class="form-control"
    placeholder="cake name"
    required
    />
  </div>
  <div class="form-group">
    <label for="price">Price:</label>
    <input 
    type="text"
    class="form-control"
    placeholder="price of cake"
    required
    />
  </div>
  <div class="form-group">
    <label for="style">Style:</label>
    <input 
    type="text"
    class="form-control"
    placeholder="what is it"
    required
    />
  </div>
</div>
</template>

<script>
export default {

}
</script>

<style>
#cakeform{
    margin: 100px;
}
</style>