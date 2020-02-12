<template>
  <div class="home">
    <h1 class="text">Welcome Home Friend</h1>
    <div
      class="text-color"
      v-for="publickeep in publicKeeps"
      :key="publickeep.id"
    >
      {{ publickeep.name }}
    </div>
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
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
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
