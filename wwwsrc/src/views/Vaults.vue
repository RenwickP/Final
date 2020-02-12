<template>
  <div><h1>Hello Vaults</h1></div>
</template>

<script>
export default {
  mounted() {
    console.log("Hi im a console log");
    this.$store.dispatch("getVaultsById", this.$route.params.id);
  }
};
</script>
