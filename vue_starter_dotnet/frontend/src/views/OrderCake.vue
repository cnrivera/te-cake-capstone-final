<template>
  <div>
      <p>{{cake.name}}</p>
  </div>
</template>

<script>
export default {
  name: 'orderCake',
  data() {
    return {
      cake: [],
    }
  },
  methods: {
    getCake(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/getCake/${id}`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake = data;
      })
      .catch((err) => console.error(err));
    }
  },
  created() {
    this.getCake(this.$route.params.id);
  }
}
</script>

<style>

</style>