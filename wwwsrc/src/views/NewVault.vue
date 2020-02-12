<template>
  <div class="newvault">
    <h1>Hello to new vaults</h1>
  </div>
</template>
<script>
export default {
  name: "newvault",

  mounted() {
    this.$store.dispatch("getVaultKeepByVaultId", this.$route.params.id);
  }
};
</script>
<style></style>
