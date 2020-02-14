<template>
  <div class="container-fluid">
    <div class="row">
      <div class="keep col-12">
        <h1>Check out this keep</h1>
        <p>{{ keep.name }}</p>
        <img :src="keep.img" />
        <h2>Test Data</h2>
        <div class="row">
          <div class="col-2">
            <div v-for="vault in vaults" :key="vault.id">
              <button @click="addKeep(vault.id)">
                Add Keep to a vault!
              </button>
              {{ vault.name }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "keep",
  data() {
    return {
      newRel: {
        keepId: this.$route.params.id,
        vaultId: ""
      }
    };
  },

  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getKeepsById", this.$route.params.id);
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
      console.log("from add keep", keep);
    }
  }
};
</script>
<style></style>
