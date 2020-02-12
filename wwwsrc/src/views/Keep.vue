<template>
  <div class="keep">
    <h1>Check out this keep</h1>
    <p>{{ keep.name }}</p>

    <h2>Test Data</h2>
    <div v-for="vault in vaults" :key="vault.id">
      <button @click="addKeep(vault.id)">
        Add Keep to a vault!
      </button>
      {{ vault.name }}
    </div>
  </div>
</template>
<script>
export default {
  name: "keep",
  data() {
    return {
      newRel: {
        keepId: "",
        vaultId: ""
      }
    };
  },

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
  },
  methods: {
    addKeep(id) {
      let keep = { ...this.newKeep };
      console.log("from create rel", keep);
      this.$store.dispatch("makeKeepRel", keep);
      this.newKeep = {
        keepId: this.$route.params.id,
        vaultId: id
      };
    }
  }
};
</script>
<style></style>
