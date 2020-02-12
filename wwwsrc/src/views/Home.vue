<template>
  <div class="home">
    <h1 class="text">Welcome Home</h1>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
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
