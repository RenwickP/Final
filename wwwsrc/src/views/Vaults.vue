<template>
  <div class="vaults">
    <h1 class="header">Hello Vaults</h1>
  </div>
</template>

<script>
export default {
  name: "vaults",
  mounted() {
    console.log("Hi im a console log", this);
    // this.$store.dispatch("getVaultsById", this.$route.params.id);
    // console.log("test stuff", this.$store.state.activeVaults);
    this.$store.dispatch("getVaultKeepByVaultId", this.$route.params.id);
    // },
    // computed: {
    //   Vault() {
    //     return this.$store.state.activeVaults;
    //   }
  }
};
</script>

<style>
.header {
  text-align: Center;
  color: green;
}
</style>
