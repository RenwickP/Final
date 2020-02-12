<template>
  <div class="dashboard">
    <h1 class="text">WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div><input type="text" /></div>
    <h3>Check Out Your Vaults!</h3>
    <div>
      <div v-for="vault in vaults" :key="vault.id">
        {{ vault.id }}<button @click="getVk(vault.id)">getStuff</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    getVk(id) {
      this.$store.dispatch("getVaultKeepByVaultId", id);
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
