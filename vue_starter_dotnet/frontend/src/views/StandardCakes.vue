<template>
<div class="container">
  <div v-for="cake in cakes" :key="cake.name" class="alert alert-info" >
      <h3>{{cake.name}} price: ${{cake.price}}</h3>
      <p>style: {{cake.style}} size: {{cake.size}} flavor: {{cake.flavor}}</p>
      <p>icing: {{cake.icing}} filling: {{cake.filling}}</p>
      <p>{{cake.description}}</p>
  </div>

  <router-link to="/createcake">Add New Cake</router-link>
</div>
</template>

<script>
export default {
    data() {
        return {
            cakes: [
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
            ]
        }
    }
}
</script>

<style>

</style>