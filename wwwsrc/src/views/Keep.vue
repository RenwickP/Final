<template>
  <div class="keep">
    <h1>Check out this keep</h1>
    <p>{{ keep.name }}</p>

    <h2>Test Data</h2>
    <div v-for="vault in vaults" :key="vault.id">{{ vault.id }}</div>
    {{ vaults }}
  </div>
</template>
<script>
export default {
  name: "keep",

  mounted() {
    this.$store.dispatch("getKeepsById", this.$route.params.id);
    this.$store.dispatch("getVaults");
  },

  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },

    vaults() {
      return this.$store.state.vaults;
    }
  }
};
</script>
<style></style>
