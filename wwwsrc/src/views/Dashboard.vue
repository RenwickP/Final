<template>
  <div class="dashboard">
    <h1 class="text">WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div><input type="text" /></div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style>
.text {
  text-align: Center;
  color: green;
}
</style>
