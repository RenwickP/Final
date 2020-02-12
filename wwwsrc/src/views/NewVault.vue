<template>
  <div class="newvault">
    <h1>Hello to new vaults</h1>
    <div v-for="keep in keeps" :key="keep.id">
      {{ keep }}
    </div>
  </div>
</template>
<script>
export default {
  name: "newvault",

  mounted() {
    this.$store.dispatch("getVaultKeepByVaultId", this.$route.params.id);
  },
  computed: {
    keeps() {
      return this.$store.state.activeVaultKeeps;
    }
  }
};
</script>
<style></style>
