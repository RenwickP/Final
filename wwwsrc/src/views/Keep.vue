<template>
  <div class="keep">
    <h1>Check out this keep</h1>
  </div>
</template>
<script>
export default {
  name: "keep",

  mounted() {
    this.$store.dispatch("getKeepsById", this.$route.params.id);
  },

  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>
<style></style>
