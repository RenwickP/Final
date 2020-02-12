<template>
  <div class="newvault">
    <h1>Hello to new vaults</h1>
    <div v-for="keep in keeps" :key="keep.id">
      {{ keep.name }}
      <button @click="deleteKeep(keep.id)">
        Delete Keep
      </button>
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
  },
  methods: {
    deleteKeep(id) {
      let deleteData = {
        vaultId: this.$route.params.id,
        keepId: id
      };
      this.$store.dispatch("deleteRel", deleteData);
      console.log("from newvault delete", deleteData);
    }
  }
};
</script>
<style></style>
