<template>
  <div class="dashboard">
    <h1 class="text">WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div><input type="text" /></div>
  </div>
</template>

<script>
export default {
  mounted() {},
  computed: {}
};
</script>

<style>
.text {
  text-align: Center;
  color: green;
}
</style>
